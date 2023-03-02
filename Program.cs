using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Member> team = new List<Member>();
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

                Console.WriteLine("Crew Member Skill Level:");
                string memberSkillLevelString = Console.ReadLine();
                int.TryParse(memberSkillLevelString, out int memberSkillLevel);

                Console.WriteLine("Crew Member Courage Factor:");
                string memberCourageFactorString = Console.ReadLine();
                double.TryParse(memberCourageFactorString, out double memberCourageFactor);

                Member newMember = new Member(memberName, memberSkillLevel, memberCourageFactor);
                team.Add(newMember);
            }
            while (memberName.Length > 0);

            Console.WriteLine($"Number of members: {team.Count}");
            foreach (Member member in team)
            {
                Console.WriteLine($"{member.Name} has a skill level of {member.SkillLevel}, and a courage factor of {member.CourageFactor}.");
            }
        }
    }
}