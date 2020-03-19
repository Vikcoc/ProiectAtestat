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
    class Avion : Control
    {
        private delegate void SafeDellDelegate();
        private delegate void SafeDelvDelegate();
        Control[] forma;
        public void Scapa()
        {
            try
            {
                foreach (Control e in forma)
                {
                    e.Dispose();
                }
            }
            catch (InvalidOperationException)
            {
                var d = new SafeDellDelegate(Scapa);
                Invoke(d);
            }
        }
        public Avion(Control tata)
        {
            CreateControl();
            forma = new Control[3];
            forma[0] = new Control();
            forma[0].SetBounds(10, 230, 30, 10);
            forma[1] = new Control();
            forma[1].SetBounds(20, 225, 15, 5);
            forma[2] = new Control();
            forma[2].SetBounds(20, 240, 15, 5);
            forma[0].BackColor = Color.Blue;
            forma[1].BackColor = Color.Blue;
            forma[2].BackColor = Color.Blue;
            forma[0].Parent = tata;
            forma[1].Parent = tata;
            forma[2].Parent = tata;
        }
        public void Pleaca()
        {
            if (forma[0].InvokeRequired)
            {
                var d = new SafeDellDelegate(Pleaca);
                Invoke(d);
            }
            else
            {
                foreach (Control a in forma)
                {
                    a.Dispose();
                }
                forma = null;
            }
        }
        public void Coboara()
        {
            if (forma[0].Location.Y < 435)
            {
                foreach (Control a in forma)
                {
                    a.SetBounds(a.Location.X, a.Location.Y + 5, a.Width, a.Height);
                }
            }
        }
        public void Urca()
        {
            if (forma[0].Location.Y > 5)
            {
                foreach (Control a in forma)
                {
                    a.SetBounds(a.Location.X, a.Location.Y - 5, a.Width, a.Height);
                }
            }
        }
        public void Stanga()
        {
            if (forma[0].Location.X > 0)
            {
                foreach (Control a in forma)
                {
                    a.SetBounds(a.Location.X - 5, a.Location.Y, a.Width, a.Height);
                }
            }
        }
        public void Dreapta()
        {
            if (forma[0].Location.X < 570)
            {
                foreach (Control a in forma)
                {
                    a.SetBounds(a.Location.X + 5, a.Location.Y, a.Width, a.Height);
                }
            }
        }
        public Control[] DaForma()
        {
            return forma;
        }
    }
}

