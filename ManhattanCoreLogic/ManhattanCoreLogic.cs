using ManhattanCoreLogic.GlobalConstants;
using ManhattanCoreLogic.ExportDataStructures;
using ManhattanCoreLogic.Validators;

namespace ManhattanCoreLogic
{
    public class ManhattanCoreLogic
    {
        private List<ErrorReport> ErrorReports = new();
        private MainWorker Worker = new();

        public string Logs => Worker.Logs;

        public ErrorReport[] CreateDefaultPattern(string path)
        {
            var errorReport = new List<ErrorReport>();

            if (path == null || path == string.Empty)
            {
                Path.ChangeExtension(path, "txt");
                errorReport.Add(new("Неверно указана директория для создания файла."));
                return errorReport.ToArray();
            }

            try
            {
                File.WriteAllText(path, DefaultAlbumTask.ToString());
            }
            catch (Exception ex)
            {
                errorReport.Add(new(ex, "Произошла ошибка во время создания файла."));
            }

            return errorReport.ToArray();
        }


        public ErrorReport[] ExecuteLogic(InputData Params)
        {
            ErrorReports.Clear();

            ValidateInputData(Params);

            if (ErrorReports.Count > 0)
                return ErrorReports.ToArray();

            
            try
            {
                Worker.Execute(Params);
            }
            catch
            {
                throw;
            }

            
            return ErrorReports.ToArray();
        }

        private void ValidateInputData(InputData inputData)
        {
            List<ErrorReport> errorReports = new();
            InputFilePathsValidator.Validate(inputData, ReportList: ErrorReports);

            if (inputData.CyclePoints.Length != 3)
                ErrorReports.Add(new("Указано неверное колличество точек моментов кампании."));

        }
    }
}