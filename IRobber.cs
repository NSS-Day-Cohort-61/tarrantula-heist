using System;
/*
A string property for Name
An integer property for SkillLevel
An integer property for PercentageCut
A method called PerformSkill that takes in a Bank parameter and doesn't return anything.
*/
namespace Heist
{
    public interface IRobber
    {
        
        string Name { get; set; }

        int SkillLevel { get; set; }

        int PercentageCut { get; set; }

        void PerformSkill(Bank bank);

    }
}