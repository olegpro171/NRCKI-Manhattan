using System;

namespace ManhattanCoreLogic.Validators;

public struct ErrorReport
{
    public readonly Exception? ex;
    public readonly string Message;

    public ErrorReport(string message)
    {
        Message = message;
    }

    public ErrorReport(Exception ex, string message)
    {
        this.ex = ex;
        Message = message;
    }
}
