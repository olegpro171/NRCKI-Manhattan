using System;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace ManhattanCoreLogic.Validators;

internal static class GenericValidator
{
    public static void ValidateFilePath(List<ErrorReport> errorReports, string path, string errMsg)
    {
        if (!Path.Exists(path))
        {
            errorReports.Add(new ErrorReport($"Ошибка: {errMsg}.\nУказанный путь: \"{path}\"."));
        }
    } 
}
