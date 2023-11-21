using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ImageMirror
{
    class Program
    {
        static void Main(string[] args)
        {
            // Отримати поточну папку
            string directoryPath = Directory.GetCurrentDirectory();

            // Отримати усі файли з поточної папки
            string[] files = Directory.GetFiles(directoryPath);

            // Регулярний вираз для перевірки розширень файлів-зображень
            Regex regexExtForImage = new Regex("((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            foreach (string filePath in files)
            {
                try
                {
                    // Отримати розширення файлу
                    string fileExtension = Path.GetExtension(filePath);

                    // Перевірити, чи файл є графічним
                    if (regexExtForImage.IsMatch(fileExtension))
                    {
                        // Зчитати файл як зображення
                        using (Bitmap originalImage = new Bitmap(filePath))
                        {
                            // Створити дзеркальне відображення по вертикалі
                            originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                            // Створити нове ім'я для збереження
                            string newFileName = Path.GetFileNameWithoutExtension(filePath) + " - mirrored.gif";

                            // Зберегти як GIF-зображення
                            originalImage.Save(Path.Combine(directoryPath, newFileName), ImageFormat.Gif);

                            Console.WriteLine($"Файл {filePath} успішно оброблено та збережено як {newFileName}");
                        }
                    }
                    else
                    {
                        // Вивести повідомлення про те, що файл не є графічним
                        MessageBox.Show($"Файл {filePath} не містить зображення.");
                    }
                }
                catch (Exception ex)
                {
                    // Вивести повідомлення про помилку читання файлу як зображення
                    MessageBox.Show($"Помилка обробки файлу {filePath}: {ex.Message}");
                }
            }
        }
    }
}
