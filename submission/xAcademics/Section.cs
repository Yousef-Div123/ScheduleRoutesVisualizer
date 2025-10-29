using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAcademics
{
    internal class Section
    {
        private string _courseCode;
        private string _sectionNumber;
        private string _instructor;
        private int _crn;
        private string _type;
        private string _department;
        private string _courseTitle;
        private Date _date;
        private Building _building;

        public string courseCode
        {
            get { return _courseCode; }
            set { _courseCode = value; }
        }

        public string sectionNumber
        {
            get { return _sectionNumber; }
            set { _sectionNumber = value; }
        }

        public string instructor
        {
            get { return _instructor; }
            set { _instructor = value; }
        }

        public int crn
        {
            get { return _crn; }
            set { _crn = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string courseTitle
        {
            get { return _courseTitle; }
            set { _courseTitle = value; }
        }

        public Date date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Building building
        {
            get { return _building; }
            set { _building = value; }
        }


        public Section(string courseCode, string sectionNumber, string instructor, int crn, string type, string department, string courseTitle, Date date, Building building)
        {
            this.courseCode = courseCode;
            this.sectionNumber = sectionNumber;
            this.instructor = instructor;
            this.crn = crn;
            this.type = type;
            this.department = department;
            this.courseTitle = courseTitle;
            this.date = date;
            this.building = building;
        }

        public String getDescription()
        {
            return $"{courseCode}-{sectionNumber} : {courseTitle}";
        }
    }
}
