using System;
using System.IO;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Task2
{
    public class ProgramTask2
    {
        static void Main(string[] args)
        {
            string folderPath = "D:/Program files";

            if (Directory.Exists(folderPath)) // Проверим, что директория существует
            {
                Console.WriteLine("Папка найдена. Приступаю к расчету размера содержимого папки.");
                Console.WriteLine();
                Console.WriteLine("Размер содержимого в папке составляет: {0} байт", CalculateSize(folderPath));
            }
            else
            {
                Console.WriteLine("Передан некорректный путь к папке для расчета размера содежимого.");
            }
            Console.ReadKey();
        }
        public static long CalculateSize(string folderPath)
        {
            string[] folders = Directory.GetDirectories(folderPath);  // Получим все содержащиеся папки
            string[] files = Directory.GetFiles(folderPath); // Получим все содержащиеся файлы

            long size = 0;

            foreach (string file in files)
            {
                try
                {
                    size += file.Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось посчитать размер файла {0}: {1}.", file, ex);
                }
            }
            foreach (string folder in folders) // рекурсия по дереву папок
            {
                try
                {
                    size += CalculateSize(folder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось посчитать размер папки {0}: {1}.", folder, ex);
                }
            }
            return size;
        }
    }
}