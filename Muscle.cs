using System;

namespace heist
{
    public class Muscle : IRobber
    {
        public string Name { get; }
        public double CourageFactor { get; }
        public int SkillLevel { get; }
        public double PercentageCut { get; }

        public Muscle(string name, double courageFactor, int skillLevel, double percentageCut)
        {
            Name = name;
            CourageFactor = courageFactor;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is taking out the guards. Decreased security by {SkillLevel} points!");
            bank.SecurityGuardScore -= SkillLevel;
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has taken out all the guards!");
            }
            Console.WriteLine();
        }
    }
}
