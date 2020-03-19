using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scoala4
{
    public partial class Form1 : Form
    {

        Timer timer;
        Multe multe;
        Avion avion;
        Coada coada;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.timer_Tick);
            button2.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            button2.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                switch (keyData)
                {
                    case Keys.Down:
                        avion.Coboara();
                        break;
                    case Keys.Up:
                        avion.Urca();
                        break;
                    case Keys.Right:
                        avion.Dreapta();
                        break;
                    case Keys.Left:
                        avion.Stanga();
                        break;
                }
            }
            catch (NullReferenceException) { }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            coada = new Coada();
            avion = new Avion(panel1);
            multe = new Multe(coada, avion, panel1, button1, button2, label2);
            multe.Start();
            button1.Hide();
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            multe.Stop();
        }

    }
}
