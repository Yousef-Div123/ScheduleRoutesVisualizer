using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAcademics
{
    internal class Route
    {
        private Building _startBuilding;
        private Building _endBuilding;
        public Building startBuilding
        {
            get { return _startBuilding; }
            set { _startBuilding = value; }
        }
        public Building endBuilding
        {
            get { return _endBuilding; }
            set { _endBuilding = value; }
        }
        public Route(Building startBuilding, Building endBuilding)
        {
            this.startBuilding = startBuilding;
            this.endBuilding = endBuilding;
        }

        public float caculateDistance()
        {
            float deltaX = endBuilding.x - startBuilding.x;
            float deltaY = endBuilding.y - startBuilding.y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static float totalDistance(List<Route> routes)
        {
            float total = 0;
            foreach (Route route in routes)
            {
                total += route.caculateDistance();
            }
            return total;
        }

    }
}
