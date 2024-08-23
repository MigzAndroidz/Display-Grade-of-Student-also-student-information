using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTask
{
    internal class Student
    {
        public string StudentNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public int GradeLevel { get; set; }
        public char Gender { get; set; }
        public double Quiz1 { get; set; }
        public double Quiz2 { get; set; }
        public double Quiz3 { get; set; }
        public double Participation1 { get; set; }
        public double Participation2 { get; set; }
        public double Participation3 { get; set; }
        public double Exam { get; set; }
        public double TaskPerformance { get; set; }
        public double PT { get; set; } 
        public double TotalScoreQ1 { get; set; }
        public double TotalScoreQ2 { get; set; }
        public double TotalScoreQ3 { get; set; }
        public double TotalScoreQ4 { get; set; }





        private const double ParticipationWeight = 0.05;
        private const double QuizWeight = 0.15;
        private const double ExamWeight = 0.3;
        private const double PTWeight = 0.5;
        private const double ScoreNormalization = 50.0;
        private const double ScoreScaling = 10.0;

        public double CalculateParticipationScore()
        {
            double participationTotal = (Participation1 + Participation2 + Participation3) / ScoreScaling;
            double participationScore = (participationTotal * ScoreNormalization) + ScoreNormalization;
            return participationScore;
        }

        public double CalculateQuizScore()
        {
            double quizTotal = (Quiz1 + Quiz2 + Quiz3) / ScoreScaling;
            double quizScore = (quizTotal * ScoreNormalization) + ScoreNormalization;
            return quizScore;
        }

        public double CalculateOverallParticipationScore()
        {
            double overallParticipation = (CalculateParticipationScore() + CalculateQuizScore()) / 2.0;
            return overallParticipation * ParticipationWeight;
        }

        public double CalculateOverallQuizScore()
        {
            double overallQuizzes = CalculateQuizScore() * QuizWeight / 3.0;
            return overallQuizzes;
        }

        public double CalculateOverallExamScore()
        {
            double examScore = (Exam / 100.0 * ScoreNormalization) + ScoreNormalization;
            return examScore * ExamWeight;
        }

        public double CalculateOverallPTScore()
        {
            double ptScore = (PT / 100.0 * ScoreNormalization) + ScoreNormalization;
            return ptScore * PTWeight;
        }

        public double CalculateOverallGrade()
        {
            double overallParticipation = CalculateOverallParticipationScore();
            double overallQuizzes = CalculateOverallQuizScore();
            double overallExam = CalculateOverallExamScore();
            double overallPT = CalculateOverallPTScore();

            double totalScore = overallParticipation + overallQuizzes + overallExam + overallPT;

            return totalScore;
        }
        public double CalculateAndDisplayGrade()
        {
            double weightQuiz = 0.15;
            double weightParticipation = 0.05;
            double weightTaskPerformance = 0.5;
            double weightExam = 0.3;

            double totalScore = (Quiz1 * weightQuiz) +
                                (Participation1 * weightParticipation) +
                                (TaskPerformance * weightTaskPerformance) +
                                (Exam * weightExam);

            return totalScore;

          
        }
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Student Number: {StudentNumber}");
            Console.WriteLine($"Name: {Surname}, {FirstName} {MiddleInitial}.");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Grade Level: {GradeLevel}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Computer Programming 4  (1st Quarter): {TotalScoreQ1}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Computer Programming 4  (2nd Quarter): {TotalScoreQ2}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Computer Programming 5  (1st Quarter): {TotalScoreQ3}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Computer Programming 5 (2nd Quarter): {TotalScoreQ4}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
