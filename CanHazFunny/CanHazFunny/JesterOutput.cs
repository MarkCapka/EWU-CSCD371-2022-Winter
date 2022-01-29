namespace CanHazFunny;

using System;


//TODO NULL CHECK
public class JesterOutput : IJesterOutput
{

    JokeService joke = new();
  //  joke = JokeService.GetJoke(); //TODO not sure this belongs here. 

    public void WriteLine(string? writtenLine)
    {
        Console.WriteLine(writtenLine);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }



    public string? JesterOutput(JokeService joke)
    {
        Console.WriteLine(joke);
        return joke.GetJoke();
        
    
    }



}

