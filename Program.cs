using System;
using System.Linq;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PLAN YOUR HEIST!");
            Console.WriteLine();

            Console.WriteLine("Rollerdex Additions");
            Console.WriteLine("Add new contacts to the list of criminals we've got...");
            Console.WriteLine();

            Hacker Hacker1 = new Hacker("Will", 1, 80, 30);
            Hacker Hacker2 = new Hacker("Dave", 0.5, 40, 15);
            LockSpecialist LockSpecialist1 = new LockSpecialist("Chris", 0.5, 80, 30);
            LockSpecialist LockSpecialist2 = new LockSpecialist("Bob", 0.25, 40, 15);
            Muscle Muscle1 = new Muscle("Logan", 2, 80, 30);
            Muscle Muscle2 = new Muscle("Nathaniel", 1.5, 40, 15);


            List<IRobber> Rollerdex = new List<IRobber>
            {
                Hacker1,
                Hacker2,
                LockSpecialist1,
                LockSpecialist2,
                Muscle1,
                Muscle2
            };

            string memberSpecialtyString = "";

            do
            {
                Console.WriteLine("Crew Member Specialty:");
                Console.WriteLine("1) Hacker");
                Console.WriteLine("2) Lock Specialist");
                Console.WriteLine("3) Muscle");
                Console.WriteLine("Leave empty to continue (just press enter)");

                memberSpecialtyString = Console.ReadLine();

                if (memberSpecialtyString == "")
                {
                    break;
                }

                Console.WriteLine("Crew Member Name:");
                string memberName = Console.ReadLine();

                Console.WriteLine("Crew Member Courage Factor:");
                string memberCourageFactorString = Console.ReadLine();
                double.TryParse(memberCourageFactorString, out double memberCourageFactor);

                Console.WriteLine("Crew Member Skill Level:");
                string memberSkillLevelString = Console.ReadLine();
                int.TryParse(memberSkillLevelString, out int memberSkillLevel);

                Console.WriteLine("Crew Member Cut:");
                string memberPercentageCutString = Console.ReadLine();
                int.TryParse(memberPercentageCutString, out int memberPercentageCut);

                switch (memberSpecialtyString)
                {
                    case "1":
                        Hacker newHackerMember = new Hacker(memberName, memberCourageFactor, memberSkillLevel, memberPercentageCut);
                        Rollerdex.Add(newHackerMember);
                        Console.WriteLine();
                        break;
                    case "2":
                        LockSpecialist newLockSpecialistMember = new LockSpecialist(memberName, memberCourageFactor, memberSkillLevel, memberPercentageCut);
                        Rollerdex.Add(newLockSpecialistMember);
                        Console.WriteLine();
                        break;
                    case "3":
                        Muscle newMuscleMember = new Muscle(memberName, memberCourageFactor, memberSkillLevel, memberPercentageCut);
                        Rollerdex.Add(newMuscleMember);
                        Console.WriteLine();
                        break;
                }
            }
            while (memberSpecialtyString.Length > 0);

            int VaultCash = (RandomNum(19) + 1) * 50000;
            int AlarmDiff = RandomNum(100);
            int VaultDiff = RandomNum(100);
            int GuardDiff = RandomNum(100);

            Bank bank = new Bank(VaultCash, AlarmDiff, VaultDiff, GuardDiff);

            Dictionary<string, int> DiffScores = new Dictionary<string, int>(){
                {"Alarm", bank.AlarmScore},
                {"Vault", bank.VaultScore},
                {"Security Guards", bank.SecurityGuardScore}
            };

            string MaxDiffScoreName = DiffScores.FirstOrDefault(score => score.Value == DiffScores.Values.Max()).Key;
            string MinDiffScoreName = DiffScores.FirstOrDefault(score => score.Value == DiffScores.Values.Min()).Key;

            Console.WriteLine("Recon Report");
            Console.WriteLine();
            Console.WriteLine($"Most Secure System: {MaxDiffScoreName}");
            Console.WriteLine($"Least Secure System: {MinDiffScoreName}");
            Console.WriteLine();

            Console.WriteLine("Rollerdex");
            Console.WriteLine();

            List<IRobber> Crew = new List<IRobber>();

            foreach (var Member in Rollerdex.Select((Value, Index) => (Value, Index)))
            {
                string MemberSpecialty = Member.Value.GetType().Name;

                if (MemberSpecialty == "LockSpecialist")
                {
                    MemberSpecialty = "Lock Specialist";
                }

                Console.WriteLine($"({Member.Index + 1}) {Member.Value.Name} | {MemberSpecialty}");
                Console.WriteLine($"Skill Level: {Member.Value.SkillLevel}");
                Console.WriteLine($"Percentage Cut: {Member.Value.PercentageCut}%");
                Console.WriteLine();
            }

            List<IRobber> RollerdexCopy = new List<IRobber>(Rollerdex);
            string userChoice = "";
            double percentageTaken = 0;

            do
            {
                Console.WriteLine("Add a Crew Member: (enter number next to name)");
                userChoice = Console.ReadLine();

                if (userChoice == "" || RollerdexCopy.Count == 0)
                {
                    break;
                }

                int.TryParse(userChoice, out int userChoiceNum);
                userChoiceNum--;

                Crew.Add(RollerdexCopy[userChoiceNum]);
                percentageTaken += RollerdexCopy[userChoiceNum].PercentageCut;
                RollerdexCopy.Remove(RollerdexCopy[userChoiceNum]);

                RollerdexCopy = RollerdexCopy.Where(Member => Member.PercentageCut + percentageTaken < 100).ToList();

                Console.WriteLine();
                Console.WriteLine("Rollerdex");
                Console.WriteLine();

                foreach (var Member in RollerdexCopy.Select((Value, Index) => (Value, Index)))
                {
                    string MemberSpecialty = Member.Value.GetType().Name;

                    if (MemberSpecialty == "LockSpecialist")
                    {
                        MemberSpecialty = "Lock Specialist";
                    }

                    Console.WriteLine($"({Member.Index + 1}) {Member.Value.Name} | {MemberSpecialty}");
                    Console.WriteLine($"Skill Level: {Member.Value.SkillLevel}");
                    Console.WriteLine($"Percentage Cut: {Member.Value.PercentageCut}%");
                    Console.WriteLine();
                }
            }
            while (userChoice != "" || Crew.Count() == 0 || RollerdexCopy.Count != 0);

            Console.WriteLine("The heist has begun!");
            Console.WriteLine();

            foreach (IRobber Member in Crew)
            {
                Member.PerformSkill(bank);
            }

            if (bank.IsSecure)
            {
                Console.WriteLine("Your team has failed. You get nothing!");
            }
            else
            {
                double payout = bank.CashOnHand;

                foreach (IRobber Member in Crew)
                {
                    double memberCut = bank.CashOnHand * (Member.PercentageCut / 100);
                    payout -= memberCut;
                    Console.WriteLine($"{Member.Name} has taken his cut of ${memberCut}.");
                }

                Console.WriteLine($"Your final payout is ${payout}.");
            }
        }

        static int RandomNum(int num)
        {
            return new Random().Next(num);
        }
    }
}