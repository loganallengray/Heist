namespace heist
{
    interface IRobber
    {
        string Name { get; }
        int SkillLevel { get; }
        double PercentageCut { get; }
        double CourageFactor { get; }
        void PerformSkill(Bank bank);
    }
}