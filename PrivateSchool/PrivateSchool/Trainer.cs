using System;

namespace PrivateSchool
{
    class Trainer : Human
    {
        // We define Subject/_subject as string because we suppose that it can take any value
        // If it could take specific values, an enum type could be used
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            private set { _subject = value; }
        }

        public Trainer() : base() { }

        public Trainer(string firstName, string lastName, string subject) : base(firstName, lastName)
        {
            if (String.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException("subject", "Trainer's subject cannot be null or empty!");
            }
            Subject = subject;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Trainer objAsTrainer = obj as Trainer;
            if (objAsTrainer == null) return false;
            else return Equals(objAsTrainer);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(Trainer other)
        {
            if (other == null) return false;
            return FirstName == other.FirstName && LastName == other.LastName && Subject == other.Subject;
        }

        public override void InsertData(string identifier)
        {
            base.InsertData(identifier);
            string input;
            do
            {
                Console.Write("Give the {0}'s Subject: ", identifier);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Trainer's subject cannot be empty");
                }
                else
                {
                    Subject = input;
                    break;
                }
            } while (true);
        }

        public override void PrintData(string identifier)
        {
            base.PrintData(identifier);
            Console.WriteLine("Subject: {0}", Subject);
        }
    }
}
