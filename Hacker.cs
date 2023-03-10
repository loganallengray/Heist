using System;

namespace heist
{
    public class Hacker : IRobber
    {
        public string Name { get; }
        public double CourageFactor { get; }
        public int SkillLevel { get; }
        public double PercentageCut { get; }

        public Hacker(string name, double courageFactor, int skillLevel, double percentageCut)
        {
            Name = name;
            CourageFactor = courageFactor;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points!");
            bank.AlarmScore -= SkillLevel;
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
            Console.WriteLine();
        }
    }
}
