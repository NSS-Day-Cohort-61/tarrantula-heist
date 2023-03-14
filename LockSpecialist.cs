using System;

namespace Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public LockSpecialist(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            bank.Vault -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased vault by {SkillLevel} points");

            if (bank.Vault <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vault!");
            }
        }
    }
}