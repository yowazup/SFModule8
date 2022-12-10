using System;
using System.IO;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace FinalTask
{
    public class FileWorker
    {
        public static void BinFileWorker(string filePath, DirectoryInfo dirInfo)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                Student[] Students = (Student[])formatter.Deserialize(fs);
                Console.WriteLine("Файл прочитан.");
                Console.WriteLine();

                CreateFolder(dirInfo);

                var groups = Students.GroupBy(x => x.Group);
                
                foreach (var group in groups)
                {
                    string FilePath = $"{dirInfo}/{group.Key}";
                    CreateFile(dirInfo, FilePath, group.Key);

                    foreach (var student in group)
                    {
                        FileWrite(FilePath, student.Name, student.DateOfBirth);
                    }
                    Console.WriteLine(); // для разделения между группами
                }
            }
        }
        static void CreateFolder(DirectoryInfo dirInfo)
        {
            try
            {
                if (dirInfo.Exists)
                {
                    dirInfo.Delete(true);
                }
                dirInfo.Create();
                Console.WriteLine("Папка {0} создана.", dirInfo);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Папку {0} создать не удалось: {1}.", dirInfo, ex.Message);
            }
        }
        static void CreateFile(DirectoryInfo dirInfo, string fileName, string groupName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                else
                {
                    using(FileStream fs = File.Create(fileName))
                    Console.WriteLine("Файл группы {0} создан в директории {1}.", groupName, dirInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Файл гурппы {0} создать не удалось: {1}.", groupName, ex.Message);
            }
        }
        public static void FileWrite(string fileName, string studentName, DateTime studentDateOfBirth)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Упс, файла нет...");
            }
            else
            {
                try
                {

                    using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Open)))
                    {
                        writer.Write($"{studentName} --- {studentDateOfBirth}");
                        Console.WriteLine("Студент {0} --- {1} в файл занесен.", studentName, studentDateOfBirth);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Студента {0} занести не удалось: {1}.",studentName, ex.Message);
                }
            }
        }
    }
}
