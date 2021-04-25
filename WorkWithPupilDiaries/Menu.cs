using System;
using System.Collections.Generic;

namespace WorkWithPupilDiaries
{
    static class Menu
    {
        private static PupilDiary _diary = new PupilDiary();

        /// <summary>
        /// Основное меню. Спрашивает пользователя какую опцию меню хочет выбрать.
        /// </summary>
        /// <returns> Возвращает пункт меню, который выбрал пользователь. </returns>
        public static string AskMainMenuPoint()
        {
            Console.WriteLine($@"Please select an option (what do you want to do):
1 - if you want to add a score to diary;
2 - if you want program to show statistic (max, min, average score);
3 - if you want to correct a score;
4 - if you want to exit this program.");

            return Console.ReadLine();
        }

        /// <summary>
        /// Спрашивает имя ученика.
        /// </summary>
        /// <returns> Возвращает строку, которую ввел пользователь. </returns>
        public static string AskPupilName()
        {
            Console.WriteLine("Please, enter a pupil's name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Выводит ошибку при выборе несуществующего пункта меню.
        /// </summary>
        public static void ShowInvalidMenuPointText()
        {
            Console.WriteLine("Please provide a valid data!\n");
        }

        /// <summary>
        /// Выбор предмета из меню с предметами.
        /// </summary>
        /// <returns> Возвращаем строку c выбором пользователя. </returns>
        public static string AskSubjectPoint()
        {
            Console.WriteLine($@"Please, select a subject from list:
1 - mathematics;
2 - reading; 
3 - natural history;
4 - gym;
5 - writing;
6 - go to the previous menu.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Меню со статистикой. Спрашивает пользователя какую опцию хочет выбрать.
        /// </summary>
        /// <returns> Возвращаем строку c выбором пользователя. </returns>
        public static string AskStatisticPoint()
        {
            Console.WriteLine($@"Please, select an option:
1 - show statistics in mathematics;
2 - show statistics in reading; 
3 - show statistics in natural history;
4 - show statistics in gym;
5 - show statistics in writing;
6 - show general statistic;
7 - go to the previous menu;
8 - exit this program.");
            return Console.ReadLine();
        }

        /// <summary>
        /// Показывает оценки по конкретному предмету.
        /// </summary>
        /// <param name="subjects"> Список предметов с оценками. </param>
        public static bool ShowMarkOfSubject(List<double> subjects)
        {
            bool ifDiaryIsEmpty = false;
            if (subjects.Count >= 1)
            {
                // Нумерация списка оценок.
                int countElement = 1;
                foreach (double markElement in subjects)
                {
                    Console.WriteLine("Mark " + countElement + ": " + markElement);
                    countElement++;
                }
                ifDiaryIsEmpty = true;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Your diary is empty.\n");
                ifDiaryIsEmpty = false;
            }
            return ifDiaryIsEmpty;
        }

        /// <summary>
        /// Спрашивает номер оценки, которую пользователь хочет исправить.
        /// </summary>
        /// <param name="subjects"> Список предметов с оценками. </param>
        /// <returns> Номер оценки. </returns>
        public static int AskNumberMark(List<double> subjects)
        {
            int numberMark;
            bool isInputCorrect = false;
            do
            {
                Console.WriteLine("Enter the mark number you want to change: ");
                isInputCorrect = int.TryParse(Console.ReadLine(), out numberMark);
                if (isInputCorrect == true && numberMark <= subjects.Count)
                {
                    break;
                }
                else
                {
                    ShowInvalidMenuPointText();
                }
            } while (true);
            return numberMark;
        }

        /// <summary>
        /// Спрашивает оценку от 1 до 10.
        /// </summary>
        /// <returns> Оценка. </returns>
        public static double ReadMark()
        {
            double mark;
            bool isInputCorrect = false;
            do
            {
                Console.WriteLine("Please, enter a mark range from 1 to 10: ");
                isInputCorrect = double.TryParse(Console.ReadLine(), out mark);
                if (isInputCorrect == true && mark >= 1 && mark <= 10)
                {
                    break;
                }
                else
                {
                    ShowInvalidMenuPointText();
                }
            } while (true);
            return mark;
        }
        /// <summary>
        /// Показывает уведомление перед списком с исправленными оценками.
        /// </summary>
        public static void ShowTitleOfCorrectMarks()
        {
            Console.WriteLine("Diary with corrected marks:\n");
        }
    }
}
