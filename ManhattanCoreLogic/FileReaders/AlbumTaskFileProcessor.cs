using System;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using ManhattanCoreLogic.ExportDataStructures;

namespace ManhattanCoreLogic.FileReaders;

internal class AlbumTaskFileProcessor : BaseFileReader
{
    public const char CommentSymbol = '#';

    public string GetFileContent(InputData Params, BIPRManParams BIPRParams)
    {
        string InitialFileContent = base.GetFileContent(Params.AlbumTaskFileName);

        var Lines = InitialFileContent
            .Split(Environment.NewLine)
            .Select(line => line.Trim())
            .ToList();

            
        var LinesClean = Lines.Where(line => !line.TrimStart().StartsWith(CommentSymbol)).ToList();


        var CleanTaskPattern = String.Join(Environment.NewLine, LinesClean);

        var Replacements = GetReplacements(Params, BIPRParams);
        foreach (var (name, value) in Replacements)
        {
            if (value is null)
                throw new ArgumentException($"Параметр, требуемый для подстановки в поле \"{name}\" файла задачи Альбома является null.");
            ReplaceVariableInText(ref CleanTaskPattern, name, value);
        }

        return CleanTaskPattern;
    }


    private static void ReplaceVariableInText(ref string input, string variableName, string replacementValue)
    {
        string pattern = $@"\{{{variableName}\}}";
        input = Regex.Replace(input, pattern, replacementValue);
    }
    
    private static Dictionary<string, string> GetReplacements(InputData Params, BIPRManParams BIPRParams)
    {
        return new()
        {
            { "UnitDirectory", Path.GetDirectoryName(Params.CycleDirectory) },
            { "CycleDirectory", Params.CycleDirectory },
            { "AlbumOutputDirectory", BIPRParams.AlbumOutputDirectory },
            { "Kamp", Path.GetFileName(Params.CycleDirectory) },
            { "File", Path.GetFileName(BIPRParams.FullFileName) },

            { "NumSostMin", BIPRParams.PowerRestoreNumSost.ToString() },
            { "NumSostMax", BIPRParams.FinalSost.ToString() },
            { "SostalgRange", GenerateRange(Params, BIPRParams)}
        };
    }

    private static string GenerateRange(InputData Params, BIPRManParams BIPRParams)
    {
        var BIPRFile = Path.GetFileName(BIPRParams.FullFileName);
        int FinalSost = BIPRParams.FinalSost;
        
        
        if (FinalSost <= 9)
        {
            return $"& {BIPRFile}.S01 - {BIPRFile}.S0{FinalSost},";
        }

        if (FinalSost <= 99)
        {
            return $"& {BIPRFile}.S01 - {BIPRFile}.S{FinalSost},";
        }

        int RemainingSost = FinalSost;
        int CurrentSost = 1;

        var sb = new StringBuilder();
        
        sb.AppendLine($"& {BIPRFile}.S01 - {BIPRFile}.S99,");
        RemainingSost -= 99;
        CurrentSost += 99;

        while (RemainingSost >= 99)
        {
            sb.AppendLine($"& {BIPRFile}.S{CurrentSost} - {BIPRFile}.S{CurrentSost + 99},");
            RemainingSost -= 100;
            CurrentSost += 100;
        }

        if (RemainingSost == 1)
            sb.AppendLine($"& {BIPRFile}.S{FinalSost},");
        else if (RemainingSost > 1)
            sb.AppendLine($"& {BIPRFile}.S{CurrentSost} - {BIPRFile}.S{FinalSost},");


        sb.Remove(sb.Length - 1, 1);
        return sb.ToString();
    }
}
