using LAB3ZAV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main()
        {
            File[] Files = new File[20];
            int choice;
            do
            {
                Console.WriteLine("1.Створити Файли");
                Console.WriteLine("2.Прочитати файли");
                Console.WriteLine("3.Середнє арефметичне");
                Console.WriteLine("Для виходу з програми введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int g = File.Generate();
                        break;
                    case 2:
                        for (int i = 10; i <= 29; i++)
                        {
                            string filename = $"{i}.txt";
                            File textFile = new File(filename);
                            string fileData = textFile.ReadText();
                            Files[i - 10] = textFile;
                        }
                        break;
                    case 3:
                        int sum = File.Calculate(Files);
                        Console.WriteLine($"Середнє арифметичне добутків: {sum}");
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                        break;
                    default:
                        Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2, 3, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }
    }

}