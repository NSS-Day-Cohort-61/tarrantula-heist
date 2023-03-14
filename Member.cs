using System;


namespace Heist
{
    class Member
    {
        public Member(string newName, int newSkill, double newCourage)
        {
            name = newName;
            skill = newSkill;
            courage = newCourage;
        }
        public string name { get; set; }
        public int skill { get; set; }
        public double courage { get; set; }
    }
}
