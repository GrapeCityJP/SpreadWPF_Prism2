using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace SpreadWPF_Prism2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand SaveCommand { get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            // RegionManagerの取得
            _regionManager = regionManager;

            // コマンドの作成
            NavigateCommand = new DelegateCommand<string>(Navigate);
            SaveCommand = new DelegateCommand(SaveData);
        }

        private void Navigate(string navigatePath)
        {
            if (string.IsNullOrEmpty(navigatePath))
            {
                // ContentRegion内のViewを削除
                _regionManager.Regions["ContentRegion"].RemoveAll();
            }
            else
            {
                // ContentRegionにViewを設定
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

        // データの保存
        private void SaveData()
        {
            ProductModel.SaveProducts();
        }
    }
}
