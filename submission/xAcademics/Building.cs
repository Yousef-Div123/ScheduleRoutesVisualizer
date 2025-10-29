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
    }
}
