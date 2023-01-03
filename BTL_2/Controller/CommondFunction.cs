using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuyThien_BTL.KetNoi
{
    internal class CommondFunction

    {
        AccessData Data = new AccessData();
        public void FillCombobox(ComboBox cbo, DataTable dtData, string display, string value)
        {
            cbo.DataSource = dtData;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
        }
        //Autocode 0 1 2
        public string AutoCode(string nameTable, string nameCode, string valueStart)
        {
            int code = 1;
            string id = "";
            string luu = valueStart;
            bool check = false;
            do
            {
                if (code < 10)
                    valueStart += "0";
                id = valueStart + code.ToString();
                DataTable dt = Data.ReadData("Select * from " + nameTable +
                " where " + nameCode + " ='" + id + "'");
                if (dt.Rows.Count == 0)
                    check = true;
                else
                {
                    code++;
                    valueStart = luu;
                }

            }
            while (check == false);

            return id;
        }
        //Autocode A B C
        public string AutoCodeABC(string nameTable, string nameCode, string valueStart)
        {
            char kt = 'A';
            string id = "";
            string luu = valueStart;
            bool check = false;
            do
            {
                id = valueStart + kt.ToString();
                DataTable dt = Data.ReadData("Select * from " + nameTable +
                " where " + nameCode + " ='" + id + "'");
                if (dt.Rows.Count == 0)
                    check = true;
                else
                {
                    kt++;
                    valueStart = luu;
                }

            }
            while (check == false);

            return id;
        }
    }
}
