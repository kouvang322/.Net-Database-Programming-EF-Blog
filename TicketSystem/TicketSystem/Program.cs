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
                            Console.WriteLine(
                                "TicketID {0},Summary {1},Status {2},Priority {3},Submitter {4},Assigned {5},Watching {6}",
                                column[0], column[1], column[2], column[3], column[4], column[5], column[6]);
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

                    StreamWriter fileWriter = new StreamWriter(file);

                    Console.Write("Enter Ticket ID: ");
                    int ticketID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Ticket summary: ");
                    var summary = Console.ReadLine();

                    Console.Write("Enter Ticket status: ");
                    var status = Console.ReadLine();

                    Console.Write("Enter Ticket priority: ");
                    var priority = Console.ReadLine();

                    Console.Write("Enter Ticket submitter: ");
                    var submitter = Console.ReadLine();

                    Console.Write("Enter who the ticket is assigned: ");
                    var assigned = Console.ReadLine();

                    Console.Write("Enter who is watching the ticket: ");
                    var watching = Console.ReadLine();

                    Console.WriteLine("Anyone else watching the ticket (Y,N): ");
                    string others = Console.ReadLine().ToUpper();

                    while (others != "N")
                    {
                        Console.Write("Enter who else is watching the ticket: ");
                        watching = Console.ReadLine();
                        Console.WriteLine("Anyone else watching the ticket (Y/N): ");
                        others = Console.ReadLine().ToUpper();
                    }

                    var entryRow = (ticketID, summary, status, priority, submitter, assigned, watching);

                    fileWriter.WriteLine(entryRow);

                    fileWriter.Close();
                }


            } while (userChoice == "1" || userChoice == "2");
        }
    }
}