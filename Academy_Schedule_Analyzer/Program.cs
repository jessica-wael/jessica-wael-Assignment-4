using BenchmarkDotNet.Running;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        string[] SessionName = { "C# Basics",
            "OOP Fundamentals",
            "Advanced C#",
            "LINQ Basics",
            "SQL Fundamentals",
            "Entity Framework",
            "ASP.NET Core",
            "Web API Fundamentals",
            "Git & GitHub",
            "Clean Code" 
        };

        DateTime[] SessionDates = {
            new DateTime(2026, 9, 18, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0),
            new DateTime(2026, 9, 27, 19, 0, 0),
            new DateTime(2026, 10, 1, 18, 30, 0),
            new DateTime(2026, 10, 4, 19, 0, 0),
            new DateTime(2026, 10, 8, 18, 0, 0),
            new DateTime(2026, 10, 11, 20, 0, 0),
            new DateTime(2026, 10, 15, 18, 30, 0),
            new DateTime(2026, 10, 18, 19, 0, 0)
        };

        int[] SessionDuration = {
            180,
            150,
            210,
            120,
            180,
            150,
            240,
            180,
            120,
            150
        };


        while (true)
        {
            
            int option = ShowMenu();

            switch (option)
            {
                case 1:
                    DisplayAllSessions(SessionName, SessionDates, SessionDuration);
                    break;

                case 2:
                    SearchForSession(SessionName, SessionDates, SessionDuration);
                    break;

                case 3:
                    SortSessionNames(SessionName);
                    break;

                case 4:
                    ReverseSessionNames(SessionName);
                    break;

                case 5:
                    FindSessionIndex(SessionName);
                    break;

                case 6:
                    IsSessionExists(SessionName);
                    break;

                case 7:
                    DurationStatistics(SessionDuration);
                    break;

                case 8:
                    SessionDetails(SessionName, SessionDates, SessionDuration);
                    break;

                case 9:
                    PastandUpcomingSessions(SessionName, SessionDates);
                    break;

                case 10:
                    FindNextSession( SessionName,  SessionDates);
                    break;

                case 11:
                    DateDifference(SessionName, SessionDates);
                    break;

                case 12:
                    DateTime custom = ReadandValidateDate();
                    Console.WriteLine($"Valid date: {custom:yyyy-MM-dd HH:mm}");
                    DateFormatting(custom);
                    break;

                case 13:
                    InvalidArrayIndex(SessionName, SessionDates, SessionDuration);
                    break;

                case 14:
                    ValidateDuration();
                    break;

                case 15:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n Schedule Report : ");
                    Console.ResetColor();
                    Console.WriteLine(ReportUsingString(SessionName, SessionDates, SessionDuration));
                    break;

                case 16:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\n Schedule Report : ");
                    Console.ResetColor();
                    Console.WriteLine(ReportUsingStringBulder(SessionName, SessionDates, SessionDuration));
                    break;


                case 17:
                    TestRef();
                    break;

                case 18:
                    TestOut(SessionName, SessionDuration);
                    break;

                case 19:
                    
                    ReferenceTypeTest(SessionName);
                    break;

                case 20:
                    
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nparams keyword demo:");
                    Console.ResetColor();
                    Console.WriteLine($"Total(120,180) = {paramsKeyword(120, 180)} minutes");
                    Console.WriteLine($"Total(120,180,240) = {paramsKeyword(120, 180, 240)} minutes");
                    Console.WriteLine($"Total(60,90,120,180,240) = {paramsKeyword(60, 90, 120, 180, 240)} minutes");
                    break;

                case 21:
                    
                    FindSession(SessionName);
                    break;

                case 22:
                    
                    FindSessionIndexUsingCondition(SessionName);
                    break;

                case 23:
                    
                    CopyAnArray(SessionName);
                    break;

                case 24:
                    
                    SortedDuration(SessionDuration);
                    break;

                case 0:
                    return;


                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid option. Please try again !");
                    Console.ResetColor();
                    break;

            }



        }



    }

    public static int ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n====   Academy Schedule Analyzer  ====");
        Console.ResetColor();

        Console.WriteLine("\n1. Display all sessions ");
        Console.WriteLine("2. Search for a session");
        Console.WriteLine("3. Sort session names");
        Console.WriteLine("4. Reverse session names");
        Console.WriteLine("5. Find session index");
        Console.WriteLine("6. Check if session exists");
        Console.WriteLine("7. Show duration statistics");
        Console.WriteLine("8. Show session date details");
        Console.WriteLine("9. Show past and upcoming sessions");
        Console.WriteLine("10. Find next session");
        Console.WriteLine("11. Compare two session dates");
        Console.WriteLine("12. Read and validate a custom date");
        Console.WriteLine("13. Select session by index");
        Console.WriteLine("14. Validate session duration");
        Console.WriteLine("15. Generate report using string");
        Console.WriteLine("16. Generate report using StringBuilder");
        Console.WriteLine("17. ref demo (change a value type)");
        Console.WriteLine("18. out demo (find session index + duration)");
        Console.WriteLine("19. Reference type without ref demo");
        Console.WriteLine("20. params keyword demo");
        Console.WriteLine("21. Find a session (Array.Find)");
        Console.WriteLine("22. Find session index using condition (Array.FindIndex)");
        Console.WriteLine("23. Copy an array demo");
        Console.WriteLine("24. Sorted session durations");
        Console.WriteLine("0. Exit");
        Console.Write("\nChoose an option :");

        while (true)
        {
            try
            {
                int option = int.Parse(Console.ReadLine()!);
                return option;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid menu option. Enter a number.");
                Console.Write("Choose an option: ");
            }
        }
    }
    public static void DisplayAllSessions(string[] SessionName, DateTime[] SessionDates, int[] SessionDuration)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("==== The Schedule ==== ");
        Console.ResetColor();
        for (int i = 0; i < SessionName.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {SessionName[i]}");
            Console.WriteLine($"Date: {SessionDates[i]:dd:MMMM:yyyy}");
            Console.WriteLine($"Start Time: {SessionDates[i].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration: {SessionDuration[i]} minutes");
            Console.WriteLine(" ");

        }


    }

    public static void SearchForSession(string[] SessionName, DateTime[] SessionDates, int[] SessionDuration)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("Enter the session name you want to search for:  ");
        Console.ResetColor();
        string Name = Console.ReadLine()!;

        int index = Array.FindIndex(SessionName, s => s.Equals(Name, StringComparison.OrdinalIgnoreCase));


        if (index != -1)
        {

            Console.WriteLine($"\n1. {SessionName[index]}");
            Console.WriteLine($"Date: {SessionDates[index]:dd:MMMM:yyyy}");
            Console.WriteLine($"Start Time: {SessionDates[index].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration: {SessionDuration[index]} minutes\n");

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Session not found.");
            Console.ResetColor();
        }
    }

    //part 4.1
    public static void SortSessionNames(string[] SessionName)
    {
        string[] CopiedName = new string[SessionName.Length];
        Array.Copy(SessionName, CopiedName, SessionName.Length);
        Array.Sort(CopiedName);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nSorted Session Names: ");
        Console.ResetColor();
        foreach (var name in CopiedName)
        {
            Console.WriteLine($"* {name} ");
        }

    }

    //part 4.2
    public static void ReverseSessionNames(string[] SessionName)
    {
        string[] ReverseNames = new string[SessionName.Length];
        Array.Copy(SessionName, ReverseNames, SessionName.Length);
        Array.Reverse(ReverseNames);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nReversed Session Names: ");
        Console.ResetColor();
        foreach (var name in ReverseNames)
        {
            Console.WriteLine($"* {name}");
        }
    }

    // part 4.3
    public static void FindSessionIndex(string[] SessionName)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name: ");
        Console.ResetColor();
        string Name = Console.ReadLine()!;
        int index = Array.IndexOf(SessionName, Name);
        Console.WriteLine($"The Index Of Session {Name} is: {index}");
    }

    //part 4.4
    public static void IsSessionExists(string[] SessionName)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name : ");
        Console.ResetColor();
        string Name = Console.ReadLine()!;
        bool exists = Array.Exists
              (SessionName, s => s.Equals(Name, StringComparison.OrdinalIgnoreCase));

        if (exists)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Session exists.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Session doesn't exists.");
            Console.ResetColor();
        }
    }

    //part 4.5
    public static void FindSession(string[] SessionName)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name : ");
        Console.ResetColor();
        string Name = Console.ReadLine()!;
        string FindSession = Array.Find
               (SessionName, s => s.Contains(Name, StringComparison.OrdinalIgnoreCase))!;
        if (FindSession != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Found Session: {FindSession}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No matching session found");
            Console.ResetColor();
        }
    }

    //part 4.6
    public static void FindSessionIndexUsingCondition(string[] SessionName)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name : ");
        Console.ResetColor();
        string Name = Console.ReadLine()!;
        int index = Array.FindIndex
            (SessionName, s => s.Contains(Name, StringComparison.OrdinalIgnoreCase))!;
        Console.WriteLine($" The Index: {index}");

    }
    public static void CopyAnArray(string[] SessionName)
    {
        string[] CopiedSession = new string[SessionName.Length];
        Array.Copy(SessionName, CopiedSession, SessionName.Length);

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter the name of session you want to change: ");
        Console.ResetColor();
        string OldName = Console.ReadLine()!;

        int index = Array.IndexOf(SessionName, OldName);
        if (index != -1)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Enter the new session name: ");
            Console.ResetColor();
            string NewName = Console.ReadLine()!;
            CopiedSession[index] = NewName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe Session Name is Changed..");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe Session Name Is Not Found !");
            Console.ResetColor();
        }
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("---- The Original Array ---");
        Console.ResetColor();
        foreach (var name in SessionName)
        {
            Console.WriteLine($"- {name}");
        }

        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("---- The Copied Array ---");
        Console.ResetColor();
        foreach (var name in CopiedSession)
        {
            Console.WriteLine($"- {name}");
        }

    }
    //total
    public static int TotalDuration(int[] SessionDuration)
    {
        int total = 0;
        foreach (int t in SessionDuration)
        {
            total += t;

        }
        return total;
    }
    //Avaerage Duration ........
    public static double AverageDuration(int[] SessionDuration)
    {
        int Total = 0;
        foreach (int v in SessionDuration)
        {
            Total += v;

        }
        double average = Total / SessionDuration.Length;

        return average;

    }

    //Shortest Duration.................
    public static int ShortestDuration(int[] SessionDuration)
    {
        int shortest = SessionDuration[0];
        foreach (int s in SessionDuration)
        {
            if (s < shortest) { shortest = s; }

        }
        return shortest;

    }

    //Longest Diration .............
    public static int LongestDuration(int[] SessionDuration)
    {
        int longest = SessionDuration[0];
        foreach (int l in SessionDuration)
        {
            if (l > longest) { longest = l; }
        }
        return longest;

    }

    //Total Duration ...........
    public static void DurationStatistics(int[] SessionDuration)
    {
        int total = TotalDuration(SessionDuration);
        double average = AverageDuration(SessionDuration);
        int shortest = ShortestDuration(SessionDuration);
        int longest = LongestDuration(SessionDuration);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("The Duration Statistics: ");
        Console.ResetColor();

        Console.WriteLine($"Total Duration : {total} minutes");
        Console.WriteLine($"Average Duration : {average} minutes");
        Console.WriteLine($"Shortest Duration : {shortest} minutes");
        Console.WriteLine($"Longest Duration : {longest} minutes");
        Console.WriteLine(" ");


    }

    // Sorted Session Duration
    public static void SortedDuration(int[] SessionDuration)
    {

        int[] CopiedDuration = new int[SessionDuration.Length];
        Array.Copy(SessionDuration, CopiedDuration, SessionDuration.Length);
        Array.Sort(CopiedDuration);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nSorted Session Duration: ");
        Console.ResetColor();
        foreach (int duration in CopiedDuration)
        {
            Console.WriteLine($"- {duration} minutes");
        }
    }


    // ref and out and reference type without ref
    public static void ChangeDuration(ref int duration)
    {
        duration = 240;

    }
    public static void TestRef()
    {
        int duration = 120;

        Console.WriteLine($"Before calling the function: {duration}");

        ChangeDuration(ref duration);

        Console.WriteLine($"After calling the function: {duration}");
    }

    public static bool FindSessionWithOut(string session, string[]SessionName , int[]SessionDuration ,out int index , out int duration)
    {

        index = Array.IndexOf(SessionName, session); 
        if (index == -1)
        {
             duration = 0;
            return false;
        }
        duration = SessionDuration[index];
        return true;

    }
    public static void TestOut(string[] SessionName, int[] SessionDuration)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name: ");
        Console.ResetColor();
        string name = Console.ReadLine()!;

        bool found = FindSessionWithOut(name, SessionName, SessionDuration, out int index, out int duration);

        if (found)
        {
            Console.WriteLine($"\nIndex: {index}");
            Console.WriteLine($"Duration {duration} minutes");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The session is not found!");
            Console.ResetColor();
        }

    }

    public static void ChangeSession(string[] SessionName)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter Session Name: ");
        Console.ResetColor();
        string session = Console.ReadLine()!;

        int index = Array.FindIndex(SessionName, s => s.Equals(session, StringComparison.OrdinalIgnoreCase));
        if(index != -1)
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\nEnter Session Name: ");
            Console.ResetColor();
            string newName = Console.ReadLine()!;

            SessionName[index] = newName;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The session updated successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Session not fount!");
            Console.ResetColor();

        }
    }

    public static void ReferenceTypeTest(string[] names)
    {
        
        string[] copiedSession = new string[names.Length];
        Array.Copy(names, copiedSession, names.Length);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nReference type without ref demo:");
        Console.ResetColor();

        Console.WriteLine("Before Changing :");
        foreach (var n in copiedSession) Console.WriteLine($"- {n}");

        ChangeSession(copiedSession);

        Console.WriteLine("After Changing :");
        foreach (var n in copiedSession) Console.WriteLine($"- {n}");
    }

    public static int paramsKeyword(params int[] Duration)
    {
         int total = 0;
        foreach(int duration in Duration)
        {
            total += duration;

        }
        return total;
    }

    // 
    static DateTime SessionEndTime(DateTime startTime, int duration)
    {

        return startTime.AddMinutes(duration);
    }
    public static void SessionDetails(string[] SessionName, DateTime[] SessionDates, int[] SessionDuration)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter session name: ");
        Console.ResetColor();
        string name = Console.ReadLine()!;

        int index = Array.FindIndex(SessionName, s => s.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (index != -1)
        {
            DateTime date = SessionDates[index];
            int duration = SessionDuration[index];
            DateTime endTime = SessionEndTime(date, duration);

            Console.WriteLine($"\nSession: {SessionName[index]}");
            Console.WriteLine($"Date: {date: dd MMMM yyy}");
            Console.WriteLine($"Day: {date.DayOfWeek}");
            Console.WriteLine($"Year: {date.Year}");
            Console.WriteLine($"Month: {date.Month}");
            Console.WriteLine($"Day Number: {date.Day}");
            Console.WriteLine($"Start Time: {date: hh:mm tt}");
            Console.WriteLine($"Duration: {duration}");
            Console.WriteLine($"End Time: {endTime: HH:mm tt}");

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Session NOT Found !");
            Console.ResetColor();
        }


    }

    public static void DateDifference(string[] SessionName, DateTime[] SessionDates)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("\nEnter the names of the two sessions.");

        Console.Write("First Session: ");
        Console.ResetColor();
        string FirstSession = Console.ReadLine()!;

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("Second Session: ");
        Console.ResetColor();
        string SecondSession = Console.ReadLine()!;

        int firstIndex = Array.FindIndex
                  (SessionName, s => s.Equals(FirstSession, StringComparison.OrdinalIgnoreCase));

        int secondIndex = Array.FindIndex
                 (SessionName, s => s.Equals(SecondSession, StringComparison.OrdinalIgnoreCase));

        if (firstIndex != -1 && secondIndex != -1)
        {
            TimeSpan diff = (SessionDates[secondIndex] - SessionDates[firstIndex]).Duration();

            Console.WriteLine("\nDifference :");
            Console.WriteLine($"{diff.Days} days");
            Console.WriteLine($"{diff.Hours} hours");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nOne or both sessions were not found!");
            Console.ResetColor();
                
        }



    }

    public static void PastandUpcomingSessions(string[] SessionName , DateTime[] SessionDates)
    {
        DateTime now = DateTime.Now;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("\n=============");
        Console.ResetColor();
        for (int i=0; i< SessionName.Length; i++)
        {
            if (SessionDates[i] < now)
            {
                Console.WriteLine($"{SessionName[i]}... Past");
            }
            else
            {
                Console.WriteLine($"{SessionName[i]}... Upcoming");
            }
        }

    }


    public static void FindNextSession(string[] SessionName, DateTime[] SessionDates)
    {
        DateTime now = DateTime.Now;
        DateTime nearestDate = DateTime.MaxValue;

        bool found=false;

        for(int i=0; i<SessionDates.Length; i++)
        {
            if (SessionDates[i] > now && SessionDates[i] < nearestDate)
            {
                found = true;
                TimeSpan Date = SessionDates[i] - now;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\nNext Session: ");
                Console.ResetColor();
                Console.WriteLine($"\n{SessionName[i]}");
                Console.WriteLine($"{SessionDates[i]:dd MMMM yyy}");
                Console.WriteLine($"{SessionDates[i]:hh:mm tt}");

                Console.WriteLine("\nTime Remaining: ");
                Console.WriteLine($"{Date.Days} days");
                Console.WriteLine($"{Date.Hours} hours");

                break;
            }
        }
        if (found == false)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("There are No upcoming sessions !");
            Console.ReadLine();

        }

    }
     
    
    public static void DateFormatting(DateTime date)
    {
        var x = CultureInfo.InvariantCulture;
        Console.WriteLine(date.ToString("yyyy-MM-dd", x));
        Console.WriteLine(date.ToString("dd/MM/yyyy", x));
        Console.WriteLine(date.ToString("dd MMMM yyyy", x));
        Console.WriteLine(date.ToString("dddd, dd MMMM yyyy", x));
        Console.WriteLine(date.ToString("hh:mm tt", x));

    }


    public static DateTime ReadandValidateDate()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Enter Date in (yyyy-MM-dd HH:mm):");
            Console.ResetColor();
            string input = Console.ReadLine()!; 

            if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", 
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid date. Please try again.");
            Console.ResetColor();

        }
    }

    public static void InvalidArrayIndex(string[] SessionNames,DateTime[] SessionDates,int[] SessionDuration)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("\nEnter session index: ");
        Console.ResetColor();

        try
        {
            int index = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"\nSession: {SessionNames[index]}");
            Console.WriteLine($"Date: {SessionDates[index]:dd MMMM yyyy}");
            Console.WriteLine($"Duration: {SessionDuration[index]} minutes");

        }
        catch (IndexOutOfRangeException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe selected Session index is out of range!");
            Console.ResetColor();
        }
    }

    //Validate Duration and throw
    public static void ThrowAnException(int duration)
    {
        if (duration <= 0)
        {
            throw new ArgumentException("Duration must be greater than zero.");
            
        }
    }
    public static void ValidateDuration()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Enter session duration: ");
            Console.ResetColor();
            int duration = int.Parse(Console.ReadLine()!);

            ThrowAnException(duration);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Duratioon accepted.");
            Console.ResetColor();

        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please enter a valid number!");
            Console.ResetColor();
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        finally
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Input operation finished.");
            Console.ResetColor();
        }
    }

    // .......Reborts... //
    public static string ReportUsingString(string[]SessionName, DateTime[]SessionDates, int[] SessionDuration)
    {
        string result = "";

        for (int i = 0 ;i < SessionName.Length; i++){
            result+=
            ($"{SessionName[i]} - {SessionDates[i]: dd/MM/yyy hh:mm tt} - {SessionDuration[i]} minutes\n");

            
        }
        return result;
    }

    public static string ReportUsingStringBulder(string[] SessionName, DateTime[] SessionDates, int[] SessionDuration)
    {
        StringBuilder result = new StringBuilder();

        for(int i = 0; i < SessionName.Length; i++)
        {
            result.Append($"{SessionName[i]} - ");
            result.Append($"{SessionDates[i]: dd/MM/yyy hh:mm tt} - ");
            result.Append($"{SessionDuration[i]} minutes");

            result.AppendLine();
        }
        return result.ToString();
    }

}