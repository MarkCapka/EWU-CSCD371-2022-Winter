using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintItUntilYouDont;
public class PrintItUntilYouDont
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");


        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


        Task task = Task.Run(
             () => Display('.', cancellationTokenSource.Token)); //issuing a single token to the display method
            

        Console.WriteLine("Enter to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel(); //this will cancel any available tokens withing the method. 
        task.Wait();
        Console.WriteLine("Exiting");

    }


//NOTE: cancellationToken gives us access to the cancellationToken, it is NOT the cancellationTokenSource itself
    static void Display(char character, CancellationToken cancellationToken)
    {
        while (true)
        {
            Console.Write(character);
        }
    }
}

