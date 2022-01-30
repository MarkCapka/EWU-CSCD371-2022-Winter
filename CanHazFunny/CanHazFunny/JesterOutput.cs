using System;

namespace CanHazFunny;

    public class JesterOutput : IJesterOutput
    {
       
        public void JesterPrint(string joke)
        {
             Console.WriteLine(joke);
        }

    }
