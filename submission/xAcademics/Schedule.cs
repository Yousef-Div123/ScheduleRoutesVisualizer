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
        private List<Route> _routes;

        public List<Section> sections
        {
            get { return _sections; }
            set { _sections = value; }
        }

        public List<Route> routes
        {
            get { return _routes; }
            private set { _routes = value; }
        }

        public Schedule()
        {
            this.sections = new List<Section>();
            this.routes = new List<Route>();
        }

        public void addSection(Section section)
        {
            this.sections.Add(section);
            this.calculateRoutes();
        }
        public void calculateRoutes()
        {
            routes = new List<Route>();

            if (sections == null || sections.Count < 2)
                return;

            // Get valid sections with non-null buildings AND non-null dates
            var validSections = sections
                .Where(s => s.building != null && s.date != null)
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

                routes.Add(new Route(
                    currentSection.building,
                    nextSection.building)
                );
            }
        }

        public String getDescription()
        {
            String result = $"Number of Courses: {sections.Count}\n";
            for (int i = 0; i < sections.Count -1;)
            {
                result += $"{i + 1} - {sections[i].getDescription()}\n";
            }

            result += $"Total Distance: {Route.totalDistance(routes)}"; 

            return result;
        }

    }
}
