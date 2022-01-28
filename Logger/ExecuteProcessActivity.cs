using System;

namespace Logger
{
    class ExecuteProcessActivity : IExecuteProcessActivity
    {
        public ExecuteProcessActivity(string executablePath) => ExecutableName = executablePath ?? throw new ArgumentNullException(nameof(executablePath));

        public string ExecutableName { get; }
        void IExecuteProcessActivity.RedirectStandardInOut() => Console.WriteLine($"ExecuteProcessActivity.ExecuteProcess()");
        void IExecuteProcessActivity.ExecuteProcess()
        {
            Console.WriteLine($"ExecuteProcessActivity.IExecuteProcessActivity.ExecuteProcess()");
        }

        public void Run()
        {

            ExecuteProcessActivity activity = new ExecuteProcessActivity("dotnet");
            ((IWorkflowActivity)activity).InternalRun();
            //activity.RedirectStandardInOut();
            //activity.ExecuteProcess();
            Console.WriteLine(@$"Executing non-polymorphic Run() with Process '{activity.ExecutableName}'.");
        }

     

    }







}
