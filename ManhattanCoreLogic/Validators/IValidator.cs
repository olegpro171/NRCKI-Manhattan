using System;
using ManhattanCoreLogic.ExportDataStructures;

namespace ManhattanCoreLogic.Validators;

public interface IValidator
{
    public void Validate(InputData inputData, List<ErrorReport> ReportList);
}
