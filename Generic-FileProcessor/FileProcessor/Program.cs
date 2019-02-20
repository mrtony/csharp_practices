using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            var peopleFile = @"C:\Temp\people.csv";
            var logFile = @"C:\Temp\logs.csv";

            //取得測試資料
            PopulateList(people, logs);

            //write people to file
            FileProcessor.SaveToTextFile<Person>(people, peopleFile);

            //write log to file
            FileProcessor.SaveToTextFile<LogEntry>(logs, logFile);

            //read people data from file and display
            var peopleFromFile = FileProcessor.LoadFromTextFile<Person>(peopleFile);
            foreach (var person in peopleFromFile)
            {
                Console.WriteLine($"The person: FirstName - {person.FirstName}, LastName - {person.LastName}, Is Alive - {person.IsAlive}");
            }

            //read log data from file and display
            var logsFromFile = FileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var log in logsFromFile)
            {
                Console.WriteLine($"The log: code - {log.ErrorCode}, message - {log.Message}, date of event - {log.TimeOfEvent.ToLocalTime()}");
            }
            Console.ReadLine();
        }

        private static void PopulateList(List<Person> people, List<LogEntry> logs)
        {
            people.Add(new Person { FirstName = "Tony", LastName = "Chen", IsAlive = true });
            people.Add(new Person { FirstName = "Candy", LastName = "Lin", IsAlive = true });

            logs.Add(new LogEntry { ErrorCode = 1, Message = "null", TimeOfEvent = DateTime.UtcNow });
            logs.Add(new LogEntry { ErrorCode = 2, Message = "empty", TimeOfEvent = DateTime.UtcNow });
        }
    }
}
