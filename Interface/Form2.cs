using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class Form2 : Form
    {
        private InfoExchanger ie = new InfoExchanger();

        public event Action ReloadForm1;

        public Form2()
        {
            InitializeComponent();
        }

        private void bRefactor_Click(object sender, EventArgs e)
        {
            if (rTBText.TextLength != 0 && rTBNewName.TextLength != 0)
            {
                switch (ie.getIndex())
                {
                    case 0:
                        {
                            ie.setText(ConsoleApp1.VariableRename.rename(ie.getText(), rTBText.Text, rTBNewName.Text));
                            break;
                        }
                    case 1:
                        {
                            ie.setText(ConsoleApp1.MethodExtraction.ExtractMethod(ie.getText(), rTBText.Text, rTBNewName.Text));
                            break;
                        }
                    case 2:
                        {
                            ie.setText(ConsoleApp1.Refactor.RenameMethod(rTBText.Text, rTBNewName.Text, ie.getText()));
                            break;
                        }
                    case 3:
                        {
                            ie.setText(ConsoleApp1.Refactor.ReplaceMagicNumber(rTBText.Text, rTBNewName.Text, ie.getText()));
                            break;
                        }
                }

                ReloadForm1();
            }
            else MessageBox.Show($"Fill in the fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rTBText.Text = "";
            rTBNewName.Text = "";

            if (ie.getSelectedText().Length !=0)
            {
                rTBText.Text = ie.getSelectedText();
            }

            switch (ie.getIndex())
            {
                case 0:
                    {
                        this.Text = "Variable rename";
                        lText.Text = "Old variable:";
                        lNewName.Text = "New variable name:";
                        break;
                    }
                case 1:
                    {
                        this.Text = "Method extraction";
                        lText.Text = "Method text:";
                        lNewName.Text = "Method name:";
                        break;
                    }
                case 2:
                    {
                        this.Text = "Method rename";
                        lText.Text = "Old method name:";
                        lNewName.Text = "New method name:";
                        break;
                    }
                case 3:
                    {
                        this.Text = "Replace magic number";
                        lText.Text = "Magical number:";
                        lNewName.Text = "Symbol to replace:";
                        break;
                    }
            }

            ie.setSelectedText("");
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadForm1();
        }
    }
}
