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
                    dirInfo.Delete();
                }
                dirInfo.Create();
                Console.WriteLine("Папка {0} создана.", dirInfo);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                File.Create(fileName);
                Console.WriteLine("Файл группы {0} создан в директории {1}.", groupName, dirInfo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
