using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Написать консольную игру "Крестики-нолики".Режим игры 1x1.

            //Переменные
            byte player = 2; 
            byte numberUser = 0; //Цифра введеная пользователем
            byte flag = 0; //Для остановки игры в случае неверного ввода пользователем
            byte turnPlayer = 0; //Ход игрока

            char[,] field = ArrayField();

            //Бесконечный цикл
            do
            {
                /* Для определения очередности хода */
                player = TurnPlayer(player);

                //заполнение цифр Х или 0 в зависимости от игрока чей ход происходит
                GetCell(player, numberUser, field);

                Console.Clear(); //очистка консоли
                Console.WriteLine($@"Tic-Tac-Toe
RULES:
    1.Player 1 is X, Player 2 is O. Players take turns putting their marks in empty squares.
    2.The first player to get 3 of her marks in a row(up, down, across, or diagonally) is the winner.
    3.When all 9 squares are full, the game is over.If no player has 3 marks in a row, the game ends in a tie.
                ");

                //Вывод массива с текущими значениями
                turnPlayer = OutputArrayWithCurrentValues(field, turnPlayer);

                char symbolZero = '0';
                char symbolX = 'X';

                if(WhoWin(field, symbolZero))
                {
                    Console.WriteLine("\nPlayer 2 is winner!");
                    Console.ReadLine();
                    break;
                }
                else if (WhoWin(field, symbolX))
                {
                    Console.WriteLine("\nPlayer 1 is winner!");
                    Console.ReadLine();
                    break;
                }
                else if (ResultTie(turnPlayer))
                {
                    break;
                }

                //Проверить, занято ли уже выбранное число на поле (например если 4 уже занято, то повторно походить на то же место невозможно)
                numberUser = UserChoise(flag, player, numberUser, field);
            } while (true);
        }

        static char[,] ArrayField()
        {
            char[,] field =
            {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
            return field;
        }

        static byte TurnPlayer(byte player)
        {
            /* Для определения очередности хода */
            if (player == 2)                        //Игрок №1 начинает игру
            {
                player = 1;
            }
            else if (player == 1)                   //Игрок №2 начинает игру
            {
                player = 2;
            }
            return player;
        }

        static char[,] GetCell(byte player, byte numberUser, char[,] field)
        {
            switch (player)
            {
                case 1: // Игрок 1, который в свой ход ставит Х
                    {
                        switch (numberUser)
                        {
                            case 1:
                                field[0, 0] = 'X';
                                break;
                            case 2:
                                field[0, 1] = 'X';
                                break;
                            case 3:
                                field[0, 2] = 'X';
                                break;
                            case 4:
                                field[1, 0] = 'X';
                                break;
                            case 5:
                                field[1, 1] = 'X';
                                break;
                            case 6:
                                field[1, 2] = 'X';
                                break;
                            case 7:
                                field[2, 0] = 'X';
                                break;
                            case 8:
                                field[2, 1] = 'X';
                                break;
                            case 9:
                                field[2, 2] = 'X';
                                break;
                        }
                        break;
                    }

                case 2: // Игрок 2, который в свой ход ставит 0
                    {
                        switch (numberUser) // 
                        {
                            case 1:
                                field[0, 0] = '0';
                                break;
                            case 2:
                                field[0, 1] = '0';
                                break;
                            case 3:
                                field[0, 2] = '0';
                                break;
                            case 4:
                                field[1, 0] = '0';
                                break;
                            case 5:
                                field[1, 1] = '0';
                                break;
                            case 6:
                                field[1, 2] = '0';
                                break;
                            case 7:
                                field[2, 0] = '0';
                                break;
                            case 8:
                                field[2, 1] = '0';
                                break;
                            case 9:
                                field[2, 2] = '0';
                                break;
                        }
                        break;
                    }
            }
            return field;
        }
        static byte OutputArrayWithCurrentValues(char[,] field, byte turnPlayer)
        {
                        //Вывод массива с текущими значениями
            Console.WriteLine("-------------");
            Console.WriteLine("| {0} | {1} | {2} |", field[0, 0], field[0, 1], field[0, 2]);
            Console.WriteLine("----+---+---- ");
            Console.WriteLine("| {0} | {1} | {2} |", field[1, 0], field[1, 1], field[1, 2]);
            Console.WriteLine("----+---+---- ");
            Console.WriteLine("| {0} | {1} | {2} |", field[2, 0], field[2, 1], field[2, 2]);
            Console.WriteLine("-------------");
            turnPlayer++; // Счетчик ходов
            return turnPlayer;
        }

        /// <summary>
        /// Окончание игры и вывод результата об игроке победителе
        /// </summary>
        /// <param name="field">игровое поле</param>
        /// <param name="symbol">символ заполнения ячейки поля (0 или Х)</param>
        /// <returns></returns>
        static bool WhoWin(char[,] field, char symbol)
        {
            bool result = false;
            if (
                    (field[0, 0] == symbol && field[0, 1] == symbol && field[0, 2] == symbol) ||
                    (field[1, 0] == symbol && field[1, 1] == symbol && field[1, 2] == symbol) ||
                    (field[2, 0] == symbol && field[2, 1] == symbol && field[2, 2] == symbol) ||
                    (field[0, 0] == symbol && field[1, 0] == symbol && field[2, 0] == symbol) ||
                    (field[0, 1] == symbol && field[1, 1] == symbol && field[2, 1] == symbol) ||
                    (field[0, 2] == symbol && field[1, 2] == symbol && field[2, 2] == symbol) ||
                    (field[0, 0] == symbol && field[1, 1] == symbol && field[2, 2] == symbol) ||
                    (field[0, 2] == symbol && field[1, 1] == symbol && field[2, 0] == symbol)
                )
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Окончание игры и вывод результата в случае ничьей
        /// </summary>
        /// <param name="turnPlayer">ход игрока</param>
        /// <returns></returns>
        static bool ResultTie(byte turnPlayer)
        {
            bool result = false;
            if (turnPlayer == 10)
            {
                result = true;
                Console.WriteLine("\nTie!");
                Console.ReadLine();
            }
            else
            {
                result = false;
            }
            return result;
        }

        static byte UserChoise(byte flag, byte player, byte numberUser, char[,] field)
        {
            do
            {
                Console.Write("\nPlayer {0} enter a number from the table: ", player);

                //Проверка на ввод цифр/строки, если строка - отобразит ошибку и попросит ввести корректно цифру
                bool isNumberUser = Byte.TryParse(Console.ReadLine(), out numberUser);
                while (!isNumberUser)
                {
                    Console.Write("You entered incorrect data! Please, enter correct number: ");
                    isNumberUser = Byte.TryParse(Console.ReadLine(), out numberUser);
                }

                if (numberUser == 1 && field[0, 0] == '1')
                {
                    flag = 0;
                }
                else if (numberUser == 2 && field[0, 1] == '2')
                {
                    flag = 0;
                }
                else if (numberUser == 3 && field[0, 2] == '3')
                {
                    flag = 0;
                }
                else if (numberUser == 4 && field[1, 0] == '4')
                {
                    flag = 0;
                }
                else if (numberUser == 5 && field[1, 1] == '5')
                {
                    flag = 0;
                }
                else if (numberUser == 6 && field[1, 2] == '6')
                {
                    flag = 0;
                }
                else if (numberUser == 7 && field[2, 0] == '7')
                {
                    flag = 0;
                }
                else if (numberUser == 8 && field[2, 1] == '8')
                {
                    flag = 0;
                }
                else if (numberUser == 9 && field[2, 2] == '9')
                {
                    flag = 0;
                }
                //В случае неверного ввода или ввода цифры, где уже проставлено 0 или Х, выводит ошибку и предлагает повторить попытку
                else
                {
                    Console.WriteLine("\nError. Try again!");
                    flag = 1;
                }
            } while (flag == 1);

            return numberUser;
        }
    }
}
