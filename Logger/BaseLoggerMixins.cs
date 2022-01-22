using System;

namespace Logger;
public static class BaseLoggerMixins
{

    //    if(BaseLogger.parameter is null)
    //       throw new NotImplementedException();


    //Error


    //Warning




    //Information





    //Debug
    public static void Debug(this BaseLogger logger, string message, params int[] moreStuff )
    {
        message = string.Format(message, moreStuff);
        logger.Log(LogLevel.Debug, message);
    }
}

