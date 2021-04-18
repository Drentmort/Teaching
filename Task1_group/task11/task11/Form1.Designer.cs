using System.Windows.Forms;

namespace task11
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            task11.RectanDrawer rectanDrawer1 = new task11.RectanDrawer();
            task11.EllipseDrawer ellipseDrawer1 = new task11.EllipseDrawer();
            task11.PolylineDrawer polylineDrawer1 = new task11.PolylineDrawer();
            task11.BeziersDrawer beziersDrawer1 = new task11.BeziersDrawer();
            task11.Fundamental0Drawer fundamental0Drawer1 = new task11.Fundamental0Drawer();
            task11.Fundamental1Drawer fundamental1Drawer1 = new task11.Fundamental1Drawer();
            task11.Fundamental3Drawer fundamental3Drawer1 = new task11.Fundamental3Drawer();
            task11.PolygonDrawer polygonDrawer1 = new task11.PolygonDrawer();
            task11.CloseCurveDrawer closeCurveDrawer1 = new task11.CloseCurveDrawer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.figureCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.isFill = new System.Windows.Forms.CheckBox();
            this.brushCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.colorCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 269);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += Panel1_Paint;
            // 
            // figureCheckedListBox
            // 
            this.figureCheckedListBox.CheckOnClick = true;
            this.figureCheckedListBox.FormattingEnabled = true;
            this.figureCheckedListBox.Items.AddRange(new object[] {
            rectanDrawer1,
            ellipseDrawer1,
            polylineDrawer1,
            beziersDrawer1,
            fundamental0Drawer1,
            fundamental1Drawer1,
            fundamental3Drawer1,
            polygonDrawer1,
            closeCurveDrawer1});
            this.figureCheckedListBox.Location = new System.Drawing.Point(525, 12);
            this.figureCheckedListBox.Name = "figureCheckedListBox";
            this.figureCheckedListBox.Size = new System.Drawing.Size(173, 184);
            this.figureCheckedListBox.TabIndex = 0;
            this.figureCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.figureCheckedListBox_SelectedIndexChanged);
            // 
            // isFill
            // 
            this.isFill.AutoSize = true;
            this.isFill.Location = new System.Drawing.Point(525, 222);
            this.isFill.Name = "isFill";
            this.isFill.Size = new System.Drawing.Size(69, 17);
            this.isFill.TabIndex = 2;
            this.isFill.Text = "Заливка";
            this.isFill.UseVisualStyleBackColor = true;
            this.isFill.CheckedChanged += new System.EventHandler(IsFill_CheckedChanged);
            // 
            // brushCheckedListBox
            // 
            this.brushCheckedListBox.FormattingEnabled = true;
            this.brushCheckedListBox.Items.AddRange(new object[] {
            "Сплошная заливка",
            "Градиент"});
            this.brushCheckedListBox.Location = new System.Drawing.Point(525, 245);
            this.brushCheckedListBox.Name = "brushCheckedListBox";
            this.brushCheckedListBox.Size = new System.Drawing.Size(120, 94);
            this.brushCheckedListBox.TabIndex = 3;
            this.brushCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.BrushCheckedListBox_SelectedIndexChanged);
            // 
            // colorCheckedListBox
            // 
            this.colorCheckedListBox.FormattingEnabled = true;
            this.colorCheckedListBox.Items.AddRange(new object[] {
            "Красный",
            "Оранжевый",
            "Желтый",
            "Зеленый",
            "Голубой",
            "Синий",
            "Фиолетовый"});
            this.colorCheckedListBox.Location = new System.Drawing.Point(12, 275);
            this.colorCheckedListBox.Name = "colorCheckedListBox";
            this.colorCheckedListBox.Size = new System.Drawing.Size(117, 94);
            this.colorCheckedListBox.TabIndex = 4;
            this.colorCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.ColorCheckedListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.colorCheckedListBox);
            this.Controls.Add(this.brushCheckedListBox);
            this.Controls.Add(this.isFill);
            this.Controls.Add(this.figureCheckedListBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Task11";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel1;
        private CheckedListBox figureCheckedListBox;
        private CheckBox isFill;
        private CheckedListBox brushCheckedListBox;
        private CheckedListBox colorCheckedListBox;
    }


}

