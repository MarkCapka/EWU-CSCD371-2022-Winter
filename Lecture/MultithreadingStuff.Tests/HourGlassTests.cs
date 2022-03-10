using System.Threading;
using System.Threading.Tasks;


namespace MultithreadingStuff.Tests;
[TestClass]
public class HourGlassTests
{




    public TestContext? TestContext { get; set; }

    [TestMethod]
    public void CallDisplayAsync()
    { //Thread 1 
        Task task = DisplayAsync();
        //while the thread is running
        task.Wait();
        //After thread Completes
    }

     //THIS DOES NOT CONCERN ITSELF WITH LOCKS OR SYNCHRONIZING
    [TestMethod]
    async public Task DisplayAsync()
    {
        //Thread 1 
        CancellationTokenSource cancellationTokenSource =
                    new CancellationTokenSource();

        HourGlass hourGlass = new HourGlass();
        int task =
            await hourGlass.DisplayAsync('.', cancellationTokenSource.Token);
        //Thread 1 
        //timer to avoid waiting too long
        //the user pressed ENTER to escape

        cancellationTokenSource.Cancel();
        //  int iterationCount = await task.WaitAsync(default(CancellationToken));

        //IF THERE IS AN ASYNCH METHOD YOU SHOULD FAVOR THIS OVER NON-ASYNC
        //ASYNC: api is telling you that the process could take a long time to run. 
        //#or i can do this work on a different CPU (i.e. graphics for example)

        //NOT using TASK this here has our wait saying that "wait until our code finishes running to sit in "wait" 

        //int iterationCount =
        //   await hourGlass.DisplayAsync('.', cancellationTokenSource.Token);
        //cancellationTokenSource.Cancel();
        //cancellationTokenSource.Cancel();
        //Assert.IsTrue(iterationCount > 0);



        //When to use TASK: rarely:    if doing process intensive or takes a long time and doesn't have Asynch built into it, use Task, most of the time there is a built in method

        //VAST MAJORITY OF TIMES, YOU ARE JUST LOOKING FOR A PREWRITTEN ASYNCH METHOD. 

        //Note: data is processed kind of upside down, in that you load your result last when returning a Task. 


        ////NOT Thread 1 
        int counter = 0;
        TestContext?.WriteLine($"{counter++}");
        TestContext?.WriteLine($"{counter++}");
        TestContext?.WriteLine($"{counter++}");
        TestContext?.WriteLine($"{counter++}");
        //iterationCount = task.Result;
    }

    async public Task DisplayTaskAsync()
    {
        HourGlass hourGlass = (HourGlass)new HourGlass();   

    }



}
