using System;


namespace Heist
{
    class Bank
    {
        public Bank(int CashOnHand, int AlarmScore, int VaultScore, int SecurityGuardScore)
        {
            COH = CashOnHand;
            Alarm = AlarmScore;
            Vault = VaultScore;
            Security = SecurityGuardScore;

        }
        public int COH { get; set; }
        public int Alarm { get; set; }
        public int Vault { get; set; }
        public int Security { get; set; }
    }
}
