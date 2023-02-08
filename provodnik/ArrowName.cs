using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArrowName
{
    public class Arrows
    {
        public static int max;
        public static int min;
        public Arrows(int _min, int _max)
        {
            max = _max;
            min = _min;
        }

        public void ShowArrow(int mincoord, int step, string selector, List<string> _dirs)
        {
            int coord = mincoord;
            List<string> dirs = _dirs;
            int counter = 0;
            while (true)
            {

                Console.SetCursorPosition(0, coord);
                Console.WriteLine(selector);
                ConsoleKeyInfo key = Console.ReadKey();
                if (coord == 0)
                {
                    counter = 0;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (coord - step >= min)
                    {
                        Console.SetCursorPosition(0, coord);
                        Console.WriteLine("  ");
                        coord -= step;
                        counter += 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (coord + step < max)
                    {
                        Console.SetCursorPosition(0, coord);
                        Console.WriteLine("  ");
                        coord += step;
                        if (counter - 1 > 0)
                        {
                            counter -= 1;
                        }

                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    try
                    {
                        Console.Clear();
                        List<string> newdircont = new List<string>();
                        string[] allDirectories = Directory.GetDirectories(dirs[coord]);
                        string[] allFiles = Directory.GetFiles(dirs[coord]);

                        foreach (var d in allDirectories)
                        {
                            newdircont.Add(d);
                        }

                        foreach (var f in allFiles)
                        {
                            newdircont.Add(f);
                        }

                        max = newdircont.Count;
                        Conductor.Сonductor.ShowDirConstent(dirs[coord]);

                        dirs = newdircont;
                    }
                    catch (System.IO.IOException)
                    {
                        Process.Start(new ProcessStartInfo { FileName = dirs[coord], UseShellExecute = true });
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    string prevdir = dirs[0];
                    List<string> dirsplit = prevdir.Split(@"\").ToList();

                    if (dirsplit.Count > 1)
                    {
                        dirsplit.Remove(dirsplit.Last());
                        dirsplit.Remove(dirsplit.Last());
                        prevdir = string.Join(@"\", dirsplit);
                    }

                    Console.Clear();
                    List<string> newdircont = new List<string>();
                    string[] allDirectories = Directory.GetDirectories(prevdir);
                    string[] allFiles = Directory.GetFiles(prevdir);

                    foreach (var d in allDirectories)
                    {
                        newdircont.Add(d);
                    }

                    foreach (var f in allFiles)
                    {
                        newdircont.Add(f);
                    }
                    max = newdircont.Count;
                    dirs = newdircont;
                    Conductor.Сonductor.ShowDirConstent(prevdir);
                }
            }
        }
    }
}
