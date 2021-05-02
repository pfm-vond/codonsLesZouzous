public record LongTermStorage(string ProviderName, string ConnectionString);

// ----------------------------------------------------------------------------------------------------------------------------------------------------------------

var product = Product.GetBuilder();

product
    .ConfigureFallBack(t => t.IsInterface, t => new Mock<t>())
    .Then(t => Fixture.CanFix(t), t => Fixture.Create(t))
    .Then(null)
    .Then((t, c) => throw new DependencyException(t, c));

product.AnswerNeed<LongTermStorage>()
       .ViaFeature<SqlServerDatabase>()
       .EnableOn(longtermStorage => longtermStorage != null && longtermStorage.ProviderName == "System.Data.EntityClient");

product.AnswerNeed<LongTermStorage>()
       .ViaFeature<MemoryDatabase>()
       .DisableOn(longtermStorage => longtermStorage != null);

builder.Build();

// ----------------------------------------------------------------------------------------------------------------------------------------------------------------

public class SqlServerDatabase : IFeature<LongTermStorage>
{
    public Register(ScopeProvider scope, Feature<LongTermStorage> feature)
    {
        feature.Need<IUnitOfWork>()
                .EnsureBy<DataStorageIntegrity>()
                .WithParam("ConnectionString", feature.Config.ConnectionString)
                .During(scope.Named("Transaction"))
                .StartingWithMe();

        feature.Need(typeof(ISet<>))
                .EnsureBy(typeof(DbSet<>))
                .Using<DbContext, T>(dbc => dbc.Set<T>())
                .During(scope.Named("Transaction"));

        feature.Need(typeof(ISet<User>))
                .EnsureBy(typeof(DbSet<User>))
                .Using<DbContext>(dbc => dbc.Users)
                .During(scope.Named("Transaction"));

        feature.Need<Func<UserIdentity, User>>()
                .EnsureBy<RetrievingOrCreatingUser>()
                .During(scope.EachCall());
    }
}

public class MemoryDatabase : IFeature
{
    public Register(ScopeProvider scope, Feature feature)
    {
        feature.Need<IUnitOfWork>()
                .EnsureBy<ListingSet>()
                .During(scope.Named("Transaction"));

        feature.Need(typeof(ISet<>))
                .EnsureBy(typeof(ManagingA<>))
                .During(scope.ProductLifeTime());

        feature.Need<Func<UserIdentity, User>>()
                .EnsureBy<RetrievingOrCreatingUser>()
                .During(scope.EachCall());

        feature.Need<IDocument>()
                .EnsureBy<DemonstratingReadingDocument>()
                .GenerateFake()
                .During(scope.EachCall());
                
        feature.Need<IImage>()
                .EnsureBy<Fake<IImage>>()
                .During(scope.SingleInstance(new Fake<IImage>()));

        feature.Need<IAudio>()
                .EnsureBy<Fake<IAudio>>()
                .UsingFactory<AudioMaker>()
                .During(scope.EachCall());
    }
}