using System;
using ManhattanCoreLogic.ExportDataStructures;
using static ManhattanCoreLogic.Validators.GenericValidator;

namespace ManhattanCoreLogic.Validators;

public class BIPRValidator : IValidator
{
    public void Validate(InputData inputData, List<ErrorReport> ReportList)
    {
        int c = 1;
        foreach (var BIPRFile in inputData.BIPRCalculatons)
        {
            ValidateFilePath(ReportList, BIPRFile.FullFileName, $"В записи параметров БИПР №{c} неверно указан путь к файлу расчета маневра по БИПРу");
            //ValidateFilePath(ReportList, Path.GetDirectoryName(BIPRFile.AlbumOutputDirectory) ?? string.Empty, $"В записи параметров БИПР №{c} неверно указан путь директории вывода для Альбома");

            if (BIPRFile.FinalSost <= 0)
                ReportList.Add(new ($"Ошибка в полях NumSost записи параметров БИПР №{c} неверно указан номер конечного состояния. ({BIPRFile.FinalSost})"));

            if (BIPRFile.PowerRestoreNumSost <= 0)
                ReportList.Add(new ($"Ошибка в полях NumSost записи параметров БИПР №{c} неверно номер состояния выхода на номинальную мощность. ({BIPRFile.PowerRestoreNumSost})"));

            if (BIPRFile.FinalSost < BIPRFile.PowerRestoreNumSost)
                ReportList.Add(new ($"Ошибка в полях NumSost записи параметров БИПР №{c}. FinalSost < PowerRestoreNumSost ({BIPRFile.PowerRestoreNumSost}; {BIPRFile.FinalSost})"));

            c++;
        }


    }
}
