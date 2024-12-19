namespace ManhattanCoreLogic.GlobalConstants;



// Kamp - (K07)
// File - название ксенонового файла
// NumSostMin - PowerRestoreNumSost
// NumSostMax - FinalSost

//SostalgRange - 
// & XE4406040T1.S01 - XE4406040T1.S99,
// & XE4406040T1.S100 - XE4406040T1.S199,
// & ...
// & XE4406040T1.S200 - XE4406040T1.S{NumSostMax},



internal static class DefaultAlbumTask
{
    public static new string ToString() => 
""""
# Файл конфигурации Manhattan для генерации задания Альбома
# 
# Не допускается редактирование переменных в фигурных скобках
# Не допускается применение фигурных скобок в других местах
# Строки, начинающиеся с символа "#" будут удалены из конечного файла

Unit = {UnitDirectory}
Graph = {AlbumOutputDirectory}

RC_Axs_Sost {Kamp} [{File} (Bar = (0,420,232,420,318,363,375,295), Process=Total, 2Dpole=none, Sfactor=yes, Type=File, NumSost=({NumSostMin}-{NumSostMax}))

RC2_5 {Kamp} [{File} (Type=File, BaseSost=1,  Interval = 0.1, PSI_Interval = 5.0, NumSost=({NumSostMin}-{NumSostMax}),
& Process = Total, SFactor=yes, Cancel = BarLine, Bar = ( 
&  11.0, 420,
&  16.6, 168.0,
&  21.0, 141.0,
&  22.3, 136.0,
&  48.4, 85.0,
&  90.0, 85.0,
& ) )

Binary = {CycleDirectory}

Permak_Sost_Tabl {File}, 
{SostalgRange}
& (Graph=None, Type=File)

end 
"""";    
}
