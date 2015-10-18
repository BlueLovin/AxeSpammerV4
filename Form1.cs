using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AxeSpammerV4
{
    public partial class Form1 : Form
    {
        Thread SpamIt;
        int delay;
        string text;
        int l = 0;
        public Form1()
        {
            InitializeComponent();
            SpamIt = new Thread(spam);
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void assholeToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("That's gross.", "Gross");
        //}

        //private void cLICKHEREToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("ass");
        //}

        private void assholeToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("That's gross.", "Gross");
        }

        private void cLICKHEREToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("ass");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void start_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            l++;
            richTextBox1.Enabled = false;
            if(l == 1)
            {
                SpamIt.Start();
            }

            
            if(l >= 2)
            {
                SpamIt.Resume();
            }
            start.Enabled = false;
            textBox1.Enabled = false;
        }
        /// <summary>
        /// This is the good stuff right here, the main part of the app!
        /// </summary>
        private void spam()
        {
                     
        delay = Convert.ToInt32(textBox1.Text);
            while (true)
            {      
                SendKeys.SendWait(text);
                Thread.Sleep(delay);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
            start.Enabled = true;
            textBox1.Enabled = true;


            if (SpamIt.IsAlive == true)
            {
                SpamIt.Suspend();
            }
            if (SpamIt.IsAlive == false)
            {
                MessageBox.Show("Nothing to stop!", "YOU MORON",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Sure you want to quit? Stop all threads first!", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dialog == DialogResult.Yes)
            {
                if (SpamIt.IsAlive == false)
                {
                    e.Cancel = false;
                }
                if (SpamIt.IsAlive == true)
                {
                    SpamIt.Resume();
                    SpamIt.Abort();
                    e.Cancel = false;
                }
            }
            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
