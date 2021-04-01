using System;

namespace PrivateSchool
{
    abstract class Human
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }

        public Human()
        {

        }

        public Human(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("firstName", "First Name cannot be null or empty!");
            }
            if (!IsValidName(firstName))
            {
                throw new ArgumentException("firstName", "First Name must start with capital letter and contain only alphabet letters.");
            }
            FirstName = firstName;
            if (String.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("lastName", "Last Name cannot be null or empty!");
            }
            if (!IsValidName(lastName))
            {
                throw new ArgumentException("lastName", "Last Name must start with capital letter and contain only alphabet letters.");
            }
            LastName = lastName;
        }

        public virtual void InsertData(string identifier) // The parameter is needed in order to implement inheritance and print different messages depending class
        {
            string input;

            if (String.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException("identifier", "Identifier cannot be null or empty!");
            }
            do
            {
                Console.Write("Give the {0}'s First Name: ", identifier);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("First Name cannot be empty");
                }
                else if (!IsValidName(input))
                {
                    Console.WriteLine("First Name must start with capital letter and contain only alphabet letters");
                }
                else
                {
                    FirstName = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the {0}'s Last Name: ", identifier);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Last Name cannot be empty");
                }
                else if (!IsValidName(input))
                {
                    Console.WriteLine("Last Name must start with capital letter and contain only alphabet letters");
                }
                else
                {
                    LastName = input;
                    break;
                }
            } while (true);
        }

        public virtual void PrintData(string identifier) // The parameter is needed in order to implement inheritance and print different messages depending class
        {
            if (String.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException("identifier", "Identifier cannot be null or empty!");
            }
            Console.WriteLine("The {0}'s info can be seen below:", identifier);
            Console.WriteLine("First Name: {0}", FirstName);
            Console.WriteLine("Last Name: {0}", LastName);
        }

        public bool IsValidName(string name)
        {
            if (Char.IsLower(name[0]))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
