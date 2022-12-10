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
    class ProgramTask4
    {
        static void Main(string[] args)
        {
            string filePath = "D:/Task4/Students.dat";
            DirectoryInfo dirInfo = new DirectoryInfo ("C:/Users/Nikita/Desktop/Students");

            if (File.Exists(filePath)) // Проверим, что файл существует
            {
                FileWorker.BinFileWorker(filePath, dirInfo);
            }
            else
            {
                Console.WriteLine("Передан некорректный путь к файлу для работы.");
            }
            
            Console.ReadKey();
        }


    }

}