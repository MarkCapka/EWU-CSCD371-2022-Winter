namespace Logger;
using System;
public interface IWorkflowActivity
{
    private void Start()
    {
        Console.WriteLine("IWorkflowActivity.Start()");
    }


    //void WriteLine(string writtenLine);
    //string ReadLine();


    //sealed prevents overriding
    sealed void Run()
    {
        try
        {
            Start();
            InternalRun();
        }
        finally
        {
            Stop();
        }
    }
    private void Stop() => Console.WriteLine("IWorkflowActivity.Stop()");
    protected void InternalRun();
}


