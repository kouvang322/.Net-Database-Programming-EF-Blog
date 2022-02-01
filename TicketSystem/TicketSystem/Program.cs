using System;
using System.IO;

namespace TicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Files/Tickets.txt";
            string userChoice;

            do
            {
                // Ask user what they want to do
                Console.WriteLine("1. Read data from file.");
                Console.WriteLine("2. Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                //  user input
                userChoice = Console.ReadLine();

                // Read 
                if (userChoice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader fileReader = new StreamReader(file);
                        string line = fileReader.ReadLine();
                        Console.WriteLine(line);


                        while (!fileReader.EndOfStream)
                        {
                            line = fileReader.ReadLine();
                            var column = line.Split(",");
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", column[0], column[1], column[2], column[3], column[4], column[5], column[6]);
                        }
                        fileReader.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (userChoice == "2")
                {
                    // Write

                    StreamWriter fileWriter = new StreamWriter(file, append: true);

                    // Array for people who are watching ticket.
                    string[] watching = new string[5];

                    int i;

                    Console.Write("Enter Ticket ID #: ");
                    int ticketID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Ticket summary: ");
                    string summary = Console.ReadLine();

                    Console.Write("Enter Ticket status: ");
                    string status = Console.ReadLine();

                    Console.Write("Enter Ticket priority: ");
                    string priority = Console.ReadLine();

                    Console.Write("Enter Ticket submitter: ");
                    string submitter = Console.ReadLine();

                    Console.Write("Enter who the ticket is assigned: ");
                    string assigned = Console.ReadLine();


                    for (i = 0; i < 5; i++)
                    {
                        Console.Write("Enter who is watching the ticket: ");
                        watching[i] = Console.ReadLine();

                        Console.WriteLine("Anyone else watching the ticket? (Y/N)?");
                        // input the response
                        string others = Console.ReadLine().ToUpper();
                        // if no then break out of loop
                        if (others != "Y") { break; }
                    }
                    string watchers = string.Join("|", watching);

                    var entryRow = (ticketID, summary, status, priority, submitter, assigned, watchers);

                    fileWriter.WriteLine();
                    fileWriter.WriteLine(entryRow);

                    fileWriter.Close();
                }
            } while (userChoice == "1" || userChoice == "2");
        }
    }
}
