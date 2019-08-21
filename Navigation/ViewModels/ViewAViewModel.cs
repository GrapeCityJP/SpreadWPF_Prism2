using Prism.Commands;
using Prism.Mvvm;
using System.Data;

namespace Navigation.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        public DelegateCommand<string> AddCommand { get; private set; }
        public DelegateCommand<string> DeleteCommand { get; private set; }
        public DelegateCommand<string> AcceptCommand { get; private set; }
        public DelegateCommand<string> RejectCommand { get; private set; }

        public ViewAViewModel(DataTable dt)
        {
            // データの取得
            Products = dt;

            // コマンドの作成
            AddCommand = new DelegateCommand<string>(Add);
            DeleteCommand = new DelegateCommand<string>(Delete);
            AcceptCommand = new DelegateCommand<string>(Accept);
            RejectCommand = new DelegateCommand<string>(Reject);
        }

        // データを保持するプロパティ
        private DataTable _products;
        public DataTable Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        // カレントレコードを保持するプロパティ
        private DataRowView _selectedProduct;
        public DataRowView SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        // レコードの追加
        private void Add(string obj)
        {
            Products.Rows.Add(Products.NewRow());
        }

        // レコードの削除
        private void Delete(string obj)
        {
            SelectedProduct.Delete();
        }

        // 変更の確定
        private void Accept(string obj)
        {
            Products.DataSet.AcceptChanges();
        }

        // 変更の破棄
        private void Reject(string obj)
        {
            Products.DataSet.RejectChanges();
            Products.DataSet.AcceptChanges();
        }
    }
}
