using System;
using System.Data;
using System.IO;

namespace SpreadWPF_Prism2
{
    class ProductModel
    {
        private static DataSet ds;
        private const string DATA_FILE_PATH = "Products.xml";

        public ProductModel() { }

        // データファイルの読み込み
        public static void LoadProducts()
        {
            if (ds == null)
            {
                ds = new DataSet();
            }

            if (File.Exists(DATA_FILE_PATH))
            {
                ds.ReadXml(DATA_FILE_PATH);
                ds.AcceptChanges();
            }
        }

        // データの取得
        public static DataTable GetProducts()
        {
            // 初期値の作成
            if (ds != null && ds.Tables.Count == 0)
            {
                DataTable dt = ds.Tables.Add("Product");
                dt.Columns.Add("Code", typeof(String));
                dt.Columns.Add("Name", typeof(String));
                dt.Columns.Add("Price", typeof(Int32));
                dt.Rows.Add("0000001", "アーモンド", 200);
                dt.Rows.Add("0000002", "グレープシード", 200);
                dt.Rows.Add("0000003", "オリーブ", 320);
                dt.Rows.Add("0000004", "ゴマ油", 300);
                dt.Rows.Add("0000005", "ひまわり", 200);
                dt.Rows.Add("0000006", "えごま", 300);
                dt.Rows.Add("0000007", "アルガン", 800);
                dt.Rows.Add("0000008", "ココナッツ", 720);
                dt.Rows.Add("0000009", "ウォールナッツ", 400);
                dt.Rows.Add("0000010", "亜麻仁油", 700);
                ds.AcceptChanges();
            }

            // 戻り値の設定
            return ds.Tables["Product"];
        }

        // データファイルの保存
        public static void SaveProducts()
        {
            ds.AcceptChanges();
            ds.WriteXml(DATA_FILE_PATH, XmlWriteMode.WriteSchema);
        }
    }
}
