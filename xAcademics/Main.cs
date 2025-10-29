using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace xAcademics
{
    public partial class Main : Form
    {
        private Dictionary<int, Section> sections;
        private ExcelReader reader;
        private Schedule schedule;
        private int _selectedDay;


        public int selectedDay
        {
            get { return _selectedDay; }
            set
            {
                if (value < 0 || value > 4)
                {
                    throw new ArgumentOutOfRangeException("selectedDay", "Day must be between 0 and 4");
                }
                _selectedDay = value;
                handleSubmit();

            }
        }
        public Main()
        {
            this.reader = new ExcelReader("Term Schedule 251.xlsx");
            this.sections = reader.loadSections();
            this.schedule = Schedule.getInstance();
            InitializeComponent();
            this.selectedDay = 0;
        }

        private static List<int> parseCRNsFromText(string inputText)
        {
            List<int> crns = new List<int>();

            if (string.IsNullOrWhiteSpace(inputText))
                return crns;

            string[] parts = inputText.Split(new char[] { ' ' },
                                                StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string cleanPart = part.Trim();

                if (cleanPart.Length == 5 &&
                    int.TryParse(cleanPart, out int crn) &&
                    crn >= 10000 && crn <= 99999) // Ensures 5-digit number
                {
                    crns.Add(crn);
                }
                else
                {
                    throw new FormatException($"Invalid CRN format: '{cleanPart}'");
                }

            }

            return crns;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            handleSubmit();
            drawRoutes(e);
        }
        private void handleSubmit() {
            try
            {
                List<int> crnList = parseCRNsFromText(textBox1.Text);
                crnList = crnList.ToHashSet().ToList();

                this.schedule.clearSections();

                for (int i = 0; i < crnList.Count; i++)
                {
                    int crn = crnList[i];

                    if (!sections.ContainsKey(crn))
                    {
                        throw new FormatException($"CRN not found: '{crn}'");
                    }
                    Section section = sections[crn];
                    this.schedule.addSection(section);

                }

                details.Text = schedule.getDescription(selectedDay);
            }
            catch (FormatException fe)
            {
                details.Text = fe.Message;
                return;
            }
        }

        private void drawRoutes(EventArgs e)
        {
            pictureBox1.Refresh();
            // To be implemented
            foreach (Route route in schedule.getDayRoutes(selectedDay))
            {
                drawArrow(route, e);
            }
        }
        private void DrawArrowHead(Graphics g, Pen arrowPen, Point startPoint, Point endPoint)
        {
            float arrowSize = 15; // Size of arrow head
            float lineThickness = arrowPen.Width;

            // Calculate the angle of the line
            float angle = (float)Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);

            // Create arrow head points
            PointF[] arrowPoints = new PointF[3];

            // Arrow tip at end point
            arrowPoints[0] = endPoint;

            // Calculate the two base points of the arrow head
            arrowPoints[1] = new PointF(
                endPoint.X - arrowSize * (float)Math.Cos(angle - Math.PI / 6),
                endPoint.Y - arrowSize * (float)Math.Sin(angle - Math.PI / 6)
            );

            arrowPoints[2] = new PointF(
                endPoint.X - arrowSize * (float)Math.Cos(angle + Math.PI / 6),
                endPoint.Y - arrowSize * (float)Math.Sin(angle + Math.PI / 6)
            );

            // Fill the arrow head
            using (Brush arrowBrush = new SolidBrush(arrowPen.Color))
            {
                g.FillPolygon(arrowBrush, arrowPoints);
            }

            // Optionally draw the outline
            g.DrawPolygon(arrowPen, arrowPoints);
        }

        private void drawArrow(Route route, EventArgs e)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();

                Pen greenPen = new Pen(Color.Green, 4); // 4 pixels thick - adjust as needed

                Point p1 = new Point((int)route.startBuilding.x, (int)route.startBuilding.y);
                Point p2 = new Point((int)route.endBuilding.x, (int)route.endBuilding.y); 

                // Draw the main line
                g.DrawLine(greenPen, p1, p2);

                // Draw arrow head at the end point
                DrawArrowHead(g, greenPen, p1, p2);

                // Clean up resources
                greenPen.Dispose();
                g.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message); // Better to show Message than StackTrace
            }
        }


        private void dayBtnCLick(object sender, EventArgs e)
        {
            Dictionary<string, int> daysDict = new Dictionary<string, int>
            {
                { "U", 0 },  // Sunday
                { "M", 1 },  // Monday
                { "T", 2 },  // Tuesday
                { "W", 3 },  // Wednesday
                { "R", 4 }   // Thursday
            };
            selectedDay = daysDict[(sender as Button).Text];
            drawRoutes(e);
        }
    }
}
