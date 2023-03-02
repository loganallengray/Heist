using System;

namespace heist
{
    class Member
    {
        public string Name { get; }

        public int SkillLevel { get; }

        public double CourageFactor { get; }

        public Member(string name, int skillLevel, double courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }
    }
}
