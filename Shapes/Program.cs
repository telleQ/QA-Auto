using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            int shapeSize = ShapeSizeInput();
            int userChoise = UserChoiseShape();
            Console.WriteLine();

            //square
            if (userChoise == 1)
            {
                Square(shapeSize);
            }
            //triangle
            else if (userChoise == 2)
            {
                Triangle(shapeSize);
            }
            //inverted triangle
            else if (userChoise == 3)
            {
                InvertedTriangle(shapeSize);
            }
            //hourglass
            else
            {
                Hourglass(shapeSize);
            }
            Console.ReadLine();
        }

        //Ввод размера пользователя
        static int ShapeSizeInput()
        {
            Console.Write("Enter a shape size: ");
            int shapeSize = Convert.ToInt32(Console.ReadLine());
            return shapeSize;
        }

        //Выбор фигуры с проверкой на ввод числа от 1 до 4
        static int UserChoiseShape()
        {
            Console.WriteLine($@"You have to choose a shape:
                            square - enter 1
                            triangle - enter 2
                            inverted triangle - enter 3
                            hourglass - enter 4");
            int userChoise;
            do
            {
                Console.Write("Enter your choise: ");
                userChoise = Convert.ToInt32(Console.ReadLine());
            } while (userChoise <= 0 || userChoise >= 5);
            return userChoise;
        }

        static void Square(int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }

        static void Triangle(int size)
        {
            int columsCount = 1;
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < columsCount; column++)
                {
                    Console.Write("0 ");
                }
                Console.WriteLine();
                columsCount++;
            }
        }
        static void InvertedTriangle(int size)
        {
            int i, j, k;
            for (i = 1; i <= size; i += 2)
            {
                for (k = 1; k < i; k++)
                {
                    Console.Write(" ");
                }
                for (j = i; j <= size; j++)
                {
                    Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }

        static void Hourglass(int size)
        {
            int i, j, k;
            //Первая часть
            InvertedTriangle(size);
            //Вторая часть
            if (size % 2 != 0)                  //Если размер равен нечетному числу
            {
                for (i = size; i >= 1; i -= 2)
                {
                    for (k = 1; k < i; k++)
                    {
                        Console.Write(" ");
                    }
                    for (j = i; j <= size; j++)
                    {
                        Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
            }
            else if (size % 2 == 0)             //Если размер равен четному числу
            {
                for (i = size - 1; i >= 1; i -= 2)
                {
                    for (k = 1; k < i; k++)
                    {
                        Console.Write(" ");
                    }
                    for (j = i; j <= size; j++)
                    {
                        Console.Write("0 ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
