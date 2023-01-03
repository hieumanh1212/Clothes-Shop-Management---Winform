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
    public partial class TestMenu : Form
    {
        public TestMenu()
        {
            InitializeComponent();
        }


        bool checkMenu;
        bool checkdouble;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(checkMenu)
            {
                MenuFlow.Width -= 10;
                if(MenuFlow.Width == MenuFlow.MinimumSize.Width)
                {
                    checkMenu = false;
                    timeMenu.Stop();
                }    
            }
            else
            {
                MenuFlow.Width += 10;
                if (MenuFlow.Width == MenuFlow.MaximumSize.Width)
                {
                    checkMenu = true;
                    timeMenu.Stop();
                }
            }    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timeMenu.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timeDouble_Tick(object sender, EventArgs e)
        {
            if (checkdouble)
            {
                PanelDouble.Height += 10;
                if (PanelDouble.Height == PanelDouble.MaximumSize.Height)
                {
                    checkdouble = false;
                    timeDouble.Stop();
                }
            }
            else
            {
                PanelDouble.Height -= 10;
                if (PanelDouble.Height == PanelDouble.MinimumSize.Height)
                {
                    checkdouble = true;
                    timeDouble.Stop();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeDouble.Start();
        }
    }
}
