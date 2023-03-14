using System;

namespace Heist
{
    public class Bank
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

        //A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true
        public bool IsSecure 
        {
            get { return !(Alarm <= 0 && Vault <=0 && Security <=0); }
        }
    }
}
