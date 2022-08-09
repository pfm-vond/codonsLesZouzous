using Autofac.Versioned;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FizzBuzz.Library
{
    class ReleaseNoteGame : IFizzBuzzGame
    {
        private readonly IEnumerable<FeatureNotes> features;
        private readonly IConfiguration config;
        private readonly IFizzBuzzGame game;
        private readonly Display display;

        public ReleaseNoteGame(
            IEnumerable<FeatureNotes> features, 
            IConfiguration cfg,
            IFizzBuzzGame game,
            Display display)
        {
            this.features = features;
            this.config = cfg;
            this.game = game;
            this.display = display;
        }

        public void Play()
        {
            if(config["notes"] != null)
                foreach(var feature in features)
                    display(feature.ToString());
            else
                game.Play();
        }
    }
}
