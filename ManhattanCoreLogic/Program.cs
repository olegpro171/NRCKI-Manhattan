
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using ManhattanCoreLogic;
using ManhattanCoreLogic.ExportDataStructures;
using ManhattanCoreLogic.Validators;

// public string CycleDirectory { get; set; } //   B23/K07 - Cycle Directory;   B23 - Unit Directory
// public string[] PermakFileNames { get; set; }
// public string AlbumProgramFileDirectory { get; set; }
// public string AlbumTaskFileDitectory { get; set; } // Файл конфигурации 
// public BIPRManParams[] BIPRCalculatons { get; set; } 
// public int[] CyclePoints { get; set; } 


namespace ManhattanCoreLogic;

public class Program
{


    static string DefaultTaskFileName = "ManhattanTask.txt";


    private static void WriteSerialized(InputData InputData)
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
        };

        File.WriteAllText(DefaultTaskFileName, JsonSerializer.Serialize(InputData, options: options));
    }

    private static InputData FromFile()
    {
        var fileContent = File.ReadAllText(DefaultTaskFileName);
        return JsonSerializer.Deserialize<InputData>(fileContent);
    }

    private static InputData GetDefaut()
    {
        BIPRManParams[] BIPRTestParams = 
        [
            new() 
            {
                FullFileName = "/Users/oleg/Desktop/B23/K07/XE123",
                //AlbumOutputDirectory = "/Users/oleg/Desktop/B23/K07/AlbumOutput",
                MomentOfCycle = 40,
                PowerRestoreNumSost = 10,
                FinalSost = -1,
            }
        ];


        InputData TestInputData = new()
        {
            CycleDirectory = "/Users/oleg/Desktop/B23/K07",
            PermakFileNames =
            [
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S01",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S02",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S03",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S04",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S05",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S06",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S07",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S08",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S09",
            ],
            CyclePoints = [40, 400, 600],
            BIPRCalculatons = BIPRTestParams,

            AlbumProgramFileName = "/Users/oleg/Desktop/B23/K07/AlbumTest",
            AlbumTaskFileName = "/Users/oleg/Desktop/B23/K07/AlbumConfig",
        };

        return TestInputData;
    }


    private static InputData GetDefautWithErrors()
    {
        BIPRManParams[] BIPRTestParams = 
        [
            new() 
            {
                FullFileName = "/Users/oleg/Desktop/B23/K07/XE123",
                //AlbumOutputDirectory = "/Users/oleg/Desktop/B23/K07/AlbumOutput",
                MomentOfCycle = 40,
                PowerRestoreNumSost = 10,
                FinalSost = -1,
            }
        ];


        InputData TestInputData = new()
        {
            CycleDirectory = "/Users/oleg/Desktop/B23/K07",
            PermakFileNames =
            [
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S01",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S02",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S03",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S04",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S05",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S06",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S07",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S08",
                "/Users/oleg/Desktop/B23/K07/SOSTALG.S09",
            ],
            CyclePoints = [40, 400, 600],
            BIPRCalculatons = BIPRTestParams,

            AlbumProgramFileName = "/Users/oleg/Desktop/B23/K07/AlbumTest",
            AlbumTaskFileName = "/Users/oleg/Desktop/B23/K07/AlbumConfig",
        };

        return TestInputData;
    }



    public static void ReadFromFileAndStart()
    {
        InputData ManhattanTask;
        try
        {
            ManhattanTask = GetDefautWithErrors();
        }
        catch
        {
            Console.WriteLine($"Не найден файл задачи:\n{DefaultTaskFileName}");
            return;
        }

        var TestCore = new ManhattanCoreLogic();

        var errorList = TestCore.ExecuteLogic(ManhattanTask);

        foreach (var item in errorList)
            Console.WriteLine(item.Message);

        Console.WriteLine(TestCore.Logs);
    }



    public static void Main(string[] args)
    {
        try
        {
            ReadFromFileAndStart();
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("");
            Console.WriteLine("Работа завершена.\nНажмите любую кнопку для выхода");
            try
            {
                Console.ReadKey();
            }
            catch { }
        }
    }
}

