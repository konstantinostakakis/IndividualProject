using System;
using System.Collections.Generic;

namespace PrivateSchool
{
    class PrivateSchool
    {
        private List<Course> _courses; // list of all courses
        private List<Trainer> _trainers; // list of all trainers
        private List<Student> _students; // list of all students
        private List<Assignment> _assignments; // list of all assignments
        //List<Student> studentsBelongingToManyCourses = new List<Student>(); // List of all students belonging to two or more courses

        public readonly string Name; // Name of the private school

        public PrivateSchool(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "The name of the school cannot be null or empty!");
            }
            Name = name;
            _courses = new List<Course>();
            _trainers = new List<Trainer>();
            _students = new List<Student>();
            _assignments = new List<Assignment>();
        }

        // Prints the menu of choices after data insertion
        private void PrintMenuOfChoices()
        {
            Console.WriteLine("What do you want to display?");
            Console.WriteLine("Type 1 for a list of all the students.");
            Console.WriteLine("Type 2 for a list of all the trainers.");
            Console.WriteLine("Type 3 for a list of all the assignments.");
            Console.WriteLine("Type 4 for a list of all the courses.");
            Console.WriteLine("Type 5 to output all the students per course.");
            Console.WriteLine("Type 6 to output all the trainers per course.");
            Console.WriteLine("Type 7 to output all the assignments per course.");
            Console.WriteLine("Type 8 to output all the assignments per student.");
            Console.WriteLine("Type 9 for a list of students that belong to more than one courses.");
            Console.WriteLine("Type 10 to give a date and output a list of students who need to submit one or more assignments on the same calendar week");
            Console.WriteLine("Type 11 to clear console");
            Console.WriteLine("Type anything else to stop the execution of the program.");
        }

        // Creates synthetic data for the program
        private void CreateSyntheticData()
        {
            try
            {
                // Create two Courses
                Course course = new Course("Coding Bootcamp 9", StreamValue.CSharp, TypeValue.Full_Time, new DateTime(2019, 10, 14), new DateTime(2020, 01, 22));
                _courses.Add(course);
                course = new Course("Coding Bootcamp 9", StreamValue.Java, TypeValue.Part_Time, new DateTime(2019, 10, 14), new DateTime(2020, 04, 22));
                _courses.Add(course);
                course = new Course("Coding Bootcamp 9", StreamValue.CSharp, TypeValue.Part_Time, new DateTime(2019, 10, 14), new DateTime(2020, 04, 22));
                _courses.Add(course);
                course = new Course("Coding Bootcamp 9", StreamValue.Java, TypeValue.Full_Time, new DateTime(2019, 10, 14), new DateTime(2020, 01, 22));
                _courses.Add(course);
                // Create five Trainers. The six of them belong only to one course, while the one belongs to two
                Trainer trainer = new Trainer("Ilias", "Karabasis", "C#");
                _trainers.Add(trainer);
                _courses[0].AddTrainer(trainer);
                trainer = new Trainer("Petros", "Papadopoulos", "Java");
                _trainers.Add(trainer);
                _courses[1].AddTrainer(trainer);
                trainer = new Trainer("Giannis", "Petrou", "HTML, CSS, Javascript");
                _trainers.Add(trainer);
                _courses[0].AddTrainer(trainer);
                _courses[1].AddTrainer(trainer);
                trainer = new Trainer("Kostas", "Petropoulos", "C#");
                _trainers.Add(trainer);
                _courses[2].AddTrainer(trainer);
                trainer = new Trainer("Ioanna", "Konstantinou", "SQL");
                _trainers.Add(trainer);
                _courses[2].AddTrainer(trainer);
                // Create eight Assignments. The seven of them belong only to one course, while the one belongs to two
                Assignment assignment = new Assignment("C# Console App", "In this assignment you need to create a console app in C#.", new DateTime(2019, 12, 12, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[0].AddAssignment(assignment);
                assignment = new Assignment("C# Console App 2", "In this assignment you need to create another console app in C#.", new DateTime(2019, 12, 22, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[0].AddAssignment(assignment);
                assignment = new Assignment("Java Console App", "In this assignment you need to create a console app in Java.", new DateTime(2020, 3, 10, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[1].AddAssignment(assignment);
                assignment = new Assignment("Java Console App 2", "In this assignment you need to create another console app in Java.", new DateTime(2020, 3, 21, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[1].AddAssignment(assignment);
                assignment = new Assignment("Website", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2020, 1, 13, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[0].AddAssignment(assignment);
                _courses[1].AddAssignment(assignment);
                assignment = new Assignment("Website 2", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2019, 12, 13, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[1].AddAssignment(assignment);
                assignment = new Assignment("C# Console App 3", "In this assignment you need to create a console app in C#.", new DateTime(2020, 1, 8, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[2].AddAssignment(assignment);
                assignment = new Assignment("SQL Assignment", "In this assignment you need to create a database and make queries to it", new DateTime(2020, 2, 21, 23, 59, 59), 25, 100);
                _assignments.Add(assignment);
                _courses[2].AddAssignment(assignment);
                // Create six Students. The four of them belong only to one course, while the other two belong to both
                Student student = new Student("Markos", "Markou", new DateTime(1992, 1, 24), 2500);
                student.AddAssignment(new Assignment("C# Console App", "In this assignment you need to create a console app in C#.", new DateTime(2019, 12, 12, 23, 59, 59), 20, 95));
                student.AddAssignment(new Assignment("C# Console App 2", "In this assignment you need to create another console app in C#.", new DateTime(2019, 12, 22, 23, 59, 59), 15, 80));
                student.AddAssignment(new Assignment("Website", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2020, 1, 13, 23, 59, 59), 17, 73));
                _students.Add(student);
                _courses[0].AddStudent(student);
                student = new Student("Kostas", "Ioannou", new DateTime(1985, 5, 10), 2250);
                student.AddAssignment(new Assignment("Java Console App", "In this assignment you need to create a console app in Java.", new DateTime(2020, 3, 10, 23, 59, 59), 24, 99));
                student.AddAssignment(new Assignment("Java Console App 2", "In this assignment you need to create another console app in Java.", new DateTime(2020, 3, 21, 23, 59, 59), 20, 91));
                student.AddAssignment(new Assignment("Website", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2020, 1, 13, 23, 59, 59), 15, 85));
                student.AddAssignment(new Assignment("Website 2", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2019, 12, 13, 23, 59, 59), 10, 80));
                _students.Add(student);
                _courses[1].AddStudent(student);
                student = new Student("Maria", "Oikonomou", new DateTime(1990, 2, 15), 4500);
                student.AddAssignment(new Assignment("C# Console App", "In this assignment you need to create a console app in C#.", new DateTime(2019, 12, 12, 23, 59, 59), 19, 94));
                student.AddAssignment(new Assignment("C# Console App 2", "In this assignment you need to create another console app in C#.", new DateTime(2019, 12, 22, 23, 59, 59), 20, 86));
                student.AddAssignment(new Assignment("Website", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2020, 1, 13, 23, 59, 59), 25, 98));
                student.AddAssignment(new Assignment("Java Console App", "In this assignment you need to create a console app in Java.", new DateTime(2020, 3, 10, 23, 59, 59), 17, 90));
                student.AddAssignment(new Assignment("Java Console App 2", "In this assignment you need to create another console app in Java.", new DateTime(2020, 3, 21, 23, 59, 59), 15, 87));
                student.AddAssignment(new Assignment("Website 2", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2019, 12, 13, 23, 59, 59), 18, 93));
                _students.Add(student);
                _courses[0].AddStudent(student);
                _courses[1].AddStudent(student);
                student = new Student("Giannis", "Kotsianis", new DateTime(1995, 2, 20), 4500);
                _students.Add(student);
                student.AddAssignment(new Assignment("C# Console App", "In this assignment you need to create a console app in C#.", new DateTime(2019, 12, 12, 23, 59, 59), 11, 86));
                student.AddAssignment(new Assignment("C# Console App 2", "In this assignment you need to create another console app in C#.", new DateTime(2019, 12, 22, 23, 59, 59), 17, 90));
                student.AddAssignment(new Assignment("Website", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2020, 1, 13, 23, 59, 59), 12, 85));
                student.AddAssignment(new Assignment("Java Console App", "In this assignment you need to create a console app in Java.", new DateTime(2020, 3, 10, 23, 59, 59), 25, 95));
                student.AddAssignment(new Assignment("Java Console App 2", "In this assignment you need to create another console app in Java.", new DateTime(2020, 3, 21, 23, 59, 59), 14, 89));
                student.AddAssignment(new Assignment("Website 2", "In this assignment you need to create a website using HTML, CSS and Javascript.", new DateTime(2019, 12, 13, 23, 59, 59), 17, 87));
                _courses[0].AddStudent(student);
                _courses[1].AddStudent(student);
                student = new Student("Nikos", "Nikolaou", new DateTime(1994, 1, 25), 2500);
                _students.Add(student);
                _courses[3].AddStudent(student);
                student = new Student("Pantelis", "Koutlas", new DateTime(1980, 8, 10), 2500);
                _students.Add(student);
                _courses[3].AddStudent(student);
                
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message); ;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }     
        }

        // Inserts data until user presses 5. User can add more than one elements per time, but in order to add a trainer/student/assignment
        // at least one course must have been created.
        private void InsertPrivateSchoolData()
        {
            string input;
            string input2;
            do
            {
                Console.WriteLine("What do you want to insert?");
                Console.WriteLine("Type 1 to insert one or more courses.");
                Console.WriteLine("Type 2 to insert one or more trainers.");
                Console.WriteLine("Type 3 to insert one or more students.");
                Console.WriteLine("Type 4 to insert one or more assignments.");
                Console.WriteLine("Type 5 to insert an existing student to one or more courses.");
                Console.WriteLine("Type 6 to insert an existing trainer to one or more courses.");
                Console.WriteLine("Type 7 to insert an existing assignment to one or more courses.");
                Console.WriteLine("Type 8 to modify the marks of one or more assignments for a student");
                Console.WriteLine("Type 9 to stop data insertion.");
                input = Console.ReadLine();
                // switch to choose depending user's input
                switch (input)
                {
                    case "1":
                        {
                            // insert courses until user don't press y
                            do
                            {
                                AddNewCourse();
                                Console.Write("Do you want to insert another course? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "2":
                        {
                            // insert trainers until user don't press y
                            do
                            {
                                AddNewTrainer();
                                Console.Write("Do you want to insert another trainer? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "3":
                        {
                            // insert students until user don't press y
                            do
                            {
                                AddNewStudent();
                                Console.Write("Do you want to insert another student? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "4":
                        {
                            // insert assignments until user don't press y
                            do
                            {
                                AddNewAssignment();
                                Console.Write("Do you want to insert another assignment? (y/n) ");
                                input2 = Console.ReadLine();
                            } while (input2 == "y");
                            break;
                        }
                    case "5":
                        {
                            AddExistingStudentToCourses();
                            break;
                        }
                    case "6":
                        {
                            AddExistingTrainerToCourses();
                            break;
                        }
                    case "7":
                        {
                            AddExistingAssignmentToCourses();
                            break;
                        }
                    case "8":
                        {
                            ModifyAssignmentMarksForAStudent();
                            break;
                        }
                    case "9":
                        {
                            CheckIfThereAreStudentAssignmentsWithZeroMarksAndModify();
                            break;
                        }
                }
                Console.WriteLine();
            } while (input != "9");
        }

        // Adds a new course unless it exists already
        private void AddNewCourse()
        {
            // Create the course and add it to courses list
            Course course = new Course();
            course.InsertData();
            // Check if this course already exists and add it to the list only if does not
            if (_courses.Contains(course))
            {
                Console.WriteLine("This course already exists!!");
            }
            else
            {
                _courses.Add(course);
            }
        }

        // Adds a new trainer to one or more courses unless he exists already there
        private void AddNewTrainer()
        {
            // Create the new trainer and add it to trainers list
            Trainer trainer = new Trainer();
            trainer.InsertData("Trainer");
            // Only add trainer to trainers list once
            if (!_trainers.Contains(trainer))
            {
                _trainers.Add(trainer);
            }
            if(_courses.Count > 0)
            {
                // Ask the user if he wants to insert the trainer to a course
                Console.WriteLine();
                Console.Write("Do you want to insert the trainer to a course? (y/n) ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    // Print a list of the available courses
                    Console.WriteLine();
                    Console.WriteLine("List of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the trainer will be inserted
                    do
                    {
                        int index = ReturnCourseIndex(_courses.Count, "trainer");
                        if (index == -1) // The course the trainer belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index insert trainer to Trainers list if the trainer does not exist there already
                        if (!_courses[index].TrainersListContains(trainer))
                        {
                            _courses[index].AddTrainer(trainer);
                        }
                        else
                        {
                            Console.WriteLine("This trainer already belongs to this course.");
                        }
                        // If there are more than one courses ask the user if he/she wants to add the trainer to another course
                        if (_courses.Count > 1)
                        {
                            Console.Write("Do you want to insert the trainer to another course as well? (y/n) ");
                            input = Console.ReadLine();
                            if (input != "y")
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
            }                               
        }

        // Adds a new student to one or more courses unless unless he/she exists already there
        private void AddNewStudent()
        {
            // Create the new student and add it to students list
            Student student = new Student();
            student.InsertData("Student");
            // Only add student to students list once
            if (!_students.Contains(student))
            {
                _students.Add(student);
            }
            if (_courses.Count > 0)
            {
                // Ask the user if he wants to insert the student to a course
                Console.WriteLine();
                Console.Write("Do you want to insert the student to a course? (y/n) ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    // Print a list of the available courses
                    Console.WriteLine();
                    Console.WriteLine("List of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the student will be inserted
                    do
                    {
                        int index = ReturnCourseIndex(_courses.Count, "student");
                        if (index == -1) // The course the student belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index insert student to Students list if the student does not exist there already
                        if (!_courses[index].StudentsListContains(student))
                        {
                            // If the course has assignments assigned to it ask the user to insert the student's marks or not
                            if(_courses[index].GetAssignmentsListSize() > 0)
                            {
                                InsertStudentMarksForCourseAssignments(student, index);
                            }
                            _courses[index].AddStudent(student);
                        }
                        else
                        {
                            Console.WriteLine("This student already belongs to this course.");
                        }
                        // If there are more than one courses ask the user if he/she wants to add the student to another course
                        if (_courses.Count > 1)
                        {
                            Console.Write("Do you want to insert the student to another course as well? (y/n) ");
                            input = Console.ReadLine();
                            if (input != "y")
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
            }            
        }

        // Adds a new assignment to one or more courses unless unless it exists already there
        private void AddNewAssignment()
        {
            // Create the new assignment and add it to students list
            Assignment assignment = new Assignment();
            assignment.InsertData();
            // Only add assignment to assignments list once
            if (!_assignments.Contains(assignment))
            {
                _assignments.Add(assignment);
            }
            if (_courses.Count > 0)
            {
                // Ask the user if he wants to insert the assignment to a course
                Console.WriteLine();
                Console.Write("Do you want to insert the assignment to a course? (y/n) ");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    // Print a list of the available courses
                    Console.WriteLine();
                    Console.WriteLine("List of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the assignment will be inserted
                    do
                    {
                        int index = ReturnCourseIndex(_courses.Count, "assignment");
                        if (index == -1) // The course the assignment belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index insert assignment to Assignments list if the assignment does not exist there already
                        if (!_courses[index].AssignmentsListContains(assignment))
                        {
                            _courses[index].AddAssignment(assignment);
                            // If there are students that belong to this course, call  InsertAssignmentMarksForCourseStudents
                            if (_courses[index].GetStudentsListSize() > 0)
                            {
                                InsertAssignmentMarksForCourseStudents(assignment, index);
                            }
                        }
                        else
                        {
                            Console.WriteLine("This assignment already belongs to this course.");
                        }
                        // If there are more than one courses ask the user if he/she wants to add the trainer to another course
                        if (_courses.Count > 1)
                        {
                            Console.Write("Do you want to insert the assignment to another course as well? (y/n) ");
                            input = Console.ReadLine();
                            if (input != "y")
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    } while (true);
                }
            }
        }

        // Returns an integer inserted by user between -1 and count-1
        private int ReturnCourseIndex(int count, string identifier)
        {
            do
            {
                int index;
                // Read input from user until an integer is given
                do
                {
                    Console.Write("Please enter the number corresponding to the course to which the {0} belongs or type 0 if the course you want does not appear in the list: ", identifier);
                } while (!int.TryParse(Console.ReadLine(), out index));
                if (0 <= index && index <= count)
                {
                    return index - 1;
                }
                Console.WriteLine("The number you have inserted does not correspond to any course or is not 0.");
            } while (true);
        }

        // Returns an integer inserted by user between -1 and count-1
        private int ReturnIndex(int count, string identifier)
        {
            do
            {
                int index;
                // Read input from user until an integer is given
                do
                {
                    Console.Write("Please enter the number corresponding to the {0} you want to insert to a course or type 0 if you cannot see the {0} you want in the list: ", identifier);
                } while (!int.TryParse(Console.ReadLine(), out index));
                if (0 <= index && index <= count)
                {
                    return index - 1;
                }
                Console.WriteLine("The number you have inserted does not correspond to any {0} or is not 0.", identifier);
            } while (true);
        }

        // Returns an integer inserted by user between -1 and count-1
        private int ReturnAssignmentIndex(int count)
        {
            do
            {
                int index;
                // Read input from user until an integer is given
                do
                {
                    Console.Write("Please enter the number corresponding to the student's assignment you want to modify its marks or type 0 if you cannot see the assignment you want in the list: ");
                } while (!int.TryParse(Console.ReadLine(), out index));
                if (0 <= index && index <= count)
                {
                    return index - 1;
                }
                Console.WriteLine("The number you have inserted does not correspond to any assignment or is not 0.");
            } while (true);
        }

        // Returns an integer inserted by user between -1 and count-1
        private int ReturnStudentIndex(int count)
        {
            do
            {
                int index;
                // Read input from user until an integer is given
                do
                {
                    Console.Write("Please enter the number corresponding to the student you want to modify his/her assignment marks or type 0 if you cannot see the student you want in the list: ");
                } while (!int.TryParse(Console.ReadLine(), out index));
                if (0 <= index && index <= count)
                {
                    return index - 1;
                }
                Console.WriteLine("The number you have inserted does not correspond to any student or is not 0.");
            } while (true);
        }

        // Adds a student chosen by user to one or more courses
        private void AddExistingStudentToCourses()
        {
            if (_students.Count > 0)
            {
                // Output all existing students
                Console.WriteLine("Below you can find a list of the existing students:");
                for (int i = 0; i < _students.Count; i++)
                {
                    Console.WriteLine("Student {0}:", i + 1);
                    _students[i].PrintData("Student");
                    Console.WriteLine();
                }
                int index1 = ReturnIndex(_students.Count, "student");
                if (index1 == -1)
                {
                    return;
                }
                if (_courses.Count > 0)
                {
                    // Print the list of available courses
                    Console.WriteLine();
                    Console.WriteLine("Below you can find a list of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the student will be inserted
                    do
                    {
                        int index2 = ReturnCourseIndex(_courses.Count, "student");
                        if (index2 == -1) // The course the student belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index2 insert student to Students list if the student does not exist there already
                        if (!_courses[index2].StudentsListContains(_students[index1]))
                        {
                            // If the course has assignments assigned to it, call InsertStudentMarksForCourseAssignments
                            if (_courses[index2].GetAssignmentsListSize() > 0)
                            {
                                InsertStudentMarksForCourseAssignments(_students[index1], index2);
                            }
                            _courses[index2].AddStudent(_students[index1]);
                        }
                        else
                        {
                            Console.WriteLine("This student already belongs to this course.");
                        }
                        Console.Write("Do you want to insert the student to another course as well? (y/n) ");
                        string input = Console.ReadLine();
                        if (input != "y")
                        {
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("You have not inserted any courses yet to add the student to.");
                }                
            }
            else
            {
                Console.WriteLine("You have not inserted any students yet.");
            }
            
        }

        // Adds a trainer chosen by user to one or more courses
        private void AddExistingTrainerToCourses()
        {
            if (_trainers.Count > 0)
            {
                // Output all existing trainers
                Console.WriteLine("Below you can find a list of the existing trainers:");
                for (int i = 0; i < _trainers.Count; i++)
                {
                    Console.WriteLine("Trainer {0}:", i + 1);
                    _trainers[i].PrintData("Trainer");
                    Console.WriteLine();
                }
                int index1 = ReturnIndex(_trainers.Count, "trainer");
                if (index1 == -1)
                {
                    return;
                }
                if (_courses.Count > 0)
                {
                    // Print the list of available courses
                    Console.WriteLine();
                    Console.WriteLine("Below you can find a list of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the trainer will be inserted
                    do
                    {
                        int index2 = ReturnCourseIndex(_courses.Count, "trainer");
                        if (index2 == -1) // The course the trainer belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index2 insert trainer to Trainers list if the trainer does not exist there already
                        if (!_courses[index2].TrainersListContains(_trainers[index1]))
                        {
                            _courses[index2].AddTrainer(_trainers[index1]);
                        }
                        else
                        {
                            Console.WriteLine("This trainer already belongs to this course.");
                        }
                        Console.Write("Do you want to insert the trainer to another course as well? (y/n) ");
                        string input = Console.ReadLine();
                        if (input != "y")
                        {
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("You have not inserted any courses yet to add the trainer to.");
                }
            }
            else
            {
                Console.WriteLine("You have not inserted any trainers yet.");
            }
        }

        // Adds an assignment chosen by user to one or more courses
        private void AddExistingAssignmentToCourses()
        {
            if (_assignments.Count > 0)
            {
                // Output all existing assignments
                Console.WriteLine("Below you can find a list of the existing assignments:");
                for (int i = 0; i < _assignments.Count; i++)
                {
                    Console.WriteLine("Assignment {0}:", i + 1);
                    _assignments[i].PrintData();
                    Console.WriteLine();
                }
                int index1 = ReturnIndex(_assignments.Count, "assignment");
                if (index1 == -1)
                {
                    return;
                }
                if (_courses.Count > 0)
                {
                    // Print the list of available courses
                    Console.WriteLine();
                    Console.WriteLine("Below you can find a list of available courses:");
                    for (int i = 0; i < _courses.Count; i++)
                    {
                        Console.WriteLine("Course {0}:", i + 1);
                        _courses[i].PrintData();
                        Console.WriteLine();
                    }
                    // Ask the user for the course to which the assignment will be inserted
                    do
                    {
                        int index2 = ReturnCourseIndex(_courses.Count, "assignment");
                        if (index2 == -1) // The course the assignment belongs to has not been inserted yet
                        {
                            return;
                        }
                        // For the above index2 insert assignment to Assignments list if the assignment does not exist there already
                        if (!_courses[index2].AssignmentsListContains(_assignments[index1]))
                        {
                            _courses[index2].AddAssignment(_assignments[index1]);
                            // If there are students that belong to this course, call  InsertAssignmentMarksForCourseStudents
                            if (_courses[index2].GetStudentsListSize() > 0)
                            {
                                InsertAssignmentMarksForCourseStudents(_assignments[index1], index2);
                            }
                        }
                        else
                        {
                            Console.WriteLine("This assignments already belongs to this course.");
                        }
                        Console.Write("Do you want to insert the assignment to another course as well? (y/n) ");
                        string input = Console.ReadLine();
                        if (input != "y")
                        {
                            break;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("You have not inserted any courses yet to add the assignment to.");
                }
            }
            else
            {
                Console.WriteLine("You have not inserted any assignments yet.");
            }
        }

        // Prints all students inserted by user
        private void ListAllStudentsInserted()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("No students were inserted.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a list of all the students:");
                for (int i = 0; i < _students.Count; i++)
                {
                    Console.WriteLine("Student {0}:", i + 1);
                    _students[i].PrintData("Student");
                    Console.WriteLine();
                }
            }
        }

        // Prints all trainers inserted by user
        private void ListAllTrainersInserted()
        {
            if (_trainers.Count == 0)
            {
                Console.WriteLine("No trainers were inserted.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a list of all the trainers:");
                for (int i = 0; i < _trainers.Count; i++)
                {
                    Console.WriteLine("Trainer {0}:", i + 1);
                    _trainers[i].PrintData("Trainer");
                    Console.WriteLine();
                }
            }
        }

        // Prints all assignments inserted by user
        private void ListAllAssignmentsInserted()
        {
            if (_assignments.Count == 0)
            {
                Console.WriteLine("No assignments were inserted.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a list of all the assignments:");
                for (int i = 0; i < _assignments.Count; i++)
                {
                    Console.WriteLine("Assignment {0}:", i + 1);
                    _assignments[i].PrintData();
                    Console.WriteLine();
                }
            }
        }

        // Prints all courses inserted by user
        private void ListAllCoursesInserted()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("No courses were inserted");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a list of all the courses:");
                for (int i = 0; i < _courses.Count; i++)
                {
                    Console.WriteLine("Course {0}:", i + 1);
                    _courses[i].PrintData();
                    Console.WriteLine();
                }
            }
        }

        // Prints all students per course
        private void ListAllStudentsPerCourse()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("No courses were inserted, thus there is nothing to display.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a all the students per course:");
                for (int i = 0; i < _courses.Count; i++)
                {
                    Console.WriteLine("Course {0}:", i + 1);
                    _courses[i].PrintData();
                    Console.WriteLine();
                    if (_courses[i].GetStudentsListSize() == 0)
                    {
                        Console.WriteLine("No students were inserted for this course.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Students' info for the above course:");
                        Console.WriteLine();
                        _courses[i].ListStudents();
                    }
                }
            }
        }

        // Prints all trainers per course
        private void ListAllTrainersPerCourse()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("No courses were inserted, thus there is nothing to display.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a all the trainers per course:");
                for (int i = 0; i < _courses.Count; i++)
                {
                    Console.WriteLine("Course {0}:", i + 1);
                    _courses[i].PrintData();
                    Console.WriteLine();
                    if (_courses[i].GetTrainersListSize() == 0)
                    {
                        Console.WriteLine("No trainers were inserted for this course.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Trainers' info for the above course:");
                        Console.WriteLine();
                        _courses[i].ListTrainers();
                    }
                }
            }
        }

        // Prints all assignments per course
        private void ListAllAssignmentsPerCourse()
        {
            if (_courses.Count == 0)
            {
                Console.WriteLine("No courses were inserted, thus there is nothing to display.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a all the assignments per course:");
                for (int i = 0; i < _courses.Count; i++)
                {
                    Console.WriteLine("Course {0}:", i + 1);
                    _courses[i].PrintData();
                    Console.WriteLine();
                    if (_courses[i].GetAssignmentsListSize() == 0)
                    {
                        Console.WriteLine("No assignments were inserted for this course.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Assignments' info for the above course:");
                        Console.WriteLine();
                        _courses[i].ListAssignments();
                    }
                }
            }
        }

        // Prints all assignments per student
        private void ListAllAssignmentsPerStudent()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("No students were inserted, thus there is nothing to display.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a all the assignments per student:");
                for (int i = 0; i < _students.Count; i++)
                {
                    Console.WriteLine("Student {0}:", i + 1);
                    _students[i].PrintData("Student");
                    Console.WriteLine();
                    if (_students[i].GetAssignmentsListSize() == 0)
                    {
                        Console.WriteLine("This student has no assignments yet.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Assignments' info for the above student:");
                        Console.WriteLine();
                        _students[i].ListAssignments();
                    }
                }
            }
        }

        // Prints all students belonging to more than one courses
        private void ListAllStudentsBeloningToManyCourses(List<Student> studentsBelongingToManyCourses)
        {
            if (studentsBelongingToManyCourses.Count == 0)
            {
                Console.WriteLine("There are no students belonging to more than one courses.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Below you can see a all the students belonging to more than one courses:");
                for (int i = 0; i < studentsBelongingToManyCourses.Count; i++)
                {
                    Console.WriteLine("Student {0}:", i + 1);
                    studentsBelongingToManyCourses[i].PrintData("Student");
                    Console.WriteLine();
                }
            }
        }

        // Prints all the students that have to submit at least one assignment in a calendar week (Monday-Friday) chosen by user
        private void ListAllStudentsSubmittingAssignmentInCalendarWeek()
        {
            DateTime usersDate = new DateTime();
            int studentsFound = 0; // How many students need to submit an assignment in the given calendar week
            /*Console.Write("Please choose a date: ");
            while (!DateTime.TryParse(Console.ReadLine(), out usersDate))
            {
                Console.WriteLine("You did not give a date!!");
                Console.Write("Please choose a date: ");
            }*/
            // Validation catching possible exception thrown by Convert.ToDateTime until correct date is given
            // Above you can see another way using DateTime.TryParse
            bool validInput;
            do
            {
                Console.Write("Please choose a date: ");
                try
                {
                    usersDate = Convert.ToDateTime(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not give a date!!");
                    validInput = false;
                }
            } while (!validInput);
            // The type that we use to check if an assignment date is in the given calendar week
            // is the same if the day is Monday to Saturday and differs only for Sunday.
            // It would be the same for all days if (int)DayOfWeek.Sunday returned 7 instead of 0.
            DayOfWeek day = usersDate.DayOfWeek; // Get the day of the week corresponding to the given date
            switch (day)
            {
                case DayOfWeek.Sunday:
                    {
                        foreach (Student student in _students)
                        {
                            for (int i = 0; i < student.GetAssignmentsListSize(); i++)
                            {
                                Assignment assignment = student.GetAssignmentFromList(i);
                                int diff = assignment.SubDateTime.Date.Subtract(usersDate).Days; // Get the date part from assignment's SubDateTime, 
                                                                                                 // subtract if from the given date and get the Days that this interval has
                                                                                                 // If the given date is a Sunday, then the days diff for the week will be from -6(Monday) to 0(Sunday)
                                                                                                 // Adding 7 to the diff the value will be from 1(Monday) to 7(Sunday).
                                                                                                 // So we need to check if (diff + 7) is from 1(Monday) to 5(Friday).
                                if (diff + 7 >= 1 && diff + 7 <= 5)
                                {
                                    studentsFound++;
                                    Console.WriteLine("Student {0}:", studentsFound);
                                    student.PrintData("Student");
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        foreach (Student student in _students)
                        {
                            for (int i = 0; i < student.GetAssignmentsListSize(); i++)
                            {
                                Assignment assignment = student.GetAssignmentFromList(i);
                                int diff = assignment.SubDateTime.Date.Subtract(usersDate).Days; // Get the date part from assignment's SubDateTime, 
                                                                                                 // subtract if from the given date and get the Days that this interval has
                                                                                                 // If the given date is different from Sunday, then the days diff for the week will depend to the day.
                                                                                                 // However if we add (int)day to the diff the value will be always from 1(Monday) to 7(Sunday).
                                                                                                 // So we need to check if (diff + (int)day) is from 1(Monday) to 5(Friday).
                                if (diff + (int)day >= 1 && diff + (int)day <= 5)
                                {
                                    studentsFound++;
                                    Console.WriteLine("Student {0}:", studentsFound);
                                    student.PrintData("Student");
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        }
                        break;
                    }
            }
            // Check if there were any students found
            if (studentsFound == 0)
            {
                Console.WriteLine("No students need to submit one or more assignments on the same calendar week as the given date");
            }
        }

        // Finds all students belonging to more than one courses
        private void PopulateStudentsBelongingToManyCoursesList(List<Student> studentsBelongingToManyCourses)
        {
            List<Course> results = new List<Course>();
            foreach (Student student in _students)
            {
                results = _courses.FindAll(x => x.StudentsListContains(student)); // Results is a list of all Course elements in _courses list where the specific student belongs
                if (results.Count >= 2)
                {
                    studentsBelongingToManyCourses.Add(student); // If results list has two or more elements, then the student belongs to two or more courses
                }
            }
        }

        // Inserts a student's marks for all the assignments assigned to a course defined by index
        private void InsertStudentMarksForCourseAssignments(Student student, int index)
        {
            // Ask the user to insert marks or not
            Console.Write("This course has assignments assigned to it. Do you want to insert the student's marks for these assignments or will you do it later? (y/n) ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                // List the assignments assigned to course until now
                Console.WriteLine("Below you can see the assignments assigned to this course.");
                for (int i = 0; i < _courses[index].GetAssignmentsListSize(); i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Assignment {0}:", i + 1);
                    Assignment assignment = _courses[index].GetAssignmentFromList(i);
                    assignment.PrintData();
                    Console.WriteLine();
                    // Read the student's marks
                    float oralMark;
                    Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0 || oralMark > assignment.OralMark)
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment.OralMark);
                        Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    }
                    float totalMark;
                    Console.Write("Give the Student's Total Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0 || totalMark > assignment.TotalMark || totalMark > assignment.TotalMark - (assignment.OralMark - oralMark))
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment.TotalMark - (assignment.OralMark - oralMark));
                        Console.Write("Give the Student's Total Mark for the above assignment: ");
                    }
                    // Create a new assignment object with the same title, description and subDateTime and the marks of the student
                    Assignment studentsAssignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, oralMark, totalMark);
                    // Add this new assignment to student's assignments list
                    student.AddAssignment(studentsAssignment);
                }
            }
            else
            {
                for (int i = 0; i < _courses[index].GetAssignmentsListSize(); i++)
                {
                    Assignment assignment = _courses[index].GetAssignmentFromList(i);
                    // Create a new assignment object with the same title, description and subDateTime and the marks having value 0
                    Assignment studentsAssignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, 0, 0);
                    // Add this new assignment to student's assignments list
                    student.AddAssignment(studentsAssignment);
                }
            }
        }

        // Inserts an assignment's marks for all the students that belong to a course defined by index
        private void InsertAssignmentMarksForCourseStudents(Assignment assignment, int index)
        {
            // Ask the user to insert marks or not
            Console.Write("There are students that belong to this course. Do you want to insert their marks for this assignment or you will do it later? (y/n) ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                // List the students that belong to this course already
                Console.WriteLine("Below you can see the students that belong to this course.");
                for (int i = 0; i < _courses[index].GetStudentsListSize(); i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Student {0}:", i + 1);
                    Student student = _courses[index].GetStudentFromList(i);
                    student.PrintData("Student");
                    Console.WriteLine();
                    // Read the student's marks
                    float oralMark;
                    Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0 || oralMark > assignment.OralMark)
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment.OralMark);
                        Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    }
                    float totalMark;
                    Console.Write("Give the Student's Total Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0 || totalMark > assignment.TotalMark || totalMark > assignment.TotalMark - (assignment.OralMark - oralMark))
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment.TotalMark - (assignment.OralMark - oralMark));
                        Console.Write("Give the Student's Total Mark for the above assignment: ");
                    }
                    // Create a new assignment object with the same title, description and subDateTime and the marks of the student
                    Assignment studentsAssignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, oralMark, totalMark);
                    // Add this new assignment to student's assignments list
                    student.AddAssignment(studentsAssignment);
                }
            }
            else
            {
                for (int i = 0; i < _courses[index].GetStudentsListSize(); i++)
                {
                    Student student = _courses[index].GetStudentFromList(i);
                    // Create a new assignment object with the same title, description and subDateTime and the marks of the student
                    Assignment studentsAssignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, 0, 0);
                    // Add this new assignment to student's assignments list
                    student.AddAssignment(studentsAssignment);
                }
            }
        }

        // Modifies the marks of one or more assignments of a student chosen by user
        private void ModifyAssignmentMarksForAStudent()
        {
            if (_students.Count > 0)
            {
                // Output all existing students
                Console.WriteLine("Below you can find a list of the existing students:");
                for (int i = 0; i < _students.Count; i++)
                {
                    Console.WriteLine("Student {0}:", i + 1);
                    _students[i].PrintData("Student");
                    Console.WriteLine();
                }
                int index1 = ReturnStudentIndex(_students.Count);
                if (index1 == -1)
                {
                    return;
                }
                // Output all student's assignments. 
                Console.WriteLine("Below you can find a list of the student's assignments:");
                for (int i = 0; i < _students[index1].GetAssignmentsListSize(); i++)
                {
                    Console.WriteLine("Assignment {0}:", i + 1);
                    _students[index1].GetAssignmentFromList(i).PrintData();
                    Console.WriteLine();
                }
                // Ask the user for the assignment which marks will be modified
                do
                {
                    int index2 = ReturnAssignmentIndex(_students[index1].GetAssignmentsListSize());
                    if (index2 == -1) // The assignment the user wants to modify its marks has not been inserted yet
                    {
                        return;
                    }
                    // For the above index2 
                    Assignment assignment = _students[index1].GetAssignmentFromList(index2);
                    Assignment assignment1 = new Assignment();
                    // Find the assignment belonging to the course to get max oral and total marks
                    foreach (Course course in _courses)
                    {
                        if (course.StudentsListContains(_students[index1]))
                        {
                            for(int i = 0; i < course.GetAssignmentsListSize(); i++)
                            {
                                assignment1 = course.GetAssignmentFromList(i);
                                if (assignment.Title == assignment1.Title && assignment.Description == assignment1.Description && assignment.SubDateTime == assignment1.SubDateTime)
                                {
                                    break; // assignment1 is the one we are looking for
                                }
                            }
                        }
                    }
                    // Read the student's marks
                    float oralMark;
                    Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0 || oralMark > assignment1.OralMark)
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment1.OralMark);
                        Console.Write("Give the Student's Oral Mark for the above assignment: ");
                    }
                    float totalMark;
                    Console.Write("Give the Student's Total Mark for the above assignment: ");
                    while (!float.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0 || totalMark > assignment1.TotalMark || totalMark > assignment1.TotalMark - (assignment1.OralMark - oralMark))
                    {
                        Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment1.TotalMark - (assignment1.OralMark - oralMark));
                        Console.Write("Give the Student's Total Mark for the above assignment: ");
                    }
                    // Because properties OralMark and TotalMark have been declared as private set, we have to remove previous assignment from list
                    // and insert a new instance with the modified marks in its previous place
                    _students[index1].RemoveAssignment(assignment);
                    assignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, oralMark, totalMark);
                    try
                    {
                        _students[index1].InsertAssignment(index2, assignment);
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.Write("Do you want to modify the marks of another assignment for this student as well? (y/n) ");
                    string input = Console.ReadLine();
                    Console.WriteLine();
                    if (input != "y")
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("You have not inserted any students yet.");
            }
        }

        // Modifies the marks of one or more assignments of a student given as parameter
        private void ModifyAssignmentMarksForAStudent(Student student)
        {
            // Output all student's assignments. 
            Console.WriteLine("Below you can find a list of the student's assignments:");
            for (int i = 0; i < student.GetAssignmentsListSize(); i++)
            {
                Console.WriteLine("Assignment {0}:", i + 1);
                student.GetAssignmentFromList(i).PrintData();
                Console.WriteLine();
            }
            // Ask the user for the assignment which marks will be modified
            do
            {
                int index2 = ReturnAssignmentIndex(student.GetAssignmentsListSize());
                if (index2 == -1) // The assignment the user wants to modify its marks has not been inserted yet
                {
                    return;
                }
                // For the above index2 
                Assignment assignment = student.GetAssignmentFromList(index2);
                Assignment assignment1 = new Assignment();
                // Find the assignment belonging to the course to get max oral and total marks
                foreach (Course course in _courses)
                {
                    if (course.StudentsListContains(student))
                    {
                        for (int i = 0; i < course.GetAssignmentsListSize(); i++)
                        {
                            assignment1 = course.GetAssignmentFromList(i);
                            if (assignment.Title == assignment1.Title && assignment.Description == assignment1.Description && assignment.SubDateTime == assignment1.SubDateTime)
                            {
                                break; // assignment1 is the one we are looking for
                            }
                        }
                    }
                }
                // Read the student's marks
                float oralMark;
                Console.Write("Give the Student's Oral Mark for the above assignment: ");
                while (!float.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0 || oralMark > assignment1.OralMark)
                {
                    Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment1.OralMark);
                    Console.Write("Give the Student's Oral Mark for the above assignment: ");
                }
                float totalMark;
                Console.Write("Give the Student's Total Mark for the above assignment: ");
                while (!float.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0 || totalMark > assignment1.TotalMark || totalMark > assignment1.TotalMark - (assignment1.OralMark - oralMark))
                {
                    Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment1.TotalMark - (assignment1.OralMark - oralMark));
                    Console.Write("Give the Student's Total Mark for the above assignment: ");
                }
                // Because properties OralMark and TotalMark have been declared as private set, we have to remove previous assignment from list
                // and insert a new instance with the modified marks in its previous place
                student.RemoveAssignment(assignment);
                assignment = new Assignment(assignment.Title, assignment.Description, assignment.SubDateTime, oralMark, totalMark);
                try
                {
                    student.InsertAssignment(index2, assignment);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Write("Do you want to modify the marks of another assignment for this student as well? (y/n) ");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (input != "y")
                {
                    break;
                }
            } while (true);
        }

        // Checks for every student if there are assignments with zero marks and asks user if they want to modify them in case of mistake
        private void CheckIfThereAreStudentAssignmentsWithZeroMarksAndModify()
        {
            bool printMessage = true;
            foreach (Student student in _students)
            {
                string input = "n";
                for (int i = 0; i < student.GetAssignmentsListSize(); i++)
                {
                    Assignment assignment = student.GetAssignmentFromList(i);
                    if (assignment.OralMark == 0.0f || assignment.TotalMark == 0.0f)
                    {
                        if (printMessage)
                        {
                            Console.WriteLine("Attention! Possibly you have forgot to insert marks to some student assignments. Find info below:");
                            Console.WriteLine();
                            printMessage = false;
                        }
                        student.PrintData("Student");
                        Console.WriteLine();
                        Console.Write("At least one assignment of the student above has one of its marks zero. Do you want to modify them? (y/n) ");
                        input = Console.ReadLine();
                        break;
                    }
                }
                if (input == "y")
                {
                    Console.WriteLine();
                    ModifyAssignmentMarksForAStudent(student);
                }
            }
        }

        // Implements the operation of the private school
        public void Run()
        {
            string input;
            Console.WriteLine("Welcome to {0} School.", Name);
            // Ask user to insert data or use synthetic data
            do
            {
                Console.Write("Type 1 to insert data or 2 to use synthetic data: ");
                input = Console.ReadLine();
            } while (input != "1" && input != "2");

            if (input == "1")
            {
                // User inserts data
                InsertPrivateSchoolData();
            }
            else
            {
                // Create the synthetic data
                CreateSyntheticData();
            }

            // Populate studentsBelongingToManyCourses list
            List<Student> studentsBelongingToManyCourses = new List<Student>();
            PopulateStudentsBelongingToManyCoursesList(studentsBelongingToManyCourses);

            // After data insertion functions
            bool stop = false;
            do
            {
                // Print menu of choices
                PrintMenuOfChoices();
                input = Console.ReadLine();
                // Do something depending user's choice
                switch (input)
                {
                    case "1":
                        {
                            ListAllStudentsInserted();
                            break;
                        }
                    case "2":
                        {
                            ListAllTrainersInserted();
                            break;
                        }
                    case "3":
                        {
                            ListAllAssignmentsInserted();
                            break;
                        }
                    case "4":
                        {
                            ListAllCoursesInserted();
                            break;
                        }
                    case "5":
                        {
                            ListAllStudentsPerCourse();
                            break;
                        }
                    case "6":
                        {
                            ListAllTrainersPerCourse();
                            break;
                        }
                    case "7":
                        {
                            ListAllAssignmentsPerCourse();
                            break;
                        }
                    case "8":
                        {
                            ListAllAssignmentsPerStudent();
                            break;
                        }
                    case "9":
                        {
                            ListAllStudentsBeloningToManyCourses(studentsBelongingToManyCourses);
                            break;
                        }
                    case "10":
                        {
                            ListAllStudentsSubmittingAssignmentInCalendarWeek();
                            break;
                        }
                    case "11":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            stop = true;
                            break;
                        }
                }
            } while (!stop);

            Console.WriteLine("Press any key to exit the application.");
            Console.ReadKey();
        }
    }
}
