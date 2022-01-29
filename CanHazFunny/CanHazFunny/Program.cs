namespace CanHazFunny;
using System;

    class Program
    {
        static void Main(string[] args)
        {
        //Confirming that the joke writer works. - writes to .exe
            JokeService jokeService = new();
            Console.Write(jokeService.GetJoke());
            
        
        //Feel free to use your own setup here - this is just provided as an example
            new Jester(new JesterOutput(), new JokeService()).TellJoke();
        }
    }

