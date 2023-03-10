using System;

namespace heist
{
    public class Bank
    {
        public double CashOnHand { get; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure
        {
            get { return !(AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0); }
        }

        public Bank(int VaultCash, int AlarmDiff, int VaultDiff, int GuardDiff)
        {
            CashOnHand = VaultCash;
            AlarmScore = AlarmDiff;
            VaultScore = VaultDiff;
            SecurityGuardScore = GuardDiff;
        }
    }
}