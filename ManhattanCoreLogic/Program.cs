
using ManhattanCoreLogic;
using ManhattanCoreLogic.ExportDataStructures;

// public string CycleDirectory { get; set; } //   B23/K07 - Cycle Directory;   B23 - Unit Directory
// public string[] PermakFileNames { get; set; }
// public string AlbumProgramFileDirectory { get; set; }
// public string AlbumTaskFileDitectory { get; set; } // Файл конфигурации 
// public BIPRManParams[] BIPRCalculatons { get; set; } 
// public int[] CyclePoints { get; set; } 

BIPRManParams[] BIPRTestParams = 
[
    new() 
    {
        FullFileName = "/Users/oleg/Desktop/B23/K07/XE123",
        AlbumOutputDirectory = "/Users/oleg/Desktop/B23/K07/AlbumOutput",
        MomentOfCycle = 40,
        PowerRestoreNumSost = 10,
        FinalSost = 882,
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




var TestCore = new ManhattanCoreLogic.ManhattanCoreLogic();

var errorList = TestCore.ExecuteLogic(TestInputData);


foreach (var item in errorList)
{
    Console.WriteLine(item.Message);    
}

Console.WriteLine(TestCore.Logs);

