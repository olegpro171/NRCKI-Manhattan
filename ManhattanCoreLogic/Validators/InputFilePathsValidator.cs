using System;
using ManhattanCoreLogic.ExportDataStructures;

namespace ManhattanCoreLogic.Validators;

public class InputFilePathsValidator
{
    static List<ErrorReport>? errorReports;

    public static void Validate(InputData inputData, List<ErrorReport> ReportList)
    {
        errorReports = ReportList;
        
        ValidateFilePath(inputData.AlbumProgramFileName, "Неверно указан путь к исполняемому файлу альбома");
        ValidateFilePath(inputData.AlbumTaskFileName, "Неверно указан путь к файлу шаблона конфигурации альбома");
       

        foreach (var permakFile in inputData.PermakFileNames)
        {
            ValidateFilePath(permakFile, "Неверно указан путь к одному из файлов расчета по пермаку");
        }

        int c = 1;
        foreach (var BIPRFile in inputData.BIPRCalculatons)
        {
            ValidateFilePath(BIPRFile.FullFileName, $"В записи параметров БИПР №{c} неверно указан путь к файлу расчета маневра по БИПРу");
            ValidateFilePath(Path.GetDirectoryName(BIPRFile.AlbumOutputDirectory), $"В записи параметров БИПР №{c} неверно указан путь директории вывода для Альбома");
        }
    }

    private static void ValidateFilePath(string path, string errMsg)
    {
        if (!Path.Exists(path))
        {
            if (errorReports != null)
                errorReports.Add(new ErrorReport($"Ошибка: {errMsg}.\nУказанный путь: \"{path}\"."));
            else
                throw new Exception($"Ошибка валидации указанного пути. Пользовательское сообщение об ошибке:\n{errMsg}.\nОтсутствует список отчетов.");
            
        }
    }
}
