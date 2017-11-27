using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGrades
{
    class Program
    {

        static double LetterToNumberGrade(string strGrade)
        {
            switch (strGrade)
            {
                case "A+": return 4.33;
                case "A": return 4.0;
                case "A-": return 3.67;
                case "B+": return 3.33;
                case "B": return 3.0;
                case "B-": return 2.67;
                case "C+": return 2.33;
                case "C": return 2.0;
                case "C-": return 1.67;
                case "D+": return 1.33;
                case "D": return 1.0;
                case "D-": return 0.67;
                case "F": return 0;
                default:
                    throw new InvalidDataException("Unknown letter grade: " + strGrade);
            }
        }

        static void Main(string[] args)
        {
            string[] lineArray = File.ReadAllLines(@"grades.txt");
            foreach (String line in lineArray)
            {
                string [] splitOne = line.Split(':');
                // TODO: assert that slitOne.length is 2 exactly
                string name = splitOne[0];
                string[] gradeArray = splitOne[1].Split(',');
                // compute the sum of all GPA values of grades
                double sum = 0;
                foreach (String strGrade in gradeArray)
                {
                    double grade = LetterToNumberGrade(strGrade);
                    sum += grade;
                }
                double average = sum / gradeArray.Length;
                Console.WriteLine(@"{0}'s GPA is {1:2F}", name, average);
            }

            Console.ReadKey();
        }
    }
}
