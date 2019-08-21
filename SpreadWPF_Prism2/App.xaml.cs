using SpreadWPF_Prism2.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Data;
using System.Windows;

namespace SpreadWPF_Prism2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // データファイルの読み込み
            ProductModel.LoadProducts();

            // Prismの既定処理
            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // データのインスタンスをコンテナに登録
            containerRegistry.RegisterInstance<DataTable>(ProductModel.GetProducts());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // モジュールの追加
            moduleCatalog.AddModule<Navigation.NavigationModule>();

            // Prismの既定処理
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
