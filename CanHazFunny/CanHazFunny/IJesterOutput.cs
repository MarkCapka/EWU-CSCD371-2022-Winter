using System;

namespace CanHazFunny
{

    //should output our JokeService to the screen
    public interface IJesterOutput : IJokeService
    {

        IJesterOutput? JesterOutput { get; }
        string? joke = GetJoke();

        
        JesterOutput jokeOutput = new ();

       
    }
}