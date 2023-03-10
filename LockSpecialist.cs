using System;

namespace heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; }
        public double CourageFactor { get; }
        public int SkillLevel { get; }
        public double PercentageCut { get; }

        public LockSpecialist(string name, double courageFactor, int skillLevel, double percentageCut)
        {
            Name = name;
            CourageFactor = courageFactor;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            Console.WriteLine($"{Name} is picking the lock. Decreased security by {SkillLevel} points!");
            bank.VaultScore -= SkillLevel;
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has picked the lock!");
            }
            Console.WriteLine();
        }
    }
}
