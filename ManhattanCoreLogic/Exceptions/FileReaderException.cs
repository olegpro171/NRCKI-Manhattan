using System;

namespace ManhattanCoreLogic.Exceptions;

public class FileReaderException : Exception
{
    public FileReaderException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
