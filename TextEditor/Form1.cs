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

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public string fileDialogName = "";
        public string[] readText = new string[1000];
    
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = @"D:\Documents\writings\coding";
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = ("(*.txt)|");
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();
            fileDialogName = fileDialog.FileName;
            if (fileDialogName != "")
            {
                textBox1.Text = "";
                //fileSpaceBox.Text = "";
                //fileNameBlock.Text = fileDialogName;
                readText = File.ReadAllLines(fileDialogName);
                for (int i = 0; i < readText.Length; i++)
                {
                    textBox1.Text += readText[i] + "\r\n";
                }
            }
        }
        private void saveFile()
        {
            if (fileDialogName != "")
            {
                File.WriteAllText(fileDialogName, textBox1.Text);
                MessageBox.Show("Successfully Saved");
            } //else
            //{
            //    var fileDialog = new OpenFileDialog();
            //    fileDialog.InitialDirectory = @"D:\Documents\writings\coding";
            //    fileDialog.DefaultExt = "txt";
             //   fileDialog.Filter = ("(*.txt)|");
            //    fileDialog.Multiselect = false;
            //    fileDialog.ShowDialog();
           //     fileDialogName = fileDialog.FileName;
            //    File.WriteAllText(fileDialogName, textBox1.Text);
            //    MessageBox.Show("Successfully Saved");
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (fileDialogName == "")
            {
               MessageBox.Show("Did not select file first. Press File -> Open File on toolbar to select file.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (fileDialogName != "")
            {
                textBox2.Clear();
                for (int i = 0; i < textBox1.Lines.Length; i++)
                {
                    textBox2.Text += i + "\r\n";
                }
                textBox2.SelectionLength = 0;
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.ScrollToCaret();
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void openFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFile();
        }
    }
}
