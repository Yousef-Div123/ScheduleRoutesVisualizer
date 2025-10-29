using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAcademics
{
    internal class Building
    {
        private String _name;
        private float _x;
        private float _y;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float x
        {
            get { return _x; }
            set { _x = value; }
        }
        public float y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Building(String name, float x, float y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public static Dictionary<string, Building> loadBuildings()
        {
            Dictionary<string, Building> buildingDict = new Dictionary<string, Building>
            {
                { "22", new Building("22", 404, 354) },
                { "24", new Building("24", 424, 415) },
                { "7", new Building("7", 267, 242) },
                { "5", new Building("5", 232, 161) },
                { "63", new Building("63", 148, 37) },
                { "59", new Building("59", 335, 196) },
                { "4", new Building("4", 205, 132) },
                { "6", new Building("6", 270, 206) },
                { "42", new Building("42", 517, 36) },
                { "76", new Building("76", 472, 371) },
                { "28", new Building("28", 577, 370) },
                { "9", new Building("9", 321, 299) },
                { "57", new Building("57", 555, 3) },
                { "58", new Building("58", 555, 3) },
                { "78", new Building("78", 522, 331) },
                { "3", new Building("3", 162, 121) },
                { "DTV248", new Building("DTV248", 66, 397) },
                { "1", new Building("1", 117, 141) },
                { "75", new Building("75", 137, 85) },
                { "39", new Building("39", 370, 73) },
                { "407", new Building("407", 429, 14) },
                { "11", new Building("11", 368, 392) }

            };
            return buildingDict;
        }
    }
}
