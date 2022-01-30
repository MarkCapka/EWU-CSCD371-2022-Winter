
namespace CanHazFunny;
using System;



public class Jester 
{
    private IJesterOutput _JesterOutput;
    private IJokeService _JokeService;
    
    public IJokeService JokeService { get { return _JokeService; } }
    public IJesterOutput JesterOutput { get { return _JesterOutput; } }


    public Jester(IJesterOutput jesterOutput, IJokeService jokeService)
    {
        _JesterOutput = jesterOutput ?? throw new ArgumentNullException(nameof(jesterOutput));
        _JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));

    }

    public void TellJoke()
    {
        string joke = JokeService.GetJoke();


        JesterOutput.JesterPrint(joke);
    }

   
}

