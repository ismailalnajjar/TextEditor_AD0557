using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor_AD0557
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }

        private void fontDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FD.ShowDialog() == DialogResult.OK)
            { 
            txt1.Font=FD.Font;
                txtName.Font=FD.Font;
                txtAge.Font = FD.Font;
            }
            

        }

        private void colerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            TextBox txt = this.ActiveControl as TextBox;
            if (txt.SelectedText!=String.Empty)
             Clipboard.SetData(DataFormats.Text,txt.SelectedText);
            txt.SelectedText = String.Empty;
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox txt = this.ActiveControl as TextBox;
            if (txt.SelectedText != String.Empty)
                Clipboard.SetData(DataFormats.Text, txt.SelectedText);
           

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int position = ((TextBox)this.ActiveControl).SelectionStart;
            this.ActiveControl.Text = this.ActiveControl.Text.Insert(position, Clipboard.GetText()); 
        }

        private void frm_Load(object sender, EventArgs e)
        {

        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void textColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Color color = CD.Color;

                txt1.ForeColor = color;
                txtName.ForeColor = color;
                txtAge.ForeColor = color;

            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CD.ShowDialog() == DialogResult.OK)
            {
                Color color = CD.Color;
                pnl.BackColor = color;


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter SW=new StreamWriter(Application.StartupPath + 
                "\\Text\\" + "Ismail.txt");
            SW.WriteLine(lblTake.Text + " : " + txt1.Text);
            SW.WriteLine(lblName.Text + " : " + txtName.Text);
            SW.WriteLine(lblAge.Text + " : " + txtAge.Text);
            SW.Close();
            MessageBox.Show("Saved successfully");
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream St;
            OpenFileDialog D = new OpenFileDialog();
            if(D.ShowDialog() == DialogResult.OK)
            {
                if((St = D.OpenFile()) != null)
                {
                    string file = D.FileName;
                    string st = File.ReadAllText(file);
                    txt1.Text = st;

                }
            }

        }

        private void saveTheFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter(Application.StartupPath +
               "\\Text\\" + "Ismail.txt");
            SW.WriteLine(lblTake.Text + " : " + txt1.Text);
            SW.WriteLine(lblName.Text + " : " + txtName.Text);
            SW.WriteLine(lblAge.Text + " : " + txtAge.Text);
            SW.Close();
            MessageBox.Show("Saved successfully");
        }
    }
}
