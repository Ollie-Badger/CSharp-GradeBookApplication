using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var dropCount = Students.Count / 20 * 100;
            List<double> averageGradesList = new List<double>();
            foreach (var student in Students)
            {
                averageGradesList.Add(student.AverageGrade);
            }

            averageGradesList.Sort();

            if (averageGrade <= dropCount)
                return 'A';
            else if (averageGrade <= dropCount *2)
                return 'B';
            else if (averageGrade <= dropCount *3)
                return 'C';
            else if (averageGrade <= dropCount *4)
                return 'D';
            else
                return 'F';
        }
    }
}
