namespace PerformanceTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[1];
                
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = EnrollStudent();
            }

            DisplayStudentInformation(students);

            Console.Write("\nEnter the student surname: ");
            string searchSurname = Console.ReadLine();
            SearchAndDisplayStudent(students, searchSurname);
        }

        static Student EnrollStudent()
        {
            
            Student student = new Student();
            Console.WriteLine("Hello! Welcome to Enrollment Module: Please fill up the following.\n");
            Console.Write("Enter Student Number: ");
            student.StudentNumber = Console.ReadLine();

            Console.Write("Enter Surname: ");
            student.Surname = Console.ReadLine();

            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Enter Middle Initial: ");
            student.MiddleInitial = Console.ReadLine();

            Console.Write("Enter Address: ");
            student.Address = Console.ReadLine();

            Console.Write("Enter Grade Level: ");
            int.TryParse(Console.ReadLine(), out int gradeLevel);
            student.GradeLevel = gradeLevel;

            Console.Write("Enter Gender (M/F): ");
            char.TryParse(Console.ReadLine(), out char gender);
            student.Gender = gender;

            Console.WriteLine("Enter 1st Quarter raw scores for Computer Programming 4:");
            SetScores(student);
            student.TotalScoreQ1 = (int)student.CalculateOverallGrade();

            Console.WriteLine("\nEnter 2nd Quarter raw scores for Computer Programming 4:");
            SetScores(student);
            student.TotalScoreQ2 = (int)student.CalculateOverallGrade();


            Console.WriteLine("\nEnter 1st Quarter raw scores for Computer Programming 5:");
            SetScores(student);
            student.TotalScoreQ3 = (int)student.CalculateOverallGrade();


            Console.WriteLine("\nEnter 2nd Quarter raw scores for Computer Programming 5:");
            SetScores(student);
           student.TotalScoreQ4 = (int)student.CalculateOverallGrade();
            return student;
        }
        static void SetScores(Student student)
        {
            double quiz1, quiz2, quiz3, participation1, participation2, participation3, exam, taskPerformance;

            TryGetScore("Quiz 1", out quiz1);
            TryGetScore("Quiz 2", out quiz2);
            TryGetScore("Quiz 3", out quiz3);
            TryGetScore("Participation 1", out participation1);
            TryGetScore("Participation 2", out participation2);
            TryGetScore("Participation 3", out participation3);
            TryGetScore("Exam", out exam);
            TryGetScore("Task Performance", out taskPerformance);

            double weightedQuiz = (quiz1 + quiz2 + quiz3) / 3.0;
            double weightedParticipation = (participation1 + participation2 + participation3) / 3.0;

            student.Quiz1 = weightedQuiz;
            student.Participation1 = weightedParticipation;
            student.Exam = exam;
            student.TaskPerformance = taskPerformance;  

           
        }
        static void DisplayStudentInformation(Student[] students)
        {
            foreach (var currentStudent in students)
            {
                Console.WriteLine("\n----------------------------------------");
                currentStudent.DisplayStudentInfo();
                currentStudent.CalculateAndDisplayGrade();
            }
        }

        static void SearchAndDisplayStudent(Student[] students, string searchSurname)
        {
            bool found = false;

            foreach (var currentStudent in students)
            {
                if (currentStudent.Surname.Equals(searchSurname, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n----------------------------------------");
                    currentStudent.DisplayStudentInfo();
                    currentStudent.CalculateAndDisplayGrade();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"No student found with the surname: {searchSurname}");
            }
        }

        static double GetTotalScore()
        {
            double totalScore = 0;

            Dictionary<string, double> scores = new Dictionary<string, double>
            {
                { "Quiz 1", 0 },
                { "Quiz 2", 0 },
                { "Quiz 3", 0 },
                { "Participation 1", 0 },
                { "Participation 2", 0 },
                { "Participation 3", 0 },
                { "Exam", 0 },
                { "Task Performance", 0 }
            };

            foreach (var kvp in scores)
            {
                bool isValidInput = false;
                do
                {
                    Console.Write($"Enter {kvp.Key} score: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out double score))
                    {
                        scores[kvp.Key] = score;
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input for {kvp.Key}. Please enter a numeric value.");
                    }
                } while (!isValidInput);
            }

            
            totalScore = scores.Values.Sum();

            return totalScore;
        }
       
        static void TryGetScore(string componentName, out double score)
        {
            score = 0;

            while (true)
            {
                Console.Write($"Enter {componentName} score: ");
                string input = Console.ReadLine();

                try
                {
                    score = double.Parse(input);
                    break; 
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid input for {componentName}. Please enter a numeric value.");
                }
            }
        }
    }
    }

