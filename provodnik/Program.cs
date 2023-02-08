using System.Globalization;
using ArrowName;

namespace Conductor
{
    public static class RepeatSomeValue
    {
        public static string Repeat(this string value, int count) => string.Concat(Enumerable.Repeat(value, count));
    }

    public static class Сonductor
    {
        public static void ShowDirConstent(string path)
        {
            Console.Clear();
            string[] allDirectories = Directory.GetDirectories(path);
            string[] allFiles = Directory.GetFiles(path);


            foreach (var dir in allDirectories)
            {
                var creation_date = Directory.GetCreationTime(dir).ToString();
                var name = new DirectoryInfo(dir).Name;
                try
                {
                    Console.WriteLine($"    Имя папки: {name} " +
                                      $"{" ".Repeat(5)}|- Дата создания: {creation_date} " +
                                      $"{" ".Repeat(5)}|- Количество файлов внутри: {Directory.GetFiles(dir).Length}");
                }
                catch (System.UnauthorizedAccessException) //Здесь отлавливается ошибка доступа к защищенным файлам
                {
                    Console.WriteLine($"    Имя файла: {name}" +
                                      $"{" ".Repeat(5)}|- Дата создания: {creation_date} " +
                                      $"{" ".Repeat(5)}|- Невозможно получить информацию о файлах внутри директории " +
                                      $"");
                }
            }

            foreach (var f in allFiles)
            {
                var ext = Path.GetExtension(f);
                var name = Path.GetFileName(f);
                var namewithoutext = name.Split(".");
                var creation_date = File.GetCreationTime(f).ToString();
                Console.WriteLine($"    Имя файла: {namewithoutext[0]} " +
                                  $"{" ".Repeat(5)}|- Расширение файла: {ext} " +
                                  $"{" ".Repeat(5)}|- Дата создания: {creation_date} ");

            }
        }
        public static void init()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<string> drivenames = new List<string>();
            foreach (DriveInfo d in allDrives)
            {
                Console.Write("     Диск", d.Name);
                drivenames.Add(d.Name);
                if (d.IsReady)
                {
                    string msg1 = $"  |- Файловая система: {d.DriveFormat}";
                    string msg2 = $"  |- Общий объем: {Math.Round(d.TotalSize / Math.Pow(2, 30), 2)} Gb";
                    string msg3 = $"  |- Объем свободного места: {Math.Round(d.TotalFreeSpace / Math.Pow(2, 30), 2)} Gb";
                    Console.WriteLine($"{msg1,5}{msg2,5}{msg3,5}");
                }
            }
            Arrows arr = new Arrows(0, 3);
            arr.ShowArrow(0, 1, "->", drivenames);
        }
        public static void Main()
        {
            init();
        }
    }
}