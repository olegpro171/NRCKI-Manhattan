using System;
using System.Text;
using ManhattanCoreLogic.ExportDataStructures;
using ManhattanCoreLogic.FileReaders;
using ManhattanCoreLogic.GlobalConstants;

namespace ManhattanCoreLogic;

internal class MainWorker
{
    AlbumTaskFileProcessor TaskFileProcessor = new();
    public List<string> WrittenFiles = new();
    private StringBuilder LoggerSB = new();
    public string Logs => LoggerSB.ToString();



    public void Execute(InputData Params)
    {
        LoggerSB.Clear();
        WrittenFiles.Clear();

        LoggerSB.AppendLine($"Заданные начальные параметры:");
        LoggerSB.AppendLine(Params.ToString());
        LoggerSB.AppendLine();
        LoggerSB.AppendLine("Параметры прошли проверку, запуск алгоритма");

        try 
        {
            MainWorkload(Params);
        }
        catch (Exception ex)
        {
            LoggerSB.AppendLine();
            LoggerSB.AppendLine("Во время работы произошла ошибка, дальнейшее выполнение алгоритма невозможно.");
            LoggerSB.AppendLine($"Текст ошибки:\n{ex.Message}");
            return;
        }
        finally
        {

            LoggerSB.AppendLine();
            LoggerSB.AppendLine($"Работа алгоритма завершена аварийно");
            if (WrittenFiles.Count == 0)
            {
                LoggerSB.AppendLine($"Записаные файлы отсутствуют");
            }
            else
            {
                try
                {
                    LoggerSB.AppendLine($"Обнаружены записаные файлы, начато удаление");
                
                    int deletedCount = 0;
                    foreach (var copiedFile in new List<string>(WrittenFiles))
                    {
                        File.Delete(copiedFile);
                        WrittenFiles.Remove(copiedFile);
                        LoggerSB.AppendLine($"Удален файл: {Path.GetFileName(copiedFile)}");
                        deletedCount += 1;
                    }
                    LoggerSB.AppendLine($"Удалено файлов: {deletedCount}");
                }
                catch (Exception ex)
                {
                    LoggerSB.AppendLine();
                    LoggerSB.AppendLine($"Произошла ошибка во время удаления файлов");
                    LoggerSB.AppendLine($"Текст ошибки:\n{ex.Message}");
                    LoggerSB.AppendLine($"Алгоритм завершает работу по причине невозможности удаления файлов");
                    LoggerSB.AppendLine($"Колличество брошенных файлов: {WrittenFiles.Count}:");
                    foreach (var file in WrittenFiles)
                        LoggerSB.AppendLine(file);

                }
            }
        }

        LoggerSB.AppendLine();
        LoggerSB.AppendLine("Работа алгоритма завершена без ошибок");
    }

    private void MainWorkload(InputData Params)
    {
        int GlobalRecordCounter = 0;
        foreach (var BIPRCalcParam in Params.BIPRCalculatons)
        {
            GlobalRecordCounter++;
            LoggerSB.AppendLine();
            LoggerSB.AppendLine($"Обработка файла задачи Альбома\nЧтение файла:\n{Params.AlbumTaskFileName}...");
            var AlbumTaskString = TaskFileProcessor.GetFileContent(Params, BIPRCalcParam);
            LoggerSB.AppendLine($"Файл прочитан, подстановки выполнены успешно");

            // Уточнить куда выводить файл альбома
            string albumTaskOutputFilePath = Path.Join(Path.GetDirectoryName(BIPRCalcParam.FullFileName), "mad.dat");

            LoggerSB.AppendLine($"Путь, указанный для записи файла задачи Альбома: {albumTaskOutputFilePath}\nЗапись файла...");
            WrittenFiles.Add(albumTaskOutputFilePath);
            File.WriteAllText(albumTaskOutputFilePath, AlbumTaskString);

            LoggerSB.AppendLine($"Файл задачи Альбома записан по пути:\n{albumTaskOutputFilePath}\n");





            var BIPRFilePath = BIPRCalcParam.FullFileName;
            LoggerSB.AppendLine($"Начато копирование для записи БИПР №{GlobalRecordCounter}, файл {Path.GetFileName(BIPRFilePath)}");

            if (!Params.CyclePoints.Contains(BIPRCalcParam.MomentOfCycle))
            {
                var errMsg = "Moment Of Cycle, заданный в BIPR Calculation Parameters отсутствует во входных параметрах (Params.CyclePoints)";
                LoggerSB.AppendLine(errMsg);
                throw new ArgumentException(errMsg);
            }

            var CopyPattern = Constants.CopyPatterns[Params.CyclePoints.ToList().IndexOf(BIPRCalcParam.MomentOfCycle)];


            string? CopySource = null;
            
            for (int CurrentSost = 1; CurrentSost <= 3; CurrentSost++)
            {
                string CopyDest;
                CopySource = Params.PermakFileNames.ToList().Find(x => x.EndsWith(CopyPattern[CurrentSost - 1]));
                if (CopySource == null)
                    throw new Exception("CopySource == null");

                CopyDest = BIPRCalcParam.FullFileName;

                CopyDest += GetExtS(CurrentSost);
                
                LoggerSB.AppendLine($"Копирование файла: {Path.GetFileName(CopySource)} -> {Path.GetFileName(CopyDest)}");
                WrittenFiles.Add(CopyDest);

                File.Copy(CopySource, CopyDest, overwrite: true);
            }


            if (CopySource == null)
                    throw new Exception("CopySource == null");
            for (int CurrentSost = 4; CurrentSost <= BIPRCalcParam.FinalSost; CurrentSost++)
            {
                string CopyDest;
                CopyDest = BIPRCalcParam.FullFileName;

                CopyDest += GetExtS(CurrentSost);
                
                LoggerSB.AppendLine($"Копирование файла: {Path.GetFileName(CopySource)} -> {Path.GetFileName(CopyDest)}");
                WrittenFiles.Add(CopyDest);
                File.Copy(CopySource, CopyDest, overwrite: true);
            }

            LoggerSB.AppendLine();
            LoggerSB.AppendLine($"Копирование файлов завершено. Файлов скопировано: {WrittenFiles.Count}");

            
            LoggerSB.AppendLine();
            LoggerSB.AppendLine("--- Псевдозапуск Альбома ---");
            LoggerSB.AppendLine();

            LoggerSB.AppendLine($"Работа альбома завершена, удаление файлов");
            int deletedCount = 0;
            foreach (var copiedFile in new List<string>(WrittenFiles))
            {
                File.Delete(copiedFile);
                WrittenFiles.Remove(copiedFile);
                LoggerSB.AppendLine($"Удален файл {Path.GetFileName(copiedFile)}");
                deletedCount += 1;
            }
            LoggerSB.AppendLine($"Удалено файлов: {deletedCount}");
        }
    }


    private string GetExtS(int n)
    {
        if (n < 1)
            throw new ArgumentException($"Попытка генерации расширения файла вне допустимого диапазона. ({n} < 1)");

        if (n < 10)
        {
            return $".S0{n}";
        }

        return $".S{n}";
    }
}
