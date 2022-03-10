using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingStuff;

public class HourGlass
{
   

    async public Task<int> DisplayAsync(char character, CancellationToken cancellationToken)
    {
        int iterationCount = 0;
        Thread.CurrentThread.Name = "DisplayThread";

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }

   
}
    //async public int DisplayAsync(char character, CancellationToken cancellationToken)
    //{
    //    int iterationCount = 0;
    //    Thread.CurrentThread.Name = "DisplayThread";

    //    while (!cancellationToken.IsCancellationRequested)
    //    {
    //        Console.Write(character);
    //        iterationCount++;
    //    }
    //    return iterationCount;
    //}

//}
