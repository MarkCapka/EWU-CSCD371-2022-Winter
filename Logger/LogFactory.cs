
namespace Logger;
public class LogFactory
{
    public bool FileLoggerIsConfigured { get; private set; }    //TODO shouldn't solve this with a bool: feedback says "you souldn't need a boolean here, see feedback on next line. 


    //general improvement for factories: maybe instead of FilePath: LoggerDestination - that way we could use it in implmentations for URLs, Files, etc. 
        

    private string? FilePath { get; set; }
        //TODO use this line instead       //Make _FilePath nullable and simply check if the path is null or not when determining if the logger has been configured or not. 
    
    
    
    public LogFactory()
    {
        FileLoggerIsConfigured = false; //shouldn't use bool to solve the issue.
    }


    //TODO should this be in the LogFactory? (No) 
    public void ConfigureFileLogger(string? path)
    {
        FilePath = path ?? throw new ArgumentNullException(nameof(path));
        FileLoggerIsConfigured = true;      //TODO change this based on feedback. We are duplicating data in our class, storing the same piece of information two different ways can lead to confusion and make sure they are in sync. 
    }

    public BaseLogger? CreateLogger(string className)
    {
        switch (className) //should utilize switch((FilePath, className))      //using a tuple    //TODO feedbacK: not quite what classname should be used for. should have created an unrelated Enum and passed in an additional parameter
        {
            case "FileLogger":
                if (FileLoggerIsConfigured)
                {                                               //pattern matching below
                    return new FileLogger(FilePath!);
         //Notes for polymorphism
                   //should utilize the below instead.
                   //switch((FilePath, className)) 
                        //case(null, _FilePath):
                        //goto default; 

                        //case:(not null, "FileLogger"):
                         //FileLogger fileLogger = new(className, FilePath)  //should check for null here instead of using a boolean 
                            //return fileLogger;
                        //default: 
                          //return null!;
                }
                break;
            case "ConsoleLogger":
                return new ConsoleLogger();
        }
        return null;
    }
}



