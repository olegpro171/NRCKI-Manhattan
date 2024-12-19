using System;
using ManhattanCoreLogic.ExportDataStructures;
using static ManhattanCoreLogic.Validators.GenericValidator;

namespace ManhattanCoreLogic.Validators;

public class InputFilePathsValidator : IValidator
{
    static List<ErrorReport>? errorReports;

    public void Validate(InputData inputData, List<ErrorReport> ReportList)
    {
        ValidateFilePath(ReportList, inputData.AlbumProgramFileName, "Неверно указан путь к исполняемому файлу альбома");
        ValidateFilePath(ReportList, inputData.AlbumTaskFileName, "Неверно указан путь к файлу шаблона конфигурации альбома");
       
        int c = 1;
        foreach (var permFileName in inputData.PermakFileNames)
        {
            ValidateFilePath(ReportList, permFileName, $"Неверно указан путь к файлу расчета по пермаку №{c}. Указанный путь:\n{permFileName}");
            c++;
        }
    }
}
