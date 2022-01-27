using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public class ConsoleIO : IConsoleIO
{
    public void WriteLine(string? writtenLine)
    {
        Console.WriteLine(writtenLine);
    }

    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public static implicit operator ConsoleIO(ConsoleLogger v)
    {
        throw new NotImplementedException();
    }
}