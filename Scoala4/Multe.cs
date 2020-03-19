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
    class Multe : Control
    {
        Task task1, task2, task3, task4, task5;
        Random random;
        Coada coada;
        Panel panel;
        Label label;
        Avion avion, avion2;
        Button button1, button2;
        bool stays;
        int interval1, interval2, interval3, interval4;
        private delegate void delegate2();
        private delegate bool delegate5();

        public Multe(Coada cozi, Avion avioane, Panel panele, Button butoane1, Button butoane2, Label labele)
        {
            label = labele;
            button1 = butoane1;
            button2 = butoane2;
            this.CreateHandle();
            coada = cozi;
            avion = avioane;
            panel = panele;
            random = new Random();
            task1 = new Task(F1);
            task2 = new Task(F2);
            task3 = new Task(F3);
            task4 = new Task(F4);
            task5 = new Task(F5);
        }

        public void Start()
        {
            stays = true;
            interval1 = 500;
            task1.Start();
            interval2 = 20;
            task2.Start();
            interval3 = 500;
            task3.Start();
            interval4 = 50;
            task4.Start();
            task5.Start();
        }
        private void ascunde()
        {
            if (button1.InvokeRequired)
            {
                var d = new delegate2(ascunde);
                Invoke(d);
            }
            else
            {
                button1.Show();
                button2.Hide();
            }
        }
        private delegate void StopDelegate();
        public void Stop()
        {
            if (panel.InvokeRequired)
            {
                var d = new StopDelegate(Stop);
                Invoke(d);
            }
            else
            {
                Panel replacement = new Panel();
                replacement.SetBounds(avion.DaForma()[0].Location.X, avion.DaForma()[1].Location.Y, 30, 20);
                replacement.BackColor = Color.Blue;
                replacement.Parent = panel;
                avion.Scapa();
                stays = false;
                task1.Wait();
                task2.Wait();
                task3.Wait();
                ascunde();
                while (coada.DaPrim() != null)
                    coada.Pop();
                replacement.Dispose();
            }
        }

        void F1()
        {
            while (stays)
            {
                coada.Add(panel, 600, random.Next() % 628 - 100);
                System.Threading.Thread.Sleep(interval1);
            }
        }
        void f2()
        {
            try
            {
                if(coada.InvokeRequired)
                {
                    var d = new delegate2(f2);
                    Invoke(d);
                }
                else
                {
                    foreach (Control da in coada.DaPiese())
                    {
                        da.SetBounds(da.Location.X - 1, da.Location.Y, da.Width, da.Height);
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }
        void F2()
        {
            while (stays)
            {
                f2();
                System.Threading.Thread.Sleep(interval2);
            }
        }
        private delegate void Scorul();
        void f3()
        {
            if (label.InvokeRequired)
            {
                var d = new Scorul(f3);
                Invoke(d);
            }
            else
            {
                int scor = int.Parse(label.Text);
                scor++;
                label.Text = scor.ToString();
            }
        }
        void F3()
        {
            while (stays)
            {
                try
                {
                    while (coada.DaPrim().Bounds.Location.X < -22)
                    { coada.Pop(); f3(); }
                }
                catch (NullReferenceException)
                {

                }
                System.Threading.Thread.Sleep(interval3);
            }
        }
        void f4()
        {
            try
            {
                foreach (Control a in coada.DaPiese())
                {
                    foreach (Control b in avion.DaForma())
                    {
                        if (a.Bounds.IntersectsWith(b.Bounds))
                        {
                            Stop();
                            return;
                        }
                    }
                }
            }
            catch(NullReferenceException)
            { }
        }
        void F4()
        {
            while (stays)
            {
                f4();
                System.Threading.Thread.Sleep(interval4);
            }
        }
        bool f5()
        {
            if (this.InvokeRequired)
            {
                var d = new delegate5(f5);
                return (bool) Invoke(d);
            }
            else
            {
                if (interval1 < 300)
                    return false;
                interval1 -= 10;
                return true;
            }
        }
        bool f52()
        {
            if (this.InvokeRequired)
            {
                var d = new delegate5(f52);
                return (bool)Invoke(d);
            }
            else
            {
                if (interval2 < 9)
                    return false;
                interval2 -= 1;
                return true;
            }
        }
        void F5()
        {
            while (stays && f5())
            {
                System.Threading.Thread.Sleep(1000);
            }
            while (stays && f52())
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
