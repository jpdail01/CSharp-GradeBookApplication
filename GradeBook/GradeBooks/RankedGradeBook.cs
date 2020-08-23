namespace GradeBook.GradeBooks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GradeBook.Enums;

    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            /*
             * One way to solve this is to figure out how many students make up 20%, 
             * then loop through all the grades and check how many scored higher than 
             * the input average, every N students where N is that 20% value, drop a 
             * letter grade.)
             */

            var twentyPercentOfStudents = Math.Floor(Students.Count * .20);
            var grades = new List<double>();

            foreach (var student in Students)
            {
                foreach (var studentGrade in student.Grades)
                {
                    grades.Add(studentGrade); 
                }
            }

            var orderedGrades = grades.OrderByDescending(g => g);
            double levels = 0;
            foreach (var orderedGrade in orderedGrades)
            {
                if (orderedGrade > averageGrade)
                {
                    levels++;
                }
            }

            levels = Math.Floor(levels / twentyPercentOfStudents);
            
            if (levels == 0)
                return 'A';
            else if (levels == 1)
                return 'B';
            else if (levels == 2)
                return 'C';
            else if (levels == 3)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}