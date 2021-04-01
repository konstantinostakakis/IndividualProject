using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    enum StreamValue { CSharp, Java }
    enum TypeValue { Full_Time, Part_Time }
    class Course
    {
        

        private string _title;
        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }

        private StreamValue _stream;
        public StreamValue Stream
        {
            get { return _stream; }
            private set { _stream = value; }
        }

        private TypeValue _type;
        public TypeValue Type
        {
            get { return _type; }
            private set { _type = value; }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            private set { _startDate = value; }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            private set { _endDate = value; }
        }

        private List<Trainer> _trainers;
        private List<Student> _students;
        private List<Assignment> _assignments;

        public Course()
        {
            _trainers = new List<Trainer>();
            _students = new List<Student>();
            _assignments = new List<Assignment>();
        }

        public Course(string title, StreamValue stream, TypeValue type, DateTime startDate, DateTime endDate)
        {
            if (String.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title", "Course's title cannot be null or empty!");
            }
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            _trainers = new List<Trainer>();
            _students = new List<Student>();
            _assignments = new List<Assignment>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Course objAsCourse = obj as Course;
            if (objAsCourse == null) return false;
            else return Equals(objAsCourse);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Course other)
        {
            if (other == null) return false;
            return Title == other.Title && Stream == other.Stream && Type == other.Type && 
                    StartDate == other.StartDate && EndDate == other.EndDate; 
        }

        public void InsertData()
        {
            string input;
            do
            {
                Console.Write("Give the Course's Title: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Courses's title cannot be empty");
                }
                else
                {
                    Title = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Course's Stream. Type 1 for C# or 2 for Java: ");
                input = Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine("Wrong choice!");
                }
                else if (input == "1")
                {
                    Stream = StreamValue.CSharp;
                    break;
                }
                else
                {
                    Stream = StreamValue.Java;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Course's Type. Type 1 for Full-Time or 2 for Part-Time: ");
                input = Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine("Wrong choice!");
                }
                else if (input == "1")
                {
                    Type = TypeValue.Full_Time;
                    break;
                }
                else
                {
                    Type = TypeValue.Part_Time;
                    break;
                }
            } while (true);
            DateTime startDate;
            Console.Write("Give the Course's Start Date: ");
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("You did not give a date!!");
                Console.Write("Give the Course's Start Date: ");
            }
            StartDate = startDate;
            DateTime endDate;
            Console.Write("Give the Course's End Date: ");
            while (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate.CompareTo(StartDate) <= 0)
            {
                Console.WriteLine("You did not give a date or you gave a date earlier than or equal to the starting date of the course!!");
                Console.Write("Give the Course's End Date: ");
            }
            EndDate = endDate;
        }

        public void PrintData()
        {
            Console.WriteLine("The Course's info can be seen below:");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Stream: {0}", Stream == StreamValue.CSharp ? "C#" : "Java");
            Console.WriteLine("Type: {0}", Type == TypeValue.Full_Time ? "Full-Time" : "Part-Time");
            Console.WriteLine("Start Date: {0}", StartDate.ToString("dd'/'MM'/'yyyy"));
            Console.WriteLine("End Date: {0}", EndDate.ToString("dd'/'MM'/'yyyy"));
        }

        public void ListTrainers()
        {
            for (int i = 0; i < _trainers.Count; i++)
            {
                Console.Write("{0}.", i + 1);
                _trainers[i].PrintData("Trainer");
                Console.WriteLine();
            }
        }
        public void AddTrainer(Trainer trainer)
        {
            _trainers.Add(trainer);
        }

        public bool TrainersListContains(Trainer trainer)
        {
            return _trainers.Contains(trainer);
        }

        public int GetTrainersListSize()
        {
            return _trainers.Count;
        }
        public void ListStudents()
        {
            for (int i = 0; i < _students.Count; i++)
            {
                Console.Write("{0}.", i + 1);
                _students[i].PrintData("Student");
                Console.WriteLine();
            }
        }
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public bool StudentsListContains(Student student)
        {
            return _students.Contains(student);
        }

        public int GetStudentsListSize()
        {
            return _students.Count;
        }

        public Student GetStudentFromList(int index)
        {
            if (index < 0 || index >= _students.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or equal/greater than size of the list.");
            }
            return _students[index];
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
        public Assignment GetAssignmentFromList(int index)
        {
            if (index < 0 || index >= _assignments.Count)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative or equal/greater than size of the list.");
            }
            return _assignments[index];
        }
        public int GetAssignmentsListSize()
        {
            return _assignments.Count;
        }
        public bool AssignmentsListContains(Assignment assignment)
        {
            return _assignments.Contains(assignment);
        }
    }
}
