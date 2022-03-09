using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintItUntilYouDont;
public class PrintItUntilYouDont
{
    static int IterationCount;
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        Task<int> task = Task.Run(
                 () =>                  
                         Display('.', cancellationTokenSource.Token)
             ); //issuing a single token to the display method


        //his code: 
        static void Decrement()
        {
            while (true)
            {
                Console.Write('-');

            }
        }



        Task decrementCount = Task.Run(
            () =>
                DecrementCount(cancellationTokenSource.Token)
              );

        Console.WriteLine("Enter to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel(); //this will cancel any available tokens withing the method. 
        IterationCount = task.Result;
        Console.WriteLine($"IterationCount = {IterationCount}");
        //task.Wait();
        Console.WriteLine("Ex(c)iting!!");


       

    }

    static void DecrementCount(CancellationToken cancellationToken)
    {
        
        Thread.CurrentThread.Name = "DecrementResult";
        
        IterationCount--;

        DecrementCount(cancellationToken);
    }


    //NOTE: cancellationToken gives us access to the cancellationToken, it is NOT the cancellationTokenSource itself
    static int Display(char character, CancellationToken cancellationToken)
    {
        IterationCount = 0;
        Thread.CurrentThread.Name = "Result";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            IterationCount++;
        }
        return IterationCount;
    }

    public int StartProcess()
    {
        Process process = Process.Start("ping", "google.com"); //This is a synchronous call. This starts the process

             //our homework will be doing it Asynchronous with Task. 

        process.WaitForExit(); //method doesn't keep go until the process is exited
        return process.ExitCode; //then return the code.
    }
}

