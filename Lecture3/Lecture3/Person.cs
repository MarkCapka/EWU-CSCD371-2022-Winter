namespace Lecture1
{
    public class Person
    {
        (string, string)[] Passwords = new[] { 
            ("Inigo Montoya", "YouKilledMyF@ther!")
        }; 

        public bool Login(string userName, string password)
        {
            return password == "YouKilledMyF@ther!";
        }
    }
}