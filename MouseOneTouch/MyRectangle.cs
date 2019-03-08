using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace MouseOneTouch
{
    class MyRectangle
    {
        RectangleF R { get; set; }
        Timer timer;
        float a;        

        public event EventHandler ForMove;
       
        public MyRectangle(RectangleF rectangle)
        {
            R = rectangle;
        }
        private void TimerInit()
        {
            timer = new Timer() { Interval = 100 };           
            timer.Tick += (s, e) => { Timer_Tick(s, e); };
            timer.Enabled = true;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            a = a + 0.1f;
            R = new RectangleF(R.X + 8 * (float)Math.Cos(a), R.Y + 8 * (float)Math.Sin(a), R.Width, R.Height);            
            ForMove?.Invoke(this, EventArgs.Empty);
        }        
        public void Draw(Graphics g)
        {
            Pen p = new Pen(Brushes.Goldenrod);
            p.Width = 3.0f;
            g.DrawRectangle(p, R.X, R.Y, R.Width, R.Height);
        }        
        public void Move()
        {
            TimerInit();
        }
        public bool ContainsPoint(float x, float y)
        {
            if (x > R.X && y > R.Y && x < R.X + R.Width && y < R.Y + R.Height)
                return true;
            else
                return false;
        }
    }
}
