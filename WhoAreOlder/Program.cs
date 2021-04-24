using System;
using System.Collections.Generic;

namespace WhoAreOlder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> humanName = new List<string>();
            List<int> humanAge = new List<int>();
            //Первый человек
            humanName.Add(InputName());
            humanAge.Add(AgeIsInt(humanName[0]));
            //Второй человек
            humanName.Add(InputName());
            humanAge.Add(AgeIsInt(humanName[1]));

            //Проверка ввода пользователя на вопрос "Кто старше?", чтобы было введено одно из ранее введеных имен.
            string userChoise = UserChoise(humanName[0], humanName[1]);
            //Проверка правдивости ответа пользователя - старше или младше? И вывод если одногодки.
            CheckUserAnswer(userChoise, humanAge[0], humanAge[1], humanName[0], humanName[1]);
        }

        //Ввод данных
        static string InputName()
        {
            string humanName;
            do
            {
                Console.WriteLine("Enter the name of human: ");
                humanName = Console.ReadLine();
            }
            while (humanName.Length <= 0);
            return humanName;
        }

        //Проверка на ввод валидных данных возвраста
        static int AgeIsInt(string name)
        {
            int age;
            for (; ; )
            {
                bool AgeIsInt = false;
                Console.WriteLine($"Enter the age of the {name}: ");
                AgeIsInt = int.TryParse(Console.ReadLine(), out age);
                if (AgeIsInt == true && age>0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You entered incorrect data. Please, try again: ");
                }
            }
            return age;
        }

        //Проверка ввода пользователя на вопрос "Кто старше?", чтобы было введено одно из ранее введеных имен.
        static string UserChoise(string firstHumanName, string secondHumanName)
        {
            string userChoise;
            do
            {
                Console.WriteLine("\nWhat’s the older person’s name?");         // спрашиваем кто старше
                userChoise = Console.ReadLine();
            } while (userChoise != firstHumanName && userChoise != secondHumanName);
            return userChoise;
        }

        //Проверка правдивости ответа пользователя - старше или младше? И вывод если одногодки.
        static void CheckUserAnswer(string userChoise, int firstHumanAge, int secondHumanAge, string firstHumanName, string secondHumanName)
        {
            string checkName;
            int olderHuman;
            if (firstHumanAge > secondHumanAge)
            {
                olderHuman = firstHumanAge - secondHumanAge;
                checkName = firstHumanName;
                if (userChoise == checkName)
                {
                    Console.WriteLine("You are right! Age difference: " + olderHuman + "year(s)");
                }
                else
                {
                    Console.WriteLine("You are wrong! Correct answer is " + checkName + ". Age difference is " + olderHuman + " year(s).");
                }
            }
            else if (firstHumanAge < secondHumanAge)
            {
                olderHuman = secondHumanAge - firstHumanAge;
                checkName = secondHumanName;
                if (userChoise == checkName)
                {
                    Console.WriteLine("You are right! Age difference: " + olderHuman + "year(s)");
                }
                else
                {
                    Console.WriteLine("You are wrong! Correct answer is " + checkName + ". Age difference is " + olderHuman + " year(s).");
                }
            }
            else
            {
                Console.WriteLine("It is not possible to determine who is older, the age of the people is the same!");
            }
        }
    }
}
