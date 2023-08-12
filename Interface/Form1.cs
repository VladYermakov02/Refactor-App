using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form1 : Form
    {
        InfoExchanger ie = new InfoExchanger();
        Form2 f2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            f2.ReloadForm1 += Reload;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Refactor";
        }

        private void Reload()
        {
            rTB_Code.Text = ie.getText();
        }

        private void cB_Action_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rTB_Code.TextLength == 0)
            {
                MessageBox.Show($"Fill in the code field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int index = cB_Action.SelectedIndex;
                ie.setText(rTB_Code.Text);
                if (rTB_Code.SelectedText.Length != 0)
                {
                    ie.setSelectedText(rTB_Code.SelectedText);
                }

                switch (index)
                {
                    case 0:
                        {
                            ie.setIndex(0);
                            f2.ShowDialog();
                            break;
                        }
                    case 1:
                        {
                            ie.setIndex(1);
                            f2.ShowDialog();
                            break;
                        }
                    case 2:
                        {
                            ie.setIndex(2);
                            f2.ShowDialog();
                            break;
                        }
                    case 3:
                        {
                            ie.setIndex(3);
                            f2.ShowDialog();
                            break;
                        }
                }
            }
        }
    }
}
