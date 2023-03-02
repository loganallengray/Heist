using System;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("Crew Member Name:");
            string memberName = Console.ReadLine();

            Console.WriteLine("Crew Member Skill Level:");
            string memberSkillLevelString = Console.ReadLine();
            int.TryParse(memberSkillLevelString, out int memberSkillLevel);

            Console.WriteLine("Crew Member Courage Factor:");
            string memberCourageFactorString = Console.ReadLine();
            double.TryParse(memberCourageFactorString, out double memberCourageFactor);

            Member member1 = new Member(memberName, memberSkillLevel, memberCourageFactor);

            Console.WriteLine($"{member1.Name} has a skill level of {member1.SkillLevel}, and a courage factor of {member1.CourageFactor}.");
        }
    }
}
