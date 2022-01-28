namespace Logger.Tests;

public interface IExecuteProcessActivity : IWorkflowActivity
{
    protected void ExecuteProcess();

    protected void RedirectStandardInOut() => Console.WriteLine("IExecuteProcessActivity.RedirectStandardInOut()");

    void IWorkflowActivity.InternalRun()
    {
        RedirectStandardInOut();
        ExecuteProcess();
        RestoreStandardInOut();
    }

    protected void RestoreStandardInOut() => Console.WriteLine("IExecuteProcessActivity.RestoreStandardInOut()");

}