using System.Diagnostics;

namespace ReadingAndWritingOnFileSystemHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //*************************************
            //Task1

            string filePath = "c:\\Users\\attil\\source\\repos\\ReadingAndWritingOnFileSystemHW\\ReadingAndWritingOnFileSystemHW\\Documents\\TextFile.txt";

            List<string> textFileStringList = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string lineContent;

                while ((lineContent = sr.ReadLine()) != null)
                {
                    textFileStringList.Add(lineContent);
                }


            }

            Console.WriteLine("Please enter text for search:");
            string stringForSearch = Console.ReadLine();

            var result = textFileStringList.Where(s => s.Contains(stringForSearch)).ToList();

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            //*************************************
            //Task2

            string appPath = "c:\\Users\\attil\\source\\repos\\ReadingAndWritingOnFileSystemHW\\ReadingAndWritingOnFileSystemHW\\bin\\Debug\\net6.0";

            string newFolder = appPath + "\\Exercise";

            if (Directory.Exists(newFolder) == false)
            {
                Directory.CreateDirectory(newFolder);
            }

            string newFilePath = newFolder + "\\calculations.txt";

            if (File.Exists(newFilePath) == false)
            {
                File.Create(newFilePath).Close();
            }

            int counter = 0;

            while (counter < 3)
            {

                Console.WriteLine("Enter first number:");

                int number1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number:");

                int number2 = int.Parse(Console.ReadLine());

                string result = CalculationMethod(number1, number2);

                Console.WriteLine(result);

                using (StreamWriter sw = new StreamWriter(newFilePath, true))
                {
                    sw.WriteLine($"{result}; Time:{DateTime.Now}");
                }

                counter++;
            }
        }

        public static string CalculationMethod(int number1, int number2)
        {
            return $"{number1} + {number2} = {number1 + number2}";
        }
    }
    }
}