
namespace CanHazFunny;
using System;



public class Jester : IJesterOutput, IJokeService
{
    
    public JokeService JokeService { get { return new (); } }


    public void TellJoke()
    {
        string joke = GetJoke();
        JesterPrint(joke);
    }

    public void JesterPrint(string joke)
    {

        Console.WriteLine(joke);
    }

    public string GetJoke()
    {
        return ((IJokeService)JokeService).GetJoke();
    }
}

