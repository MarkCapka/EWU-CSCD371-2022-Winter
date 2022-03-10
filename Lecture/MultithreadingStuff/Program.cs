
using System.Diagnostics;
using System.Net;

public class Program
{
    static int iterationCount = 0;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        CancellationTokenSource cancellationTokenSource =
            new CancellationTokenSource();

        Task<int> taskDisplay = Task.Run(
            () => Display('.', cancellationTokenSource.Token)
            );

        static void Decrement()
        {
            while (true)
            {
                Console.Write('-');
                iterationCount--;
            }
        };
        Task taskDecrement = Task.Run(Decrement);

        iterationCount--;
        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
        cancellationTokenSource.Cancel();
        iterationCount = taskDisplay.Result;
        Console.WriteLine($"IterationCount = {iterationCount}");
        Console.WriteLine("Exiting!!!");
    }
    static int Display(char character, CancellationToken cancellationToken)
    {
        iterationCount = 0;
        Thread.CurrentThread.Name = "DisplayThread";
        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write(character);
            iterationCount++;
        }
        return iterationCount;
    }


    public int StartProcess(int interations)
    {
        Process process = Process.Start("ping", "google.com");
        //other code; Note that there is no task here. Processes are Asynchronous, but we don't need a task to make asynchronous processes? I thinK?
        process.WaitForExit();
        return process.ExitCode;
    }


    public void DownloadFile()
    {
        WebClient webClient = new WebClient();
        Task task = webClient.DownloadFileTaskAsync(new Uri("IntelliTect.com"), "intellitect.html");
            //do other stuff here



        //NOTE NEVE EVER DO THIS: 
            //DON'T DO THIS: Task.Run(()=>webClient.DownlaodFile(new Uri("IntelliTect.com"), "intellitect.html"));
                //DON'T if Asynch is available Do the above because we are going outside of the API that was written for the library. 
                    //inside the method we never know or think abou tasks

        task.Wait();
    }

}

