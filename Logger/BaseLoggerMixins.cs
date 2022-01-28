namespace Logger;
public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params Object[] arrayParameters)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (message is null) throw new ArgumentNullException(nameof(logger));
        message = String.Format(message, arrayParameters);
        logger.Log(LogLevel.Error, message);
    }

    public static void Warning(this BaseLogger logger, string message, params Object[] arrayParameters)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (message is null) throw new ArgumentNullException(nameof(logger));
        message = String.Format(message, arrayParameters);
        logger.Log(LogLevel.Warning, message);
    }

    public static void Information(this BaseLogger logger, string message, params Object[] arrayParameters)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (message is null) throw new ArgumentNullException(nameof(logger));
        message = String.Format(message, arrayParameters);
        logger.Log(LogLevel.Information, message);
    }

    public static void Debug(this BaseLogger logger, string message, params Object[] arrayParameters)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (message is null) throw new ArgumentNullException(nameof(logger));
        message = String.Format(message, arrayParameters);
        logger.Log(LogLevel.Debug, message);
    }
}

