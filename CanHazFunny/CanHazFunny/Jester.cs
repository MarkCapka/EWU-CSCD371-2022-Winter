namespace CanHazFunny;

public class Jester : IJesterOutput: IJokeService
{

        public JesterOutput jesterOutput { get; }
        public JokeService joke { get; }
        Jester jester = new();
   

public Jester(JesterOutput jesterOutput, JokeService joke)
    {
        JesterOutput = jesterOutput;
        Joke = joke;

    }




        
    public string tellJoke(jesterOutput, jokeService)
    {
    Jester jester = new();
    JokeService joke = new();
   
    jester.TellJoke(joke);

    string? jokeOut = "write out joke to console: Jester.Telljoke: {0}", joke;

    //fetch joke using GetJoke()
   
    return joke;
        //output joke
    }





   
}
