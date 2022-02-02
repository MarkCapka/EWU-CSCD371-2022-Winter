namespace CanHazFunny;
using System;

    class Program
    {
        public static void Main(string[] args)
        {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }
        //Confirming that the joke writer works. - writes to .exe
        //JokeService jokeService = new();
        //Console.Write(jokeService.GetJoke());


        //Feel free to use your own setup here - this is just provided as an example
        new Jester().TellJoke();
          //  jester = new Jester(jesterOutput, joke).TellJoke();            //IJester.JesterOutput jesterOutput = new JesterOutput()                   //IJokeService.JokeService joke = new JokeSerivce()     //Console.WriteLine(joke) call
        }
    }

