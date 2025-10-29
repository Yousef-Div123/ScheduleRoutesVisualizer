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


        public Section(int crn, string courseCode, string department, string sectionNumber, string courseTitle, string type, string instructor, Date date, Building building)
        {
            this.crn = crn;
            this.courseCode = courseCode;
            this.department = department;
            this.sectionNumber = sectionNumber;
            this.courseTitle = courseTitle;
            this.type = type;
            this.instructor = instructor;
            this.date = date;
            this.building = building;
        }
        public Section(int crn, string courseCode, string department, string sectionNumber, string courseTitle, string type, string instructor)
        {
            this.crn = crn;
            this.courseCode = courseCode;
            this.department = department;
            this.sectionNumber = sectionNumber;
            this.courseTitle = courseTitle;
            this.type = type;
            this.instructor = instructor;
        }

        public String getDescription()
        {
            return $"{courseCode}-{sectionNumber} : {courseTitle}";
        }
    }
}
