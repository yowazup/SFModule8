using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFModule8
{
    public class Folder
    {

        static void GetCatalogs()
        {
            try
            {
                string dirName = "C:/Users/Nikita/Desktop/NewDirectory"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    Console.WriteLine("Папки:");
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                    foreach (string d in dirs) // Выведем их все
                        Console.WriteLine(d);

                    Console.WriteLine();
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                    foreach (string s in files)   // Выведем их все
                        Console.WriteLine(s);

                    Console.WriteLine();
                    Console.WriteLine(Directory.GetDirectories(dirName).Length + Directory.GetFiles(dirName).Length);
                    Console.WriteLine();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CreateFolder()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:/Users/Nikita/Desktop/NewDirectory");
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    dirInfo.CreateSubdirectory("New Folder.");
                    Console.WriteLine("Каталог создан.");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeleteFolder()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:\\NewDirectory");
                dirInfo.Delete(true); // Удаление со всем содержимым
                Console.WriteLine("Каталог удален.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MoveFolder()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:/Users/Nikita/Desktop/NewDirectory");
                string newPath = "C:/Users/Nikita/Desktop/SkillFactory";

                if (dirInfo.Exists && !Directory.Exists(newPath))
                    dirInfo.MoveTo(newPath);
                Console.WriteLine("Каталог перемещен.");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MoveBin()
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo("C:/Users/Nikita/Desktop/NewDirectory");

                if (dirInfo.Exists && !Directory.Exists("C:/$RECYCLE. BIN"))
                    dirInfo.MoveTo("C:/$RECYCLE. BIN");
                Console.WriteLine("Каталог отдыхает в корзине.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
