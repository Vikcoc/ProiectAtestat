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
    class Coada : Control
    {
        private delegate void SafeCallDelegate(Control tata, int orizontal, int vertical);
        private delegate void SafeDellDelegate();
        class Element { public Panel panel = new Panel(); public Element next = null; }
        Element old = null, last = null;
        int number = 0;
        public Coada()
        {
            this.CreateControl();
        }
        public void Add(Control tata, int orizontal, int vertical)
        {
            if (tata.InvokeRequired)
            {
                    var d = new SafeCallDelegate(Add);
                    Invoke(d, new object[] { tata, orizontal, vertical });
            }
            else
            {

                Element aux;
                aux = new Element();
                aux.panel.SetBounds(orizontal, vertical, 22, 22);
                aux.panel.BackColor = Color.Aqua;
                aux.panel.CreateControl();
                aux.panel.Parent = tata;
                if(number==0)
                {
                    old = aux;
                    last = aux;
                }
                last.next = aux;
                last = aux;
                number++;
            }
        }
        public void Pop()
        {
            
            try
            {
                if (old.panel.InvokeRequired)
                {
                    var d = new SafeDellDelegate(Pop);
                    Invoke(d);
                }
                else
                {
                    Element aux;
                    aux = old;
                    old = old.next;
                    aux.panel.Dispose();
                    aux = null;
                    number = (number > 1) ? number - 1 : 0;
                }
            }
            catch (NullReferenceException)
            {
            }
        }
        public Control[] DaPiese()
        {
            Control[] s;
            try
            {
                int i, cnumber = number;

                s = new Control[cnumber];
                Element aux = old;
                for (i = 0; i < cnumber; i++)
                {
                    s[i] = aux.panel;
                    aux = aux.next;
                }
            }
            catch (NullReferenceException)
            {
                s = null;
            }
            return s;
        }
        public Control DaPrim()
        {
            try
            {
                return old.panel;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        public bool IsEmpty()
        {
            if (number == 0)
                return true;
            else
                return false;
        }
    }
}
