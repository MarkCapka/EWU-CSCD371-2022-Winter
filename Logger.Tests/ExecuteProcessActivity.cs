using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    class ExecuteProcessActivity : IExecuteProcessActivity
    {
        public ExecuteProcessActivity(string executablePath) 
            => ExecutableName = executablePath ?? throw new ArgumentNullException(nameof(executablePath));

        public string ExecutableName { get; }

        void IExecuteProcessActivity.ExecuteProcess()
        {
            Console.WriteLine();
        }

        void IExecuteProcessActivity.RedirectStandardInOut()=>Console.WriteLine($"ExecuteProcessActivity.ExecuteProcess()");

    }
}
