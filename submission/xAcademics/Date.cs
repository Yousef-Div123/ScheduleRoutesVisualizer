using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAcademics
{
    internal class Date : IComparable<Date>
    {
        private bool[] _days;
        private int _startTime;
        private int _endTime;

        public int startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public int endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public bool[] days
        {
            get { return _days; }
            set {
                if(value.Length !=5)
                {
                    throw new ArgumentException("Days array should be of lenght 5");
                }
                else
                {
                    _days = value;
                }
            }
        }

        public Date(String days, int startTime, int endTme) {
            Dictionary<char, int> daysDict = new Dictionary<char, int>
            {
                { 'U', 0 },  // Sunday
                { 'M', 1 },  // Monday
                { 'T', 2 },  // Tuesday
                { 'W', 3 },  // Wednesday
                { 'H', 4 }   // Thursday
            };
            bool[] newDays = new bool[5];
            for (int i = 0; i < days.Length; i++)
            {
                if(daysDict.ContainsKey(days[i]))
                    newDays[daysDict[days[i]]] = true;
            }

            this.startTime = startTime;
            this.endTime = endTime;
            this.days = newDays;

        }

        public int CompareTo(Date? other)
        {
            if (other == null) return 1;

            // Handle nullable start times: unspecified (null) sorts after specified times.
            if (this.startTime == null && other.startTime != null) return 1;
            if (this.startTime != null && other.startTime == null) return -1;
            if (this.startTime != null && other.startTime != null)
            {
                int startTimeComparison = this.startTime.CompareTo(other.startTime);
                if (startTimeComparison != 0) return startTimeComparison;
            }

            // If all comparisons are equal, return 0
            return 0;
        }
    }
}

