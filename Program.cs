using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Create a random number between -10 and 10 for the heist's luck value.
            1 Add this number to the bank's difficulty level.
            2 Before displaying the success or failure message, display a report that shows.
             The team's combined skill level
            4 The bank's difficulty level*/

            int bankDifficultyLevel = 100;

            List<Member> Team = new List<Member>();
            Console.WriteLine("Plan Your Heist!");

            string memberName = "";
            do
            {
                Console.WriteLine("Crew Member Name:");
                memberName = Console.ReadLine();
                if (memberName == "")
                {
                    break;
                }


                Console.WriteLine("Crew Member skill level:");
                string memberSkillLevelString = Console.ReadLine();
                int.TryParse(memberSkillLevelString, out int memberSkillLevel);

                Console.WriteLine("Crew Member courage factor:");
                string memberCourageFactorString = Console.ReadLine();
                double.TryParse(memberCourageFactorString, out double memberCourageFactor);

                Member newMember = new Member(memberName, memberSkillLevel, memberCourageFactor);
                Team.Add(newMember);
                Console.WriteLine();
            }
            while (memberName.Length > 0);

            int teamSkillLevel = 0;

            foreach (Member member in Team)
            {
                teamSkillLevel += member.SkillLevel;
            }

            Console.WriteLine("How many trials do you want to run?:");
            string trialChoiceString = Console.ReadLine();
            int.TryParse(trialChoiceString, out int trialChoice);

            for (int i = 0; i < trialChoice; i++)
            {
                int LuckValue = new Random().Next(-10, 11);
                bankDifficultyLevel += LuckValue;

                Console.WriteLine($"total skill level of team :{teamSkillLevel} and bank's difficulty level is {bankDifficultyLevel}");

                if (teamSkillLevel >= bankDifficultyLevel)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"you did it");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"straight to jail");
                    Console.ResetColor();
                }
            }

            // foreach (Member member in Team)
            // {
            // Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel} and a courage factor of {member.CourageFactor}.");
            // }
        }
    }
}