using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WCCISpringMeetingPrj
{
    class Program
    {

        //set up some reusable chunks (Methods)
        static void HeaderText()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("*    Meeting Minutes Management Software    *");
            Console.WriteLine("*********************************************");
        }
        static void Menu()
        {
            HeaderText();
            Console.WriteLine("\n\nPick an Option From the Following List:\n");
            Console.WriteLine("1.  Create Meeting");
            Console.WriteLine("2.  View Team");
            Console.WriteLine("3.  Exit");
        }
        static void MinutesWriter()
        {
            int minutesDate;
            Console.WriteLine("\n\nWhat is the meeting date? Please answer in MMDDYY.");
            Console.WriteLine("(Today is: " + DateTime.Now.ToString("MMddyy") + ")");
            while (!int.TryParse(Console.ReadLine(), out minutesDate))
                Console.Write("That isn't a valid date. Please answer in MMDDYY.\n");
            //in a perfect world I would check each digit against valid dates but 
            //I am not sure of any trivial-for-me way to do that.
            string minutesTitle = "Minutes" + minutesDate + ".txt";
            //string minutesTitle = "minutes" + DateTime.Today.ToString("MMddyy") + ".txt";
            //Console.WriteLine(minutesTitle); this worked but wasn't what we were asked for.
            using (StreamWriter minutes = new StreamWriter(minutesTitle))
            {
                minutes.WriteLine("WE CAN SURE CODE IT");
                minutes.WriteLine("50 PUBLIC SQUARE, SUITE 200");
                minutes.WriteLine("CLEVELAND, OH 44113\n");
                minutes.WriteLine("-----------------------");
                minutes.WriteLine("   \"MEETING MINUTES\"   ");
                minutes.WriteLine("-----------------------\n");
                Console.WriteLine("Who is recording the minutes?");
                string secretary = (Console.ReadLine());
                minutes.WriteLine("Secretary: " + secretary + "\n");
                Console.WriteLine("Who is leading the meeting?");
                string teamLead = (Console.ReadLine());
                minutes.WriteLine("Team Lead: " + teamLead + "\n");
                Console.Clear();
                HeaderText();
                Console.WriteLine("\n\nPlease choose your meeting type from the following list:\n");
                List<string> meetingTypes = new List<string>();
                meetingTypes.Add("1. Marketing Meeting");
                meetingTypes.Add("2. Emergency Meeting");
                meetingTypes.Add("3. Secret Meeting");
                meetingTypes.Add("4. Planning Meeting");
                meetingTypes.Add("5. Desperate Clandestine Plotting Meeting");
                meetingTypes.Add("6. Actually Hiding From Jerry Meeting");
                meetingTypes.Add("7. Probably Going To Fire Someone Meeting");
                foreach (string meeting in meetingTypes)
                {
                    Console.WriteLine(meeting);
                }
                int pickedMeeting = int.Parse(Console.ReadLine());
                switch (pickedMeeting)
                {
                    case 1:
                        minutes.WriteLine("Meeting type: Marketing Meeting");
                        break;
                    case 2:
                        minutes.WriteLine("Meeting type: Emergency Meeting");
                        break;
                    case 3:
                        minutes.WriteLine("Meeting type: Secret Meeting");
                        break;
                    case 4:
                        minutes.WriteLine("Meeting type: Planning Meeting");
                        break;
                    case 5:
                        minutes.WriteLine("Meeting type: Desperate Clandestine Plotting Meeting");
                        break;
                    case 6:
                        minutes.WriteLine("Meeting type: Actually Hiding from Jerry Meeting");
                        break;
                    case 7:
                        minutes.WriteLine("Meeting type: Probably Going to Fire Someone Meeting");
                        break;
                }
                string typingStuff = "Y";
                while (typingStuff == "Y" || typingStuff == "y")
                {
                    Console.WriteLine("Please Type a Meeting Topic:");
                    string topic = (Console.ReadLine());
                    minutes.WriteLine("Topic: " + topic + "\n");
                    Console.WriteLine("Please enter your notes on this topic.");
                    minutes.WriteLine(Console.ReadLine());
                    minutes.WriteLine("\n");
                    Console.WriteLine("Would you like to add another topic? Y/N");
                    typingStuff = Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine("Your minutes are as follows: \n\n");
            StreamReader reader = new StreamReader(minutesTitle);
            try
            {
                //StreamReader reader = new StreamReader(minutesTitle);
                using (reader)
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(
                    "Can not find file {0}.", minutesTitle);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine(
                    "Invalid directory in the file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Cannot open the file {0}", minutesTitle);
            }
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void TeamList()
        {
            //set up this dictionary
            string teamFinder = "empty";
            Dictionary<string, string> teamMembers = new Dictionary<string, string>();
            //the team name is not unique but the personal name is
            //so the person name = key, team name = value
            //Note this means I have to sort these suckers by the value and pull the key
            //which is lousy. But we did this in class so I can reference how I did it then.
            //I would rather have each team have its own dictionary, I think. But that is not in the rubric.
            teamMembers.Add("Bob Ross", "Marketing");
            teamMembers.Add("Emily Bronte", "Marketing");
            teamMembers.Add("Booster Gold", "Marketing");
            teamMembers.Add("Alan Rickman", "Sales");
            teamMembers.Add("Jack Black", "Sales");
            teamMembers.Add("Clayton Forrester", "Sales");
            teamMembers.Add("Mona Lisa", "Capital Improvement");
            teamMembers.Add("Joel Hodgson", "Capital Improvement");
            teamMembers.Add("Frank Coniff", "Capital Improvement");
            teamMembers.Add("Mel McGee", "Administration");
            teamMembers.Add("Shana Mysko", "Administration");
            teamMembers.Add("Lauren Holloway", "Administration");
            teamMembers.Add("Alan Greenspan", "Finance");
            teamMembers.Add("Patti Substelny", "Finance");
            teamMembers.Add("Jeb Hensarling", "Finance");
            //Team menu:
            Console.WriteLine("\n\nPick a Team From the Following List:\n");
            Console.WriteLine("1.  Administration");
            Console.WriteLine("2.  Sales");
            Console.WriteLine("3.  Marketing");
            Console.WriteLine("4.  Capital Improvement");
            Console.WriteLine("5.  Finance");
            Console.WriteLine("6.  All Members");
            Console.WriteLine("\n");
            int teamInput = int.Parse(Console.ReadLine());
            switch (teamInput)
            {
                case 1:
                    teamFinder = "Administration";
                    Console.WriteLine("The Administration Team Includes: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        if (member.Value == teamFinder)
                        {
                            Console.WriteLine(member.Key);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 2:
                    teamFinder = "Sales";
                    Console.Clear();
                    HeaderText();
                    Console.WriteLine("\n\nThe Sales Team Includes: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        if (member.Value == teamFinder)
                        {
                            Console.WriteLine(member.Key);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 3:
                    teamFinder = "Marketing";
                    Console.Clear();
                    HeaderText();
                    Console.WriteLine("\n\nThe Marketing Team Includes: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        if (member.Value == teamFinder)
                        {
                            Console.WriteLine(member.Key);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 4:
                    teamFinder = "Capital Improvement";
                    Console.Clear();
                    HeaderText();
                    Console.WriteLine("\n\nThe Capital Improvement Team Includes: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        if (member.Value == teamFinder)
                        {
                            Console.WriteLine(member.Key);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 5:
                    teamFinder = "Finance";
                    Console.Clear();
                    HeaderText();
                    Console.WriteLine("\n\nThe Finance Team Includes: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        if (member.Value == teamFinder)
                        {
                            Console.WriteLine(member.Key);
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                case 6:
                    Console.Clear();
                    HeaderText();
                    Console.WriteLine("\n\nThe Comprehensive List of Team Members: \n");
                    foreach (KeyValuePair<string, string> member in teamMembers)
                    {
                        Console.WriteLine(member.Key + " (" + member.Value + ")");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        static void Main(string[] args)
        {
            Menu();
            int menuChoice = 0;
            while (menuChoice != 3)
            {
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        HeaderText();
                        MinutesWriter();
                        break;
                    case 2:
                        Console.Clear();
                        HeaderText();
                        TeamList();
                        break;
                    case 3:
                        Console.Clear();
                        HeaderText();
                        Console.WriteLine("\n\n\"Goodbye\"");
                        //Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

        }
    }
}
