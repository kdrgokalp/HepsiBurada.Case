using ConsoleApplication.Command;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    public static class CommonOperation
    {
        public static List<BaseCommand> FileOperattion(string path)
        {
            if (!File.Exists(path))
                throw new Exception("File not found!");

            List<BaseCommand> baseCommands = new List<BaseCommand>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line = string.Empty;
                while (!string.IsNullOrWhiteSpace(line = sr.ReadLine()))
                {
                    
                    var lineSplit = line.Split(" ").ToList();
                    if (lineSplit.Count < 2)
                        throw new Exception($"Command line is defined incorrectly. Line : {line}");

                    CommandType commandType;
                    if (!Enum.TryParse(lineSplit.First(), out  commandType) )
                        throw new Exception($"Command name is defined incorrectly. Command Name: {lineSplit.First()}");

                    BaseCommand command;
                    switch (commandType)
                    {
                        case CommandType.create_product:
                            command = new CreateProductCommand(lineSplit.Skip(1).ToList());
                            break;
                        case CommandType.get_product_info:
                            command = new GetProductInfoCommand(lineSplit.Skip(1).ToList());
                            break;
                        case CommandType.create_order:
                            command = new CreateOrderCommand(lineSplit.Skip(1).ToList());
                            break;
                        case CommandType.create_campaign:
                            command = new CreateCampaignCommand(lineSplit.Skip(1).ToList());
                            break;
                        case CommandType.get_campaign_info:
                            command = new GetCampaignInfoCommand(lineSplit.Skip(1).ToList());
                            break;
                        case CommandType.increase_time:
                            command = new GetIncreaseTimeCommand(lineSplit.Skip(1).ToList());
                            break;
                        default:
                            throw new Exception($"Command line is not defined");
                    }

                    baseCommands.Add(command);
                }
            }
            return baseCommands;
            
        }
    }
}
