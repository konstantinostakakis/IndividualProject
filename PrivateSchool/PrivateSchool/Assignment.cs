using System;

namespace PrivateSchool
{
    class Assignment
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            private set { _description = value; }
        }

        private DateTime _subDateTime;
        public DateTime SubDateTime
        {
            get { return _subDateTime; }
            private set { _subDateTime = value; }
        }

        private float _oralMark;
        public float OralMark
        {
            get { return _oralMark; }
            private set { _oralMark = value; }
        }

        private float _totalMark;
        public float TotalMark
        {
            get { return _totalMark; }
            private set { _totalMark = value; }
        }

        public Assignment()
        {

        }

        public Assignment(string title, string description, DateTime subDateTime, float oralMark, float totalMark)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "The title of the assignment cannot be null or empty!");
            }
            Title = title;
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("description", "The description of the assignment cannot be null or empty!");
            }
            Description = description;
            SubDateTime = subDateTime;
            if (oralMark < 0)
            {
                throw new ArgumentOutOfRangeException("oralMark", "Oral Mark cannot be negative!");
            }
            OralMark = oralMark;
            if (TotalMark < 0)
            {
                throw new ArgumentOutOfRangeException("totalMark", "Total Mark cannot be negative!");
            }
            TotalMark = totalMark;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Assignment objAsAssignment = obj as Assignment;
            if (objAsAssignment == null) return false;
            else return Equals(objAsAssignment);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Assignment other)
        {
            if (other == null) return false;
            return Title == other.Title && Description == other.Description && SubDateTime == other.SubDateTime &&
                    OralMark == other.OralMark && TotalMark == other.TotalMark;
        }

        public void InsertData()
        {
            string input;
            do
            {
                Console.Write("Give the Assignment's Title: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Title cannot be empty");
                }
                else
                {
                    Title = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Assignment's Description: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Description cannot be empty");
                }
                else
                {
                    Description = input;
                    break;
                }
            } while (true);
            DateTime subDateTime;
            Console.Write("Give the Assignment's Submission Date & Time: ");
            while(!DateTime.TryParse(Console.ReadLine(), out subDateTime))
            {
                Console.WriteLine("You did not give date or time correctly!!");
                Console.Write("Give the Assignment's Submission Date & Time: ");
            }
            SubDateTime = subDateTime;
            float oralMark;
            Console.Write("Give the Assignment's Oral Mark: ");
            while(!float.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0)
            {
                Console.WriteLine("You did not gave a number or you gave a negative one!");
                Console.Write("Give the Assignment's Oral Mark: ");
            }
            OralMark = oralMark;
            float totalMark;
            Console.Write("Give the Assignment's Total Mark: ");
            while (!float.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0)
            {
                Console.WriteLine("You did not gave a number or you gave a negative one!");
                Console.Write("Give the Assignment's Total Mark: ");
            }
            TotalMark = totalMark;
        }

        public void PrintData()
        {
            Console.WriteLine("The Assignment's info can be seen below:");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Description: {0}", Description);
            Console.WriteLine("Submission Date & Time: {0}", SubDateTime.ToString("dd'/'MM'/'yyyy HH:mm:ss"));
            Console.WriteLine("Oral Mark: {0}", OralMark);
            Console.WriteLine("Total Mark: {0}", TotalMark);
        }
    }
}
