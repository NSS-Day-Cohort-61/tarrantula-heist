using System;
using System.Collections.Generic;


namespace Heist
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Member> HeistCrew = new List<Member>();





            Console.WriteLine("Plan your heist!!!");
        another:
            Console.WriteLine("Choose difficulty level: 1 = easy, 2 = average, 3 = difficult");
            int difficulty = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("What's your patsy's name?");
            string name = Console.ReadLine();
            Console.WriteLine("How good they is? 1-100");
            int skill = int.Parse(Console.ReadLine());
            Console.WriteLine("How Not Scared Are They? 0.0 - 2.0");
            double courage = double.Parse(Console.ReadLine());
            Console.WriteLine(@$"

Name: {name} 
Skill Level: {skill} 
Courage Factor: {courage}");
            Member member = new Member(name, skill, courage);

            HeistCrew.Add(member);
            Console.WriteLine("Do you need another member? Yes/No");
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                goto another;
            }
            else
            {
                Console.WriteLine("---------------------------");
                Console.Clear();
                Console.WriteLine($"You have {HeistCrew.Count} partners in crime");

            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            Console.WriteLine("It's time to prepare. How many trial runs do you want to do? (0-5)");
            int TrialRuns = int.Parse(Console.ReadLine());
            foreach (var crewMem in HeistCrew)
            {
                Console.WriteLine(@$"
Name: {crewMem.name},
Skill level: {crewMem.skill},
Courage Factor: {crewMem.courage}");
                Console.WriteLine("---------");
            }
            int success = 0;
            int failure = 0;

            while (TrialRuns > 0)
            {
                Random r = new Random();
                int Luck = r.Next(-10, 10);
                int BankSecurity = 100;
                if (difficulty == 1)
                {
                    BankSecurity = 100;
                }
                else if (difficulty == 2)
                {
                    BankSecurity = 200;
                }
                else 
                {
                    BankSecurity = 300;
                }


                BankSecurity += Luck;


                int CrewSkill = 0;
                foreach (var crewMem in HeistCrew)
                {
                    CrewSkill += crewMem.skill;
                }

                Console.WriteLine($"The bank's security level is {BankSecurity}, and your crew has {CrewSkill} skill");
                if (CrewSkill > BankSecurity)
                {
                    Console.WriteLine("The heist was a success!");
                    TrialRuns--;
                    success++;
                    
                    
                }

                else
                {
                    Console.WriteLine($"{HeistCrew[0].name} tripped the alarm! You're all screwed!");
                    TrialRuns--;
                    failure++;
                }
            }
            Console.WriteLine(@$"
success: {success} 
failure: {failure}");
        }
    }
}



