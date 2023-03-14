using System;

namespace Heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public Muscle(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
        }

        public void PerformSkill(Bank bank)
        {
            bank.Security -= SkillLevel;
            Console.WriteLine($"{Name} is taking out the guards. Decreased security by {SkillLevel} points");

            if (bank.Security <= 0)
            {
                Console.WriteLine($"{Name} has taken out all the guards!");
            }
        }
    }
}