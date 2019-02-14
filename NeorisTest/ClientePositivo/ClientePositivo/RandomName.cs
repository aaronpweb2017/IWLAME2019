using System;

namespace ClientePositivo
{
    class RandomName
    {
        string[] maleNames;
        string[] femaleNames;
        string[] lastNames;
        Random rand;
        public RandomName()
        {
            maleNames = new string[20] { "Jacob", "Michael", "Joshua", "Matthew", "Christopher", "Andrew", "Daniel", "Ethan", "Joseph", "William", "Anthony", "Nicholas", "David", "Alexander", "Ryan", "Tyler", "James", "John", "Jonathan", "Brandon" };
            femaleNames = new string[20] { "Emily", "Madison", "Emma", "Hannah", "Olivia", "Abigail", "Isabella", "Ashley", "Samantha", "Elizabeth", "Sarah", "Alyssa", "Grace", "Sophia", "Taylor", "Brianna", "Lauren", "Ava", "Kayla", "Jessica" };
            lastNames = new string[20] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson" };
            rand = new Random(DateTime.Now.Second);
        }
        public String GetRandomName()
        {
            if (rand.Next(1, 2) == 1)
                return maleNames[rand.Next(0, maleNames.Length - 1)] + " "
                    + lastNames[rand.Next(0, lastNames.Length - 1)];
            else
                return femaleNames[rand.Next(0, femaleNames.Length - 1)] + " "
                    + lastNames[rand.Next(0, lastNames.Length - 1)];
        }
    }
}

