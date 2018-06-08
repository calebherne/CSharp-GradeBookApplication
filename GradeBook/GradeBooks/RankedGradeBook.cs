using GradeBook.Enums;
using System;
using System.Linq;

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
                throw new InvalidOperationException("Ranked grading requires at leasht 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * .2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold - 1) * 2] <= averageGrade)
                return 'B';
            else if (grades[(threshold - 1) * 3] <= averageGrade)
                return 'C';
            else if (grades[(threshold - 1) * 4] <= averageGrade)
                return 'D';
            else
                return 'F';
            return base.GetLetterGrade(averageGrade);
        }
    }
}
