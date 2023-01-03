using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormCha : Form
    {
        public FormCha()
        {
            InitializeComponent();
        }
        private void add_form(Form a)
        {
            a.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(a);
            a.BringToFront();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (CheckExitsFrom("FormCon.FormCon") == false)
            {
                FormCon.FormCon fc = new FormCon.FormCon();
                fc.MdiParent = this;
                add_form(fc);
                fc.Show();
            }
            else
                ActiveChildForm("FormCon.FormCon");


        }
        private bool CheckExitsFrom(string nameform)
        {
            bool check = false;
            foreach(Form f in this.MdiChildren)
            {
                if(f.Name == nameform)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveChildForm(string nameform)
        {
            
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == nameform)
                {
                    f.Activate();
                    break;
                }
            }
           
        }

        private void FormCha_Load(object sender, EventArgs e)
        {

        }
    }
}
