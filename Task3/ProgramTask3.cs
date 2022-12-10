using System;
using System.IO;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Task3
{
    class ProgramTask3
    {
        static void Main(string[] args)
        {
            string folderPath = "D:/Task3";

            if (Directory.Exists(folderPath)) // Проверим, что директория существует
            {
                Console.WriteLine("Папка найдена. Приступаю к оценке размера и удалению содержимого.");
                Thread.Sleep(3000);

                //Исходное состояние
                long quantityS = CalculateQuantity(folderPath);
                long sizeS = Task2.ProgramTask2.CalculateSize(folderPath);
                
                //Удаление
                Task1.ProgramTask1.DeleteFolderContent(folderPath);
                long quantityF = CalculateQuantity(folderPath);
                long sizeF = Task2.ProgramTask2.CalculateSize(folderPath);

                //Текущее состоянии
                Console.WriteLine();
                Console.WriteLine("Исходный размер папки составлял: {0} байт. В папке находилось {1} файлов.", sizeS, quantityS);
                Console.WriteLine("Удалено {0} файлов и освобождено {1} байт.", quantityS - quantityF, sizeS - sizeF);
                Console.WriteLine("Текущий размер папки: {0} байт. В папке находится {1} файлов.", sizeF, quantityF);
            }
            else
            {
                Console.WriteLine("Передан некорректный путь к папке для очистки.");
            }
            Console.ReadKey();
        }
        static long CalculateQuantity(string folderPath)
        {
            string[] folders = Directory.GetDirectories(folderPath);  // Получим все содержащиеся папки
            string[] files = Directory.GetFiles(folderPath); // Получим все содержащиеся файлы

            long quantity = 0;

            foreach (string file in files)
            {
                try
                {
                    quantity ++;
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
                    quantity += CalculateQuantity(folder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Не удалось посчитать размер папки {0}: {1}.", folder, ex);
                }
            }
            return quantity;
        }
    }
}