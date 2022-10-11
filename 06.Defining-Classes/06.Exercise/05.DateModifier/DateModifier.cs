using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(string dateOne, string dateTwo)
        {
            DateOne = dateOne;
            DateTwo = dateTwo;
        }
        private string dateOne;

        public string DateOne
        {
            get { return dateOne; }
            set { dateOne = value; }
        }
        private string dateTwo;

        public string DateTwo
        {
            get { return dateTwo; }
            set { dateTwo = value; }
        }

        public string DaysCalc()
        {
            var days = DateTime.Parse(dateTwo) - DateTime.Parse(dateOne);
            return Math.Abs(days.TotalDays).ToString();
        }
    }
}
