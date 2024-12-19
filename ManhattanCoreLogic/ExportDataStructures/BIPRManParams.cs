using System.Dynamic;

namespace ManhattanCoreLogic
{
    public struct BIPRManParams
    {
        public string FullFileName { get; set; } // xe file
        public string AlbumOutputDirectory { get; set; }
        public int MomentOfCycle { get; set; }
        public int PowerRestoreNumSost { get; set; }
        public int FinalSost { get; set; }

        public override string ToString()
    {
        string FormatPath(string path) =>
            string.IsNullOrWhiteSpace(path)
                ? "(empty)"
                : path.Length > 40
                    ? $"{path[..15]}...{path[^15..]}"
                    : path;

        return @$"  Full File Name: {FormatPath(FullFileName)}
  Album Output Directory: {FormatPath(AlbumOutputDirectory)}
  Moment of Cycle: {MomentOfCycle}
  Power Restore Num Sost: {PowerRestoreNumSost}
  Final Sost: {FinalSost}";
    }

    }
}