using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3ZAV1
{
    internal class File
    {
        private string filename;
        private int num1;
        private int num2;
        public File(string filename)
        {
            this.filename = filename;
        }
        public int Num1
        {
            get
            {
                return num1;
            }
            set
            {
                num1 = value;
            }
        }
        public int Num2
        {
            get
            {
                return num2;
            }
            set
            {
                num2 = value;
            }
        }

        public static int Generate()
        {

            for (int i = 10; i <= 29; i++)
            {
                string fileName = i + ".txt";
                int num1, num2;
                try
                {
                    num1 = GenerateRandomNumber();
                    num2 = GenerateRandomNumber();
                    
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(num1);
                        writer.WriteLine(num2);
                    }

                    Console.WriteLine($"Created and populated file {fileName}");
                }
                
                catch (IOException e)
                {
                    Console.WriteLine($"Помилка при записі в файл '{fileName}': {e.Message}");
                }

            }
            Console.WriteLine("All files created and populated successfully.");
            return 0;

        }
        static int GenerateRandomNumber()
        {

            Random random = new Random();
            return random.Next(10, 99);
        }
        
        public string ReadText()
        {
            string line1 = null;
            string line2 = null;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    line1 = reader.ReadLine();
                    line2 = reader.ReadLine();
                }
            }
            catch (FileNotFoundException e)
            {
                //no_file.txt
                Console.WriteLine($"Помилка, файл '{filename}' відсутній: {e.Message}");
                return null;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Помилка при зчитуванні з файлу '{filename}': {e.Message}");
                return null;
            }

            try
            {
                Num1 = int.Parse(line1);
                Num2 = int.Parse(line2);
                string result = $"{Num1}\n{Num2}";
                Console.WriteLine($"Прочитано два числа з файлу '{filename}'");
                return result;
            }
            catch (FormatException)
            {
                //bad_data.txt
                Console.WriteLine($"Помилка,файл '{filename}': перший або другий рядок не містить два цілих числа.");
                return null;
            }
            catch (OverflowException)
            {
                //overflow.txt
                Console.WriteLine($"Помилка,файл '{filename}': переповнений значенями при перетворенні рядка на ціле число.");
                return null;
            }
        }
        public static int Calculate(File[] textFiles)
        {
            long totalsum = 0;
            int FilesWithData = 0;
            foreach (var textFile in textFiles)
            {
                int num1 = textFile.Num1;
                int num2 = textFile.Num2;
                try
                {
                    checked
                    {
                        int sum = num1 * num2;
                        totalsum += sum;
                        FilesWithData++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Переповнення значення при обчисленні добутку.");
                }
            }
            try
            {
                int averagesum = (int)totalsum / FilesWithData;
                return averagesum;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Помилка: ділення на нуль.");
                return 0;
            }
        }

    }
}
