using System;
using System.Collections.Generic;
using System.Linq;


namespace Heist
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hacker Jenny = new Hacker("Jenny", 100, 30);
            Muscle Logan = new Muscle("Logan", 80, 25);
            LockSpecialist Nelson = new LockSpecialist("Nelson", 12, 0);
            LockSpecialist Jacob = new LockSpecialist("Babbs", 45, 30);
            Muscle Val = new Muscle("Val", 85, 10);
            Hacker Steve = new Hacker("Coach", 99, 40);

            List<IRobber> Rolodex = new List<IRobber>
          {
            Jenny, Logan, Nelson, Jacob, Val, Steve
          };

            while (true)
            {
                System.Console.WriteLine($"There are currently {Rolodex.Count} operatives to choose from for your heist.");
                System.Console.WriteLine("Enter the name of a new crew member!");
                string Name = Console.ReadLine();
                if (Name == "")
                {
                    break;
                }
                System.Console.WriteLine(@"Choose your new crew members specialty! (1-3)
        1.Hacker (Disables alarms)
        2. Muscle (Disarms guards)
        3. Lock Specialist (cracks vault)");
                int specialtyInt = int.Parse(Console.ReadLine());
                System.Console.WriteLine("What is your new crew members skill level? (0-100)");
                int skillLevelInt = int.Parse(Console.ReadLine());
                System.Console.WriteLine("What percentage of the cut is your crew member taking? (0-100)");
                int percentCut = int.Parse(Console.ReadLine());

                if (specialtyInt == 1)
                {
                    Hacker newMember = new Hacker(Name, skillLevelInt, percentCut);
                    Rolodex.Add(newMember);
                }
                else if (specialtyInt == 2)
                {
                    Muscle newMember = new Muscle(Name, skillLevelInt, percentCut);
                    Rolodex.Add(newMember);
                }
                else if (specialtyInt == 3)
                {
                    LockSpecialist newMember = new LockSpecialist(Name, skillLevelInt, percentCut);
                    Rolodex.Add(newMember);
                }
            }
            int cash = RandomNum(50000, 1000000);
            int alarm = RandomNum(0, 100);
            int vault = RandomNum(0, 100);
            int security = RandomNum(0, 100);
            Bank bank = new Bank(cash, alarm, vault, security);

            Dictionary<string, int> BankDifficulties = new Dictionary<string, int>
            {
                {"Alarm", alarm},
                {"Vault", vault},
                {"Security Guard", security}
            };

            var sortedBankDifficulties = BankDifficulties.OrderByDescending(x => x.Value);

            System.Console.WriteLine($"RECON REPORT: {sortedBankDifficulties.First().Key} is the most secure, {sortedBankDifficulties.Last().Key} is the least secure");

            /*
            Print out a report of the rolodex that includes each person's name, specialty, skill level, and cut. 
            Include an index in the report for each operative so that the user can select them by that index in the next step. 
            (You may want to update the IRobber interface and/or the implementing classes to be able to print out the specialty)*/
            List<IRobber> crew = new List<IRobber>();
            int cutSum = 0;

            while (Rolodex.Any())
            {

                Console.WriteLine("Available Operatives");
                foreach (var person in Rolodex.Select((Value, Index) => (Value, Index)))
                {

                    Console.WriteLine($"Operative ID: {person.Index + 1} Name: {person.Value.Name} / Specialty: {person.Value.GetType().Name} / Skill Level: {person.Value.SkillLevel} / Cut: {person.Value.PercentageCut}");
                }


                Console.WriteLine("Choose an operator's ID to add to your heist crew, or hit ENTER to stop adding members.");
                int OpId = int.Parse(Console.ReadLine());
                if (OpId.ToString() == "")
                {
                    break;
                }

                crew.Add(Rolodex[OpId - 1]);
                cutSum += Rolodex[OpId - 1].PercentageCut;
                Rolodex.Remove(Rolodex[OpId - 1]);
                Rolodex = Rolodex.Where(person => person.PercentageCut + cutSum <= 100).ToList();
            }

            foreach (var person in crew)
            {
                person.PerformSkill(bank);
            }

            if (bank.IsSecure)
            {
                System.Console.WriteLine("W A S T E D");
            }
            else
            {
                System.Console.WriteLine("You're rich or something! yeehaw.");
                double bankCash = Convert.ToDouble(bank.COH);
                double playerPayout = bankCash;

                foreach (IRobber member in crew)
                {
                    double memberPercentage = Convert.ToDouble(member.PercentageCut);
                    double memberCut = bankCash * (memberPercentage / 100);
                    playerPayout -= memberCut;
                    Console.WriteLine($"{member.Name} is taking ${memberCut}");
                }

                Console.WriteLine($"You got ${playerPayout}");
            }

        }
        static int RandomNum(int num, int limit)
        {
            return new Random().Next(num, limit);
        }



    }
}



