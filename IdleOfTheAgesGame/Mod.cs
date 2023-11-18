using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;

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
            dataLoader.LoadLanguages("Assets", "Languages");
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
