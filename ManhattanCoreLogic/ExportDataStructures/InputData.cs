namespace ManhattanCoreLogic.ExportDataStructures
{
    public struct InputData
    {
        public string CycleDirectory { get; set; } //   B23/K07 - Cycle Directory;   B23 - Unit Directory
        public string[] PermakFileNames { get; set; }
        public string AlbumProgramFileName { get; set; }
        public string AlbumTaskFileName { get; set; } // Файл конфигурации 
        public BIPRManParams[] BIPRCalculatons { get; set; } 
        public int[] CyclePoints { get; set; } 




        public override string ToString()
        {
            string FormatPath(string path) =>
                string.IsNullOrWhiteSpace(path) 
                    ? "(empty)" 
                    : path.Length > 40 
                        ? $"{path[..15]}...{path[^15..]}" 
                        : path;

            string FormatArray(string[] array) =>
                array == null || array.Length == 0 
                    ? "None" 
                    : string.Join(", ", array.Select(FormatPath));

            var cyclePoints = CyclePoints;
            string FormatCyclePoints() =>  
                (cyclePoints == null || cyclePoints.Length == 0)
                    ? "None" 
                    : string.Join(", ", cyclePoints);

            var birpCalcs = BIPRCalculatons;
            string FormatCalculations() =>
                birpCalcs == null || birpCalcs.Length == 0 
                    ? "None" 
                    : string.Join(Environment.NewLine, birpCalcs.Select(x => x.ToString()));

            return @$"
Cycle Directory: {FormatPath(CycleDirectory)}
Permak File Directories: {FormatArray(PermakFileNames)}
Album Program File Directory: {FormatPath(AlbumProgramFileName)}
Album Task File Directory: {FormatPath(AlbumTaskFileName)}
Cycle Points: {FormatCyclePoints()}
BIPR Calculations:
{FormatCalculations()}";
        }
    }
}