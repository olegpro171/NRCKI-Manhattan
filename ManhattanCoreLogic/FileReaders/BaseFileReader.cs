using System;
using ManhattanCoreLogic.Exceptions;

namespace ManhattanCoreLogic.FileReaders;

internal abstract class BaseFileReader
{
    protected string GetFileContent(string path)
    {
        try
        {
            return File.ReadAllText(path);
            
        }
        catch (Exception ex)
        {
            throw new FileReaderException($"Ошибка чтения файла {path}: {ex.Message}", ex);
        }
    }
}
