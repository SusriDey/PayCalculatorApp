using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OO_programming
{

    /// <summary>
    ///  Basic class to start my program
    ///  
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Entery point for my application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //ReadFile();
            //WriteToFile();
     
            Application.Run(new Form1());
        }

        /// <summary>
        /// Read a file passed in by the user.
        /// </summary>
        private static void ReadFile()
        {
            //Store the file location in a variable.
            string filePath = @"\\..\\employee.csv";

            //Check if the file exists 
            if (File.Exists(filePath))
            {
                //read the file
                StreamReader sr = new StreamReader(File.OpenRead(filePath));
                List<string> employeeList = new List<string>();

                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    foreach (var item in values)
                    {
                        employeeList.Add(item);
                    }

                    foreach (var c in employeeList)
                    {
                        Console.WriteLine(c);
                    }
                }

            }
            else
            {
                Console.WriteLine("File can not be found");
            }
        }

        /// <summary>
        /// Create a CSV file if it does not exists otherwise 
        /// notify the user the file does not exists.
        /// </summary>
        private static void WriteToFile()
        {
            //Create a file named partsCatalogue in the app directory
            string fileName = "..\\..\\PartsCatalogue.csv";

            if (!File.Exists(fileName))
            {
                //Use the enviroment to fetch the carriage return on 
                //the used Operating system.
                string newLine = Environment.NewLine;

                //Create the CSV file header fields
                string header = "\"CarMake\",\"Model\"" + newLine;

                //Insert a new row with the following details.
                string rowData = "\"Ford\",Focus" + newLine;

                //Write the data to the CSV File
                File.WriteAllText(fileName, header);

                File.AppendAllText(fileName, rowData);

                Console.WriteLine("Writing to file is completed");

            }
            else
            {
                Console.WriteLine("File already exists");
            }

        }
    }

}