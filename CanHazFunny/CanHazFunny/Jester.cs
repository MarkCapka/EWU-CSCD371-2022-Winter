
namespace CanHazFunny;
using System;



public class Jester : IJesterOutput
{
    
    public JokeService JokeService { get { return new (); } }

    public void TellJoke()
    {
        string joke = JokeService.GetJoke();
        JesterPrint(joke);
    }

    public void JesterPrint(string joke)
    {

        Console.WriteLine(joke);
    }
}

