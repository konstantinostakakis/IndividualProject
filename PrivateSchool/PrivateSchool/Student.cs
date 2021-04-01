using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    class Student : Human
    {
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set { _dateOfBirth = value; }
        }

        private decimal _tuitionFees;
        public decimal TuitionFees
        {
            get { return _tuitionFees; }
            private set { _tuitionFees = value; }
        }

        private List<Assignment> _assignments;

        public Student() : base() 
        {
            _assignments = new List<Assignment>();
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees) : base(firstName, lastName)
        {
            if (dateOfBirth.CompareTo(DateTime.Now) > 0)
            {
                throw new ArgumentOutOfRangeException("dateOfBirth", "The date you have inserted has not come yet!");
            }
            DateOfBirth = dateOfBirth;
            if (tuitionFees < 0)
            {
                throw new ArgumentOutOfRangeException("tuitionFees", "Tuition fees cannot be a negative number!");
            }
            TuitionFees = tuitionFees;
            _assignments = new List<Assignment>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Student objAsStudent = obj as Student;
            if (objAsStudent == null) return false;
            else return Equals(objAsStudent);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;
            return FirstName == other.FirstName && LastName == other.LastName && 
                   DateOfBirth == other.DateOfBirth && TuitionFees == other.TuitionFees;
        }

        public override void InsertData(string identifier)
        {
            base.InsertData(identifier);
            DateTime dateOfBirth;
            Console.Write("Give the {0}'s Date Of Birth: ", identifier);
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth) || dateOfBirth.CompareTo(DateTime.Now) > 0)
            {
                Console.WriteLine("You did not give a date or the date has not come yet!!");
                Console.Write("Give the {0}'s Date Of Birth: ", identifier);
            }
            DateOfBirth = dateOfBirth;
            decimal tuitionFees;
            Console.Write("Give the {0}'s Tuition Fees: ", identifier);
            while(!decimal.TryParse(Console.ReadLine(), out tuitionFees) || tuitionFees < 0)
            {
                Console.WriteLine("You did not give a number or you gave a negative one!!");
                Console.Write("Give the {0}'s Tuition Fees: ", identifier);
            }
            TuitionFees = tuitionFees;
        }

        public override void PrintData(string identifier)
        {
            base.PrintData(identifier);
            Console.WriteLine("Date Of Birth: {0}", DateOfBirth.ToString("dd'/'MM'/'yyyy"));
            Console.WriteLine("Tuition Fees: {0}", TuitionFees.ToString("F"));
        }

        public void ListAssignments()
        {
            for (int i = 0; i < _assignments.Count; i++)
            {
                Console.Write("{0}.", i + 1);
                _assignments[i].PrintData();
                Console.WriteLine();
            }
        }

        public void AddAssignment(Assignment assignment)
        {
            _assignments.Add(assignment);
        }

        public void InsertAssignment(int index, Assignment assignment) 
        {
            if (index < 0 || index > _assignments.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or greater than size of the list.");
            }
            _assignments.Insert(index, assignment);
        }

        public void RemoveAssignment(Assignment assignment)
        {
            _assignments.Remove(assignment);
        }

        public int GetAssignmentsListSize()
        {
            return _assignments.Count;
        }

        public Assignment GetAssignmentFromList(int index)
        {
            if (index < 0 || index >= _assignments.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or equal/greater than size of the list.");
            }
            return _assignments[index];
        }

        public bool AssignmentsListContains(Assignment assignment)
        {
            return _assignments.Contains(assignment);
        }
    }
}
