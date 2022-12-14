using System;
using System.IO;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Task1
{
    public class ProgramTask1
    {
        static void Main(string[] args)
        {
            string folderPath = "D:/Task1";

            if (Directory.Exists(folderPath)) // Проверим, что директория существует
            {
                Console.WriteLine("Папка найдена. Приступаю к удалению содержимого.");
                Console.WriteLine();
                DeleteFolderContent(folderPath);
            }
            else
            {
                Console.WriteLine("Передан некорректный путь к папке для очистки.");
            }
            Console.ReadKey();
        }
        public static void DeleteFolderContent(string folderPath)
        {
            string[] folders = Directory.GetDirectories(folderPath);  // Получим все содержащиеся папки
            string[] files = Directory.GetFiles(folderPath); // Получим все содержащиеся файлы

            if (folders.Length + files.Length == 0)
                Console.WriteLine("Папка пуста. Ничего удалять не потребовалось.");

            foreach (string file in files) // Удаление файлов
            {
                if (DateTime.Now - Directory.GetLastAccessTime(file) > TimeSpan.FromMinutes(30)) // Проверяем использовали ли файл посление 30 минут
                {
                    try
                    {
                        File.Delete(file);
                        Console.WriteLine("Файл {0} удален.", file);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Нет прав доступа на удаление файла {0}: {1}", file, ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Файлом {0} пользовались в течение последних 30 минут. Не удаляю.", file);
                }
            }
            foreach (string folder in folders)  // Удаление содержимого всех папок
            {
                try
                {
                    DeleteFolderContent(folder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Нет прав доступа на удаление содержимого папки {0}: {1}", folder, ex.Message);
                }
            }
            foreach (string folder in folders)  // Удаление пустых папок
            {
                    try
                    {
                        DirectoryInfo Folder = new DirectoryInfo(folder);
                        Folder.Delete();
                        Console.WriteLine("Папка {0} и ее содержимое удалены.", folder);
                        DeleteFolderContent(folder);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Нет прав доступа на удаление папки {0}: {1}", folder, ex.Message);
                    }
            }
        }
    }
}