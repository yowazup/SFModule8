using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Files
    {
        public static void FileRead()
        {
            string filePath = "D:/BinaryFile.bin"; // Укажем путь 
            if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
            {
                Console.WriteLine("Упс, файла нет...");
            }
            else
            {
                string stringValue;
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }
        }
        public static void FileWrite()
        {
            string filePath = "D:/BinaryFile.bin"; // Укажем путь 
            if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
            {
                Console.WriteLine("Упс, файла нет...");
            }
            else
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open("D:/BinaryFile.bin", FileMode.Open)))
                    writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
            }

        }
    }
}
