using System;
using System.Collections.Generic;

namespace WorkWithPupilDiaries
{
    class PupilDiary
    {
        public string PupilName;
        // Списки с оценками.
        public List<double> MarksInMathematics = new List<double>();
        public List<double> MarksInReading = new List<double>();
        public List<double> MarksInNaturalHistory = new List<double>();
        public List<double> MarksInGym = new List<double>();
        public List<double> MarksInWriting = new List<double>();
        public List<double> PupilMarks = new List<double>();

        /// <summary>
        /// Добавление оценок в список.
        /// </summary>
        /// <param name="mark"> Оценка. </param>
        public void AddMarks(double mark, List<double> marks)
        {
            if (mark >= 1 && mark <= 10)
            {
                marks.Add(mark);
            }
            else
            {
                Console.WriteLine("Your enter is not correct. Try again!");
            }
        }

        /// <summary>
        /// Подсчет и вывод статистики.
        /// </summary>
        public void ShowStatistics(List<double> marks)
        {
            if (marks.Count > 0)
            {
                // Сумма всех оценок
                double sumMarks = 0.0;
                foreach (double markPupilElement in marks)
                {
                    sumMarks += markPupilElement;
                }
                PupilMarks.Sort();
                Console.WriteLine($"{PupilName}'s minimum score is {marks[0]}.\r\nMaximum score is {marks[marks.Count - 1]}. \r\nAverage score is {sumMarks / marks.Count}.\n");
            }
            else
            {
                Console.WriteLine("Your diary is empty.\n");
            }
        }

        /// <summary>
        /// Метод исправляет оценку по предмету.
        /// </summary>
        /// <param name="marks"> Список с оценками по предмету. </param>
        /// <param name="countElement"> Счетчик оценок (пронумерованные оценки). </param>
        /// <param name="mark"> Оценка. </param>
        /// <returns></returns>
        public List<double> CorrectMarkOnSubject(List<double> marks, int countElement, double mark)
        {
            marks[countElement - 1] = mark;
            return marks;
        }
    }
}
