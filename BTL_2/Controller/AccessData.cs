using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DuyThien_BTL.KetNoi
{
    internal class AccessData
    {
        // khai bao bien
        SqlConnection SqlConn = null;


        public string connectionString = "Data Source=DESKTOP-FRVSHFM\\SQLEXPRESS;Initial Catalog=CSDL_BTL_C#;Integrated Security=True";


        // phuong thuc mo ket noi
        public void OpenConnect()
        {
            SqlConn = new SqlConnection(connectionString);
            if (SqlConn.State != ConnectionState.Open)
                SqlConn.Open();
        }

        // phuong thuc dong ket noi

        public void CloseConnect()
        {
            if (SqlConn.State != ConnectionState.Closed)
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }

        // phuong thuc doc du lieu tra ve mot DataTable, input: cau lenh Select, ouput: DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dtData = new DataTable();
            OpenConnect();
            SqlDataAdapter dtDataA = new SqlDataAdapter(sqlSelect, SqlConn);
            dtDataA.Fill(dtData);
            CloseConnect();
            return dtData;
        }

        // phuong thuc thuc hien cac lenh insert, update, delete
        public void UpdateData(string sql)
        {
            OpenConnect();
            //SqlCommand sqlComm = new SqlCommand();
            //sqlComm.Connection = SqlConn;
            //sqlComm.CommandText = sql;

            SqlCommand sqlComm = new SqlCommand(sql);
            sqlComm.Connection = SqlConn;

            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
    }
}
