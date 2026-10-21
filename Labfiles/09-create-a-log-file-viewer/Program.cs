// Ask user if they want to overwrite the log file
Console.Write("Do you want to overwrite the log file? (y/n): ");
string ?overwriteInput = Console.ReadLine();

while (overwriteInput?.ToLower() != "y" && overwriteInput?.ToLower() != "n")
{
    Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
    Console.Write("Do you want to overwrite the log file? (y/n): ");
    overwriteInput = Console.ReadLine();
}

if (overwriteInput?.ToLower() == "y")
{
    File.WriteAllText("log.txt", string.Empty);
    Console.WriteLine("Log file overwritten.\n");
}
else
{
    Console.WriteLine("Log file will be appended.\n");
}

// Log a new event
string logFile = "log.txt";
string timestamp = DateTime.Now.ToString("HH:mm:ss");

File.AppendAllText(logFile, $"[{timestamp}] Application started\n");

Console.WriteLine("Event logged.\n");

// Read back every logged event
Console.WriteLine("Event history:");

using StreamReader reader = new StreamReader(logFile);
string line;

while ((line = reader.ReadLine()) != null)
{
    Console.WriteLine(line);
}

// Count the logged events
if (File.Exists(logFile))
{
    string[] allLines = File.ReadAllLines(logFile);
    Console.WriteLine($"\nTotal events logged: {allLines.Length}");
}
else
{
    Console.WriteLine("No log file found yet.");
}