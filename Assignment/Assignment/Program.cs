using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Assignment
{
    internal class Program
    {
        static readonly string textFile = @"G:\SimpliLearn\Assignments\Read from Text File with Searching and Sorting\Assignment\StudentDetails.txt";
        static void Main(string[] args)
        {
            bool flag = true;
            var StudentDetails = new Dictionary<string, int>();
            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        string[] student = ln.Split(',');
                        StudentDetails.Add(student[0], int.Parse(student[1]));
                    }
                    file.Close();
                }
            }
            while (flag)
            {
                Console.WriteLine("Student Details Read from file.\n\nChoose from the below operations\n1.Display unsorted Data\n2.Sort data by Name and display\n3.Sort data by Class and display\n4.Search by Name");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            foreach (KeyValuePair<string, int> student in StudentDetails)
                            {
                                Console.WriteLine("Name: {0}, Class: {1}", student.Key, student.Value);
                            }
                        }
                        break;
                    case 2:
                        {
                            var orderedByName = StudentDetails.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                            foreach (KeyValuePair<string, int> student in orderedByName)
                            {
                                Console.WriteLine("Name: {0}, Class: {1}", student.Key, student.Value);
                            }
                        }
                        break;
                    case 3:
                        {
                            var orderedByClass = StudentDetails.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                            foreach (KeyValuePair<string, int> student in orderedByClass)
                            {
                                Console.WriteLine("Name: {0}, Class: {1}", student.Key, student.Value);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter the name you want to search");
                            string name = Console.ReadLine().ToLower();
                            foreach (KeyValuePair<string, int> student in StudentDetails)
                            {
                                if (student.Key.ToLower() == name)
                                {
                                    Console.WriteLine("Name: {0}, Class: {1}", student.Key, student.Value);
                                }

                            }
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Wrong input");
                        }
                        break;
                }
                Console.WriteLine("\n");
                Console.WriteLine("Press Y if you want to return to main menu");
                if (Console.ReadLine().ToLower() != "y")
                {
                    flag = false;
                }
            }
            Console.ReadKey();
        }
    }
}
