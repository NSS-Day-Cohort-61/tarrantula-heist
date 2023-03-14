﻿using System;
using System.Collections.Generic;


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

        }
    }
}



