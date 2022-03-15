using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment;


//Assignment 9+10: .NET PROGRAMMING CSCD371      //The purpose of this assignment is to solidify your learning of multithreaded programing with the Task Parallel Library (TPL).

//Tyler Rose & Mark Capka           //--students
//@TylerRose8    //@MarkCapka      //--github

//.NET 6.0  MSTest Visual Studio 2022

//Assignment 9&10

//Due Dates
//Assignment 9&10 is due (even though you are pairing) Monday March 21, 11:59 PM.
//Code reviews (be everyone individually) are due Wednesday March 23, 11:59 PM. (Thus all PRs will be reviewed twice.)
//Final PR is due Thursday March 24, 11:59 PM.
//The combination of Assignment 9&10 will be graded - starting Friday March 24.

//Reading
//Chapter 19: Introducing Multithreading
//Chapter 21: Iterating in Parallel
//Previously Assigned
//Chapter 20: Programming with Task-Based Asynchronous Pattern
//Chapter 22: Thread Synchronization

//Extra Credit
//Test and implement PingProcess.RunAsync(System.IProgress<T> progess) so that you can capture the output as it occurs rather than capturing the output only when the process finishes. ❌✔
//Fundamentals
//Ensure you enable:
//nullable reference types is enabled ❌✔
//net6 targeted ❌✔
//C# 10.0 ❌✔
//and enabled.NET analyzers for both projects ❌✔
//All of the above should be unit tested ❌✔
//Choose simplicity over complexity ❌✔

public record struct PingResult(int ExitCode, string? StdOutput);

public class PingProcess
{
    private ProcessStartInfo StartInfo { get; } = new("ping");

    public PingResult Run(string hostNameOrAddress)
    {
        StartInfo.Arguments = hostNameOrAddress;
        StringBuilder? stringBuilder = null;
        void updateStdOutput(string? line) =>
            (stringBuilder ??= new StringBuilder()).AppendLine(line);
        Process process = RunProcessInternal(StartInfo, updateStdOutput, default, default);
        return new PingResult(process.ExitCode, stringBuilder?.ToString());
    }


    /*
     * 1. TODO Implement PingProcess' public Task<PingResult> RunTaskAsync(string hostNameOrAddress) ❌✔
             First implement public void RunTaskAsync_Success() test method to test PingProcess.RunTaskAsync() using "localhost". ❌✔
             Do NOT use async/await in this implementation. ❌✔
     */






    public Task<PingResult> RunTaskAsync(string hostNameOrAddress)
    {
        throw new NotImplementedException();



    } 
    
    
    
    /*             NOTE from Mark not the lads: I THINK THIS IS 2. the brackets are missing but there doesn't seem to be another one. Double check this though
    *   TODO   2. Implement PingProcess' async public Task<PingResult> RunAsync(string hostNameOrAddress) ❌✔
            First implement the public void RunAsync_UsingTaskReturn_Success() test method to test PingProcess.RunAsync() using "localhost" without using async/await. ❌✔
             Also implement the async public Task RunAsync_UsingTpl_Success() test method to test PingProcess.RunAsync() using "localhost" but this time DO using async/await. ❌✔
     */

    // TODO 3. Add support for an optional cancellation token to the PingProcess.RunAsync() signature. ❌✔
    // Inside the PingProcess.RunAsync() invoke the token's ThrowIfCancellationRequested() method so an exception is thrown. ❌✔
    // Test that, when cancelled from the test method, the exception thrown is an AggregateException ❌✔
    // with a TaskCanceledException inner exception ❌✔ using the test methods RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping ❌✔
    // and RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException ❌✔
    // respectively.

    // TODO  4.  Complete/fix AND test async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)
    //              which executes ping for and array of hostNameOrAddresses(which can all be "localhost") in parallel, adding synchronization if needed. ❌✔
    //              NOTE: The order of the items in the stdOutput is irrelevent and expected to be intermingled.
                    //StdOutput must have all the ping output returned (no lines can be missing) even though intermingled. ❌✔
    async public Task<PingResult> RunAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        Task task = null!;
        await task;
        throw new NotImplementedException();
    }



    async public Task<PingResult> RunAsync(params string[] hostNameOrAddresses)
    {
        StringBuilder? stringBuilder = null;
        ParallelQuery<Task<int>>? all = hostNameOrAddresses.AsParallel().Select(async item =>
        {
            Task<PingResult> task = null!;
        // ...

        await task.WaitAsync(default(CancellationToken));
            return task.Result.ExitCode;
        });

        await Task.WhenAll(all);
        int total = all.Aggregate(0, (total, item) => total + item.Result);
        return new PingResult(total, stringBuilder?.ToString());
    }



    //TODO 5. Implement AND test public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token) using Task.Factory.StartNew()
            //and invoking RunProcessInternal with a TaskCreation value of TaskCreationOptions.LongRunning and a
            //TaskScheduler value of TaskScheduler.Current.NOTE: This method does NOT use Task.Run.
    async public Task<PingResult> RunLongRunningAsync(
        string hostNameOrAddress, CancellationToken cancellationToken = default)
    {
        Task task = null!;
        await task;
        throw new NotImplementedException();
    }

    private Process RunProcessInternal(
        ProcessStartInfo startInfo,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        var process = new Process
        {
            StartInfo = UpdateProcessStartInfo(startInfo)
        };
        return RunProcessInternal(process, progressOutput, progressError, token);
    }

    private Process RunProcessInternal(
        Process process,
        Action<string?>? progressOutput,
        Action<string?>? progressError,
        CancellationToken token)
    {
        process.EnableRaisingEvents = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorHandler;

        try
        {
            if (!process.Start())
            {
                return process;
            }

            token.Register(obj =>
            {
                if (obj is Process p && !p.HasExited)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Win32Exception ex)
                    {
                        throw new InvalidOperationException($"Error cancelling process{Environment.NewLine}{ex}");
                    }
                }
            }, process);


            if (process.StartInfo.RedirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }
            if (process.StartInfo.RedirectStandardError)
            {
                process.BeginErrorReadLine();
            }

            if (process.HasExited)
            {
                return process;
            }
            process.WaitForExit();
        }
        catch (Exception e)
        {
            throw new InvalidOperationException($"Error running '{process.StartInfo.FileName} {process.StartInfo.Arguments}'{Environment.NewLine}{e}");
        }
        finally
        {
            if (process.StartInfo.RedirectStandardError)
            {
                process.CancelErrorRead();
            }
            if (process.StartInfo.RedirectStandardOutput)
            {
                process.CancelOutputRead();
            }
            process.OutputDataReceived -= OutputHandler;
            process.ErrorDataReceived -= ErrorHandler;

            if (!process.HasExited)
            {
                process.Kill();
            }

        }
        return process;

        void OutputHandler(object s, DataReceivedEventArgs e)
        {
            progressOutput?.Invoke(e.Data);
        }

        void ErrorHandler(object s, DataReceivedEventArgs e)
        {
            progressError?.Invoke(e.Data);
        }
    }

    private static ProcessStartInfo UpdateProcessStartInfo(ProcessStartInfo startInfo)
    {
        startInfo.CreateNoWindow = true;
        startInfo.RedirectStandardError = true;
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.WindowStyle = ProcessWindowStyle.Hidden;

        return startInfo;
    }
}