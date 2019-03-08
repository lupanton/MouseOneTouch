using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseOneTouch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            MyRectangle rect = new MyRectangle(new Rectangle(108, 40, 50, 50));
            rect.ForMove += (s, e) => { Refresh(); };            
            Paint += (s, e) => { rect.Draw(e.Graphics); };            
            MouseClick += (s, e) =>
            {
                if (rect.ContainsPoint(e.X, e.Y))
                    rect.Move();
            };
        }
    }
}
