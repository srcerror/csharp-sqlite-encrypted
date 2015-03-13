using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Data;
using Community.CsharpSqlite.SQLiteClient;
using test;

namespace Test.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        public void WriteLine(String value)
        {
            this.listBox1.Items.Add(value);// + Environment.NewLine;
        }

        protected void MainPage_Loaded(object sender, EventArgs e)
        {

            //var lst = new List<string>();
            //IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication();
            //isf.DeleteFile("test.db");

            //using (SqliteConnection conn = new SqliteConnection("Version=3,uri=file:test.db"))
            //{

            //    conn.Open();
            //    using (IDbCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "pragma hexkey='0x73656372657470617373776F72640f11'";
            //        cmd.ExecuteNonQuery();
            //    }
            //    using (SqliteCommand cmd = conn.CreateCommand() as SqliteCommand)
            //    {
            //        cmd.CommandText = "CREATE TABLE test ( [id] INTEGER PRIMARY KEY, [col] INTEGER UNIQUE, [col2] INTEGER, [col3] REAL, [col4] TEXT, [col5] BLOB)";
            //        cmd.ExecuteNonQuery();

            //        cmd.Transaction = conn.BeginTransaction();
            //        cmd.CommandText = "INSERT INTO test(col, col2, col3, col4, col5) VALUES(@col, @col2, @col3, @col4, @col5);SELECT last_insert_rowid();";
            //        cmd.Parameters.Add("@col", null);
            //        cmd.Parameters.Add("@col2", null);
            //        cmd.Parameters.Add("@col3", null);
            //        cmd.Parameters.Add("@col4", null);
            //        cmd.Parameters.Add("@col5", null);

            //        DateTime start = DateTime.Now;
            //        lst.Add("Inserting 100 Rows with transaction");

            //        for (int i = 0; i < 100; i++)
            //        {
            //            cmd.Parameters["@col"].Value = i;
            //            cmd.Parameters["@col2"].Value = i;
            //            cmd.Parameters["@col3"].Value = i * 0.515;
            //            cmd.Parameters["@col4"].Value = "สวัสดี な. あ · か · さ · た · な · は · ま · や · ら · わ. 形容詞 hello " + i;
            //            cmd.Parameters["@col5"].Value = Encoding.UTF8.GetBytes("สวัสดี");

            //            object s = cmd.ExecuteScalar();
            //        }
            //        cmd.Transaction.Commit();
            //        cmd.Transaction = null;
            //        lst.Add("Time taken :" + DateTime.Now.Subtract(start).TotalMilliseconds + " ms.");

            //        cmd.CommandText = "SELECT * FROM test";
            //        try
            //        {


            //            using (IDataReader reader = cmd.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    var bytes = (byte[])reader.GetValue(5);
            //                    lst.Add(string.Format("{0},{1},{2},{3},{4}, {5}",
            //                                                           reader.GetInt32(0),
            //                                                           reader.GetInt32(1),
            //                                                           reader.GetInt32(2),
            //                                                           reader.GetDouble(3),
            //                                                           reader.GetString(4),
            //                                                           Encoding.UTF8.GetString(bytes, 0, bytes.Length)));
            //                }
            //            }
            //        }
            //        catch (ApplicationException exc)
            //        {
            //            Debug.WriteLine(exc);
            //        }
            //        conn.Close();
            //    }
            //}


            //SQLiteClientTests.SQLiteClientTestDriver.Main(null);
            IDbConnection cnn;

            try
            {
                System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().DeleteFile("test.db3");
            }
            catch { }


            using (cnn = new SqliteConnection())
            {
                TestCases tests = new TestCases();

                cnn.ConnectionString = "data source=test.db3,password=0x01010101010101010101010101010101";
                cnn.Open();
                tests.Run(cnn, this);
            }
        }
    }
}