using ConsoleApplication.Command;
using ConsoleApplication.Helpers;

using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("-----HepsiBurada Case---------");
            Console.WriteLine("Enter the Endpoint Adress(Example: http://localhost:8080/)");
            Helper.EndPointAddress =  Console.ReadLine();
            

            string scenarioNumber = string.Empty;
            while (true)
            {
                try
                {
                    string path = string.Empty;
                    List<BaseCommand> list;
                    switch (scenarioNumber)
                    {
                        case "1":
                            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "ScenariosFile\\Scenario1.txt");
                            list = CommonOperation.FileOperattion(path);
                            ExcecuteLine(list);
                            break;
                        case "2":
                            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "ScenariosFile\\Scenario2.txt");
                            list = CommonOperation.FileOperattion(path);
                            ExcecuteLine(list);
                            break;
                        case "3":
                            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "ScenariosFile\\Scenario3.txt");
                            list = CommonOperation.FileOperattion(path);
                            ExcecuteLine(list);
                            break;
                        case "4":
                            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "ScenariosFile\\Scenario4.txt");
                            list = CommonOperation.FileOperattion(path);
                            ExcecuteLine(list);
                            break;
                        case "5":
                            path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "ScenariosFile\\Scenario5.txt");
                            list = CommonOperation.FileOperattion(path);
                            ExcecuteLine(list);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("There are 5 scenarios in the system");
                Console.WriteLine("Please choose from 1 to 5 scenarios");
                scenarioNumber = Console.ReadLine();
            }
            
        }

        public static void ExcecuteLine(List<BaseCommand> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. command line invoked");
                list[i].Execute();
                
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------------");
            Console.WriteLine("Scenario is complete.");
            Console.WriteLine("----------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
