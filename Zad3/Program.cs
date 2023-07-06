// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj rozmiar tablicy (liczba wierszy i kolumn):");
        int Size;

        while (!int.TryParse(Console.ReadLine(), out Size) || Size <= 0)
        {
            Console.WriteLine("Niepoprawna wartość. Podaj poprawny rozmiar tablicy:");
        }

        int[,] tablica = new int[Size, Size];

        int currentCol = 0;
        int currentRow = 0;
        int direction = 0; // 0 - prawo; 1 - dół; 2 - lewo; 3 - góra

        for (int currentNumber = 1; currentNumber <= Size * Size; currentNumber++)
        {
            tablica[currentRow, currentCol] = currentNumber;
            switch (direction)
            {
                case 0: //right
                    if (currentCol + 1 >= Size || tablica[currentRow, currentCol + 1] != 0)
                    {
                        direction = 1;
                        currentRow++;
                    }
                    else
                    {
                        currentCol++;
                    }
                    break;
                case 1: //down
                    if (currentRow + 1 >= Size || tablica[currentRow + 1, currentCol] != 0)
                    {
                        direction = 2;
                        currentCol--;
                    }
                    else
                    {
                        currentRow++;
                    }
                    break;
                case 2: //left
                    if (currentCol - 1 < 0 || tablica[currentRow, currentCol - 1] != 0)
                    {
                        direction = 3;
                        currentRow--;
                    }
                    else
                    {
                        currentCol--;
                    }
                    break;
                case 3: //up
                    if (tablica[currentRow - 1, currentCol] != 0)
                    {
                        direction = 0;
                        currentCol++;
                    }
                    else
                    {
                        currentRow--;
                    }
                    break;
                default:
                    break;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < 10; j++)
                {
                    tablica[i, j] = 10 * i + j + 1;
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    tablica[i, j] = 10 * (i + 1) - j;
                }
            }
        }
        Console.WriteLine("Tablica{0}x{0}:", Size);

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write("{0,3} ", tablica[i, j]);
            }
            Console.WriteLine();

        }
        Console.ReadLine();
    }
}

