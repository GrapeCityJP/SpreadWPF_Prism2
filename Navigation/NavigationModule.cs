using Navigation.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigationの対象となるViewをコンテナに登録
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}