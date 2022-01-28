namespace Logger;

public interface IExecuteProcessActivity : IWorkflowActivity
{

    protected void RedirectStandardInOut()
    {
        Console.WriteLine("IExecuteProcessActivity.RedirectStandardInOut()");
    }

    void IWorkflowActivity.InternalRun()
    {
        RedirectStandardInOut();
        ExecuteProcess();
        RestoreStandardInOut();
    }
    
    
    protected void ExecuteProcess();
    protected void RestoreStandardInOut()
    {
        Console.WriteLine("IExecuteProcessActivity.RestoreStandardInOut()");
    }
}