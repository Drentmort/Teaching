using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace task11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                foreach(Drawer d in figureCheckedListBox.SelectedItems)
                {
                    d.Draw(g);
                }
            }
        }

        private void figureCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
            var list = sender as CheckedListBox;
            foreach (int index in list.CheckedIndices)
            {
                figureCheckedListBox.SetItemChecked(index, false);
            }
            figureCheckedListBox.SetItemChecked(list.SelectedIndex, true);

        }

        private void BrushCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = sender as CheckedListBox;
            foreach (int index in list.CheckedIndices)
            {
                brushCheckedListBox.SetItemChecked(index, false);
            }
            brushCheckedListBox.SetItemChecked(list.SelectedIndex, true);

            switch (list.SelectedIndex)
            {
                case 0:
                    Gr.brush = new SolidBrush(Gr.color);
                    break;
                case 1:
                    int newR = Gr.color.R + 50 >= 255 ? 255 : Gr.color.R + 50;
                    int newG = Gr.color.G + 50 >= 255 ? 255 : Gr.color.G + 50;
                    int newB = Gr.color.B + 50 >= 255 ? 255 : Gr.color.B + 50;

                    Gr.brush = new LinearGradientBrush(new Point(30, 30), new Point(200, 200), Gr.color, 
                        Color.FromArgb(newR, newG, newB));
                    break;
            }
            panel1.Invalidate();
        }

        private void ColorCheckedListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var list = sender as CheckedListBox;
            foreach (int index in list.CheckedIndices)
            {
                colorCheckedListBox.SetItemChecked(index, false);
            }
            colorCheckedListBox.SetItemChecked(list.SelectedIndex, true);

            switch (list.SelectedIndex)
            {
                case 0:
                    Gr.color = Color.Red;
                    break;
                case 1:
                    Gr.color = Color.Orange;
                    break;
                case 2:
                    Gr.color = Color.Yellow;
                    break;
                case 3:
                    Gr.color = Color.Green;
                    break;
                case 4:
                    Gr.color = Color.Blue;
                    break;
                case 5:
                    Gr.color = Color.Cyan;
                    break;
                case 6:
                    Gr.color = Color.Violet;
                    break;
                    
            }
            Gr.brush = new SolidBrush(Gr.color);
            foreach (int index in brushCheckedListBox.CheckedIndices)
            {
                brushCheckedListBox.SetItemChecked(index, false);
            }
            brushCheckedListBox.SetItemChecked(0, true);
            panel1.Invalidate();
        }

        private void IsFill_CheckedChanged(object sender, EventArgs e)
        {
            Gr.isFilled = isFill.Checked;
            if (isFill.Checked) {
                brushCheckedListBox.SetItemChecked(0, true);
                Gr.brush = new SolidBrush(Gr.color);
            }
                
            else
                foreach (int index in brushCheckedListBox.CheckedIndices)
                {
                    brushCheckedListBox.SetItemChecked(index, false);
                }

            panel1.Invalidate();
        }

    }

    class Gr
    {
        public static Pen pen = new Pen(Color.Black);
        public static bool isFilled = false;
        public static Color color = Color.BlueViolet;
        public static Brush brush;
    }


    abstract class Drawer
    {
        public abstract void Draw(Graphics g);
    }

    class RectanDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Gr.pen = new Pen(Color.Black);
            g.DrawRectangle(Gr.pen, 30, 30, 400, 200);
            if (Gr.isFilled)
            {
                g.FillRectangle(Gr.brush, 31, 31, 399, 199);
            }

        }

        public override string ToString()
        {
            return "Прямоугольник";
        }
    }

    class EllipseDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Gr.pen, 30, 30, 400, 200);
            if (Gr.isFilled)
            {
                g.FillEllipse(Gr.brush, 31, 31, 399, 199);
            }
        }

        public override string ToString()
        {
            return "Эллипс";
        }
    }

    class PolylineDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(new Point() { X = 30, Y = 30 }, new Point() { X = 60, Y = 90 });
            gp.AddLine(new Point() { X = 160, Y = 230 }, new Point() { X = 190, Y = 150 });
            gp.AddLine(new Point() { X = 210, Y = 230 }, new Point() { X = 350, Y = 120 });

            if (Gr.isFilled)
            {
                gp.CloseFigure();
                Region r = new Region(gp);
                g.FillRegion(Gr.brush,r);
                return;
            }
            g.DrawPath(Gr.pen, gp);
        }

        public override string ToString()
        {
            return "Ломаная";
        }
    }

    class BeziersDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            GraphicsPath gp = new GraphicsPath();
            gp.AddBeziers(p);

            if (Gr.isFilled)
            {
                gp.CloseFigure();
                Region r = new Region(gp);
                g.FillRegion(Gr.brush, r);
                return;
            }
            g.DrawPath(Gr.pen, gp);
        }

        public override string ToString()
        {
            return "Кривая Безье";
        }
    }

    class Fundamental0Drawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            GraphicsPath gp = new GraphicsPath();
            gp.AddCurve(p,0);

            if (Gr.isFilled)
            {
                gp.CloseFigure();
                Region r = new Region(gp);
                g.FillRegion(Gr.brush, r);
                return;
            }
            g.DrawPath(Gr.pen, gp);
        }

        public override string ToString()
        {
            return "Фунд. кривая, нат. 0";
        }
    }

    class Fundamental1Drawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            GraphicsPath gp = new GraphicsPath();
            gp.AddCurve(p, 1);

            if (Gr.isFilled)
            {
                gp.CloseFigure();
                Region r = new Region(gp);
                g.FillRegion(Gr.brush, r);
                return;
            }
            g.DrawPath(Gr.pen, gp);
        }

        public override string ToString()
        {
            return "Фунд. кривая, нат. 1";
        }
    }

    class Fundamental3Drawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            GraphicsPath gp = new GraphicsPath();
            gp.AddCurve(p, 3);

            if (Gr.isFilled)
            {
                gp.CloseFigure();
                Region r = new Region(gp);
                g.FillRegion(Gr.brush, r);
                return;
            }
            g.DrawPath(Gr.pen, gp);
        }

        public override string ToString()
        {
            return "Фунд. кривая, нат. 3";
        }
    }

    class PolygonDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            g.DrawPolygon(Gr.pen, p);
        }

        public override string ToString()
        {
            return "Полигон";
        }
    }

    class CloseCurveDrawer : Drawer
    {
        public override void Draw(Graphics g)
        {
            Point[] p = {new Point() {X=30,Y=30},
                new Point() {X=60,Y=90},
                new Point() {X=160,Y=230},
                new Point() {X=190,Y=150},
                new Point() {X=210,Y=230},
                new Point() {X=350,Y=120},
                new Point() {X=430,Y=60}
            };
            g.DrawClosedCurve(Gr.pen, p);
        }

        public override string ToString()
        {
            return "Замкнутая кривая";
        }
    }
}
