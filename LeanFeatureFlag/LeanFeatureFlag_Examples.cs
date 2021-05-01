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
                .ResponsibleFor<DataStorageIntegrity>()
                .WithParam("ConnectionString", feature.Config.ConnectionString)
                .During(scope.Named("Transaction"))
                .StartingWithMe();

        feature.Need(typeof(ISet<>))
                .ResponsibleFor(typeof(DbSet<>))
                .Using<DbContext, T>(dbc => dbc.Set<T>())
                .During(scope.Named("Transaction"));

        feature.Need(typeof(ISet<User>))
                .ResponsibleFor(typeof(DbSet<User>))
                .Using<DbContext>(dbc => dbc.Users)
                .During(scope.Named("Transaction"));

        feature.Need<Func<UserIdentity, User>>()
                .ResponsibleFor<RetrievingOrCreatingUser>()
                .During(scope.EachCall());
    }
}

public class MemoryDatabase : IFeature
{
    public Register(ScopeProvider scope, Feature feature)
    {
        feature.Need<IUnitOfWork>()
                .ResponsibleFor<ListingSet>()
                .During(scope.Named("Transaction"));

        feature.Need(typeof(ISet<>))
                .ResponsibleFor(typeof(ManagingA<>))
                .During(scope.ProductLifeTime());

        feature.Need<Func<UserIdentity, User>>()
                .ResponsibleFor<RetrievingOrCreatingUser>()
                .During(scope.EachCall());

        feature.Need<IDocument>()
                .ResponsibleFor<DemonstratingReadingDocument>()
                .GenerateFake()
                .During(scope.EachCall());
                
        feature.Need<IImage>()
                .ResponsibleFor<Fake<IImage>>()
                .During(scope.SingleInstance(new Fake<IImage>()));

        feature.Need<IAudio>()
                .ResponsibleFor<Fake<IAudio>>()
                .UsingFactory<AudioMaker>()
                .During(scope.EachCall());
    }
}