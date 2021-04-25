using System;

namespace WorkWithPupilDiaries
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string pupilName = Menu.AskPupilName();
            // Создаем экземпляр класса PupilDiary.
            PupilDiary diary = new PupilDiary();
            diary.PupilName = pupilName;

            while (true)
            {
                //Вывод меню с пунктами: добавить оценку, показать статистику, исправить оценку или выйти из программы.
                string menuPoint = Menu.AskMainMenuPoint();

                Console.Clear();
                switch (menuPoint)
                {
                    // Выбор предмета из списка меню.
                    case "1":
                        string menuPointWithSubject = Menu.AskSubjectPoint();

                        Console.Clear();
                        switch (menuPointWithSubject)
                        {
                            case "1":
                                double pupilMark = Menu.ReadMark();
                                diary.AddMarks(pupilMark, diary.MarksInMathematics);
                                diary.AddMarks(pupilMark, diary.PupilMarks);
                                break;
                            case "2":
                                pupilMark = Menu.ReadMark();
                                diary.AddMarks(pupilMark, diary.MarksInReading);
                                diary.AddMarks(pupilMark, diary.PupilMarks);
                                break;
                            case "3":
                                pupilMark = Menu.ReadMark();
                                diary.AddMarks(pupilMark, diary.MarksInNaturalHistory);
                                diary.AddMarks(pupilMark, diary.PupilMarks);
                                break;
                            case "4":
                                pupilMark = Menu.ReadMark();
                                diary.AddMarks(pupilMark, diary.MarksInGym);
                                diary.AddMarks(pupilMark, diary.PupilMarks);
                                break;
                            case "5":
                                pupilMark = Menu.ReadMark();
                                diary.AddMarks(pupilMark, diary.MarksInWriting);
                                diary.AddMarks(pupilMark, diary.PupilMarks);
                                break;
                            case "6":
                                break;
                            default:
                                Menu.ShowInvalidMenuPointText();
                                break;
                        }
                        break;

                    // Вывод меню с пунктами: вывод статистики, возврат в предыдущее меню, выход с программы.
                    case "2":
                        string menuPointSubjectWithStatistic = Menu.AskStatisticPoint();
                        Console.Clear();
                        switch (menuPointSubjectWithStatistic)
                        {
                            case "1":
                                diary.ShowStatistics(diary.MarksInMathematics);
                                break;
                            case "2":
                                diary.ShowStatistics(diary.MarksInReading);
                                break;
                            case "3":
                                diary.ShowStatistics(diary.MarksInNaturalHistory);
                                break;
                            case "4":
                                diary.ShowStatistics(diary.MarksInGym);
                                break;
                            case "5":
                                diary.ShowStatistics(diary.MarksInWriting);
                                break;
                            case "6":
                                diary.ShowStatistics(diary.PupilMarks);
                                break;
                            // Возвращает в предыдущее меню.
                            case "7":
                                break;
                            // Выйти из программы.
                            case "8":
                                return;
                            default:
                                Menu.ShowInvalidMenuPointText();
                                break;
                        }
                        break;

                    // Исправление ранее поставленных оценок по предметам.
                    case "3":
                        string _menuPointWithSubject = Menu.AskSubjectPoint();
                        // Номер оценки по списку.
                        int numberMark;
                        // Новая оценка взамен старой.
                        double newMark;
                        Console.Clear();
                        switch (_menuPointWithSubject)
                        {
                            case "1":
                                if (Menu.ShowMarkOfSubject(diary.MarksInMathematics))
                                {
                                    Menu.ShowMarkOfSubject(diary.MarksInMathematics);
                                    numberMark = Menu.AskNumberMark(diary.MarksInMathematics);
                                    newMark = Menu.ReadMark();
                                    diary.CorrectMarkOnSubject(diary.MarksInMathematics, numberMark, newMark);
                                    Console.Clear();
                                    Menu.ShowTitleOfCorrectMarks();
                                    Menu.ShowMarkOfSubject(diary.MarksInMathematics);
                                }
                                break;
                            case "2":
                                if (Menu.ShowMarkOfSubject(diary.MarksInReading))
                                {
                                    Menu.ShowMarkOfSubject(diary.MarksInReading);
                                    numberMark = Menu.AskNumberMark(diary.MarksInReading);
                                    newMark = Menu.ReadMark();
                                    diary.CorrectMarkOnSubject(diary.MarksInReading, numberMark, newMark);
                                    Console.Clear();
                                    Menu.ShowTitleOfCorrectMarks();
                                    Menu.ShowMarkOfSubject(diary.MarksInReading);
                                }
                                break;
                            case "3":
                                if (Menu.ShowMarkOfSubject(diary.MarksInNaturalHistory))
                                {
                                    Menu.ShowMarkOfSubject(diary.MarksInNaturalHistory);
                                    numberMark = Menu.AskNumberMark(diary.MarksInNaturalHistory);
                                    newMark = Menu.ReadMark();
                                    diary.CorrectMarkOnSubject(diary.MarksInNaturalHistory, numberMark, newMark);
                                    Console.Clear();
                                    Menu.ShowTitleOfCorrectMarks();
                                    Menu.ShowMarkOfSubject(diary.MarksInNaturalHistory);
                                }
                                break;
                            case "4":
                                if (Menu.ShowMarkOfSubject(diary.MarksInGym))
                                {
                                    Menu.ShowMarkOfSubject(diary.MarksInGym);
                                    numberMark = Menu.AskNumberMark(diary.MarksInGym);
                                    newMark = Menu.ReadMark();
                                    diary.CorrectMarkOnSubject(diary.MarksInGym, numberMark, newMark);
                                    Console.Clear();
                                    Menu.ShowTitleOfCorrectMarks();
                                    Menu.ShowMarkOfSubject(diary.MarksInGym);
                                }
                                break;
                            case "5":
                                if (Menu.ShowMarkOfSubject(diary.MarksInWriting))
                                {
                                    Menu.ShowMarkOfSubject(diary.MarksInWriting);
                                    numberMark = Menu.AskNumberMark(diary.MarksInWriting);
                                    newMark = Menu.ReadMark();
                                    diary.CorrectMarkOnSubject(diary.MarksInWriting, numberMark, newMark);
                                    Console.Clear();
                                    Menu.ShowTitleOfCorrectMarks();
                                    Menu.ShowMarkOfSubject(diary.MarksInWriting);
                                }
                                break;
                            case "6":
                                break;
                            default:
                                Menu.ShowInvalidMenuPointText();
                                break;
                        }
                        break;
                    // Выйти из программы.
                    case "4":
                        return;
                    // Если пользователь совершает неправильный выбор, то выводит ошибку.
                    default:
                        Menu.ShowInvalidMenuPointText();
                        break;
                }
            }
        }
    }
}
