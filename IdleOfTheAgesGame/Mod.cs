using IdleOfTheAgesGame.Skills;

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Services;

namespace IdleOfTheAgesGame {
    public class Mod : IMod {
        public void AppLoaded(IServiceLibrary serviceLibrary) {
            serviceLibrary.Get<ILogger>().Info("App Loaded");
        }

        public void GameLoaded(IServiceLibrary serviceLibrary) {
            serviceLibrary.Get<ILogger>().Info("Game Loaded");
            var dataLoader = serviceLibrary.Get<IDataLoader>();
            dataLoader.LoadData("data.json");
            dataLoader.RegisterTextures("Assets");
            serviceLibrary.Get<ISkillService>().RegisterSkill<Woodcutting>();
            serviceLibrary.Get<ISkillService>().RegisterSkill<Mining>();
        }

        public void ModLoaded(IServiceLibrary serviceLibrary) {
            serviceLibrary.Get<ILogger>().Info("Mod Loaded");
        }

        public void RegisterPublicServices(IServiceRegistry serviceRegistry) {
            
        }

        public void RegisterServices(IServiceRegistry serviceRegistry) {

        }
    }
}
