using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace xAcademics
{
    public partial class Form1 : Form
    {
        private ArrayList sections;
        private ExcelReader reader;

        public Form1()
        {  
            reader = new ExcelReader();
            sections = reader.loadData();
            InitializeComponent();
        }

        //private void DrawBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Graphics g = DrawingPanel.CreateGraphics();
        //        Color timeLineColor = Color.Black;
        //        Brush timeLineBrush = new SolidBrush(timeLineColor);
        //        Pen timeLinePen = new Pen(timeLineColor);

        //        Pen GreenPen = new Pen(Color.Green);
        //        Brush txtBrush = new SolidBrush(Color.Black);

        //        Point p1 = new Point(20, 20);
        //        Point p2 = new Point(200, 200);
        //        g.DrawLine(GreenPen, p1, p2); // ██████████████████████████████

        //        StringFormat sf = new StringFormat
        //        {
        //            LineAlignment = StringAlignment.Center,
        //            Alignment = StringAlignment.Center
        //        };
        //        g.DrawString("Sample Text", DrawBtn.Font, txtBrush, p2, sf); // ██████████████████████████████

        //        g.FillRectangle(txtBrush, 30, 300, 300, 10); // ██████████████████████████████
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.StackTrace);
        //    }
        //}




        private void dayBtnCLick(object sender, EventArgs e)
        {
            details.Text = (sender as Button).Text;
        }

    }
}
