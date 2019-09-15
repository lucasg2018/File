using Course.Entities;
using System;
using System.IO;

namespace Course {
    class Program {
        static void Main(string[] args) {

            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\Total";
                string targetFilePath = targetFolderPath + @"\summary.txt";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath)) {
                    foreach (string line in lines) {

                        string[] fields = line.Split(", ");
                        string name = fields[0];
                        double price = double.Parse(fields[1]);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine("Nome: " + prod.Name + " - Total:" + prod.Total());
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
