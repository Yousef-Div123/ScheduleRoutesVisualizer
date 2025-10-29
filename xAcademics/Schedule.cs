using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace xAcademics
{
    internal class Schedule
    {
        private List<Section> _sections;
        private List<List<Route>> _routes;
        private static Schedule _instance;

        public List<Section> sections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public List<List<Route>> routes
        {
            get { return _routes; }
            private set { _routes = value; }
        }

        public static Schedule getInstance()
        {
            if (_instance == null)
            {
                _instance = new Schedule();
            }
            return _instance;
        }

        private Schedule()
        {
            sections = new List<Section>();
            routes = new List<List<Route>>(){
                new List<Route>(), // Index 0
                new List<Route>(), // Index 1
                new List<Route>(), // Index 2
                new List<Route>(), // Index 3
                new List<Route>()  // Index 4
            };
        }

        public void addSection(Section section)
        {
            this.sections.Add(section);
            this.calculateRoutes();
        }

        public void clearSections()
        {
            this.sections.Clear();
            for(int i = 0; i<5; i++)
            {
                this.routes[i].Clear();
            }
        }

        private void calculateRoutes()
        {
            // Calculate routes for each day of the week (0 to 4)
            for (int day = 0; day < 5; day++)
            {
                calculateRoutesDay(day);
            }
        }
        private void calculateRoutesDay(int day)
        {
            routes[day] = new List<Route>();

            if (sections == null || sections.Count < 2)
                return;

            // Get valid sections with non-null buildings AND non-null dates
            var validSections = sections
                .Where(s => s.building != null && s.date != null && s.date.days[day])
                .ToList();

            // Order sections by their date/time
            validSections = validSections.OrderBy(s => s.date).ToList();

            // Create routes between consecutive valid sections with different buildings
            for (int i = 0; i < validSections.Count - 1; i++)
            {
                var currentSection = validSections[i];
                var nextSection = validSections[i + 1];

                // Skip if buildings are the same
                if (currentSection.building.name == nextSection.building.name)
                    continue;

                routes[day].Add(new Route(
                    currentSection.building,
                    nextSection.building)
                );
            }
        }

        public List<Route> getDayRoutes(int day)
        {
            if (day < 0 || day > 4)
            {
                throw new ArgumentOutOfRangeException("day", "Day must be between 0 and 4");
            }
            return routes[day];
        }

        public String getDescription(int day)
        {
            String result = $"Number of Courses: {sections.Count}\r\n";
            int n = 1;
            for (int i = 0; i < sections.Count;i++)
            {
                if (sections[i].date != null&& sections[i].date.days[day])
                {
                    result += $"{n} - {sections[i].getDescription()}\r\n";
                    n++;
                }
            }

            result += $"Total Distance: {Route.totalDistance(routes[day])} m"; 

            return result;
        }

    }
}
