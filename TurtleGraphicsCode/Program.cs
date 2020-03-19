﻿using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TurtleGraphicsCode
{
    /// <summary>
    /// This is a private space, you do not need to be here ;)
    /// </summary>
    class Program
    {
        public static void Main()
        {
            Launch(new Code().ToExecute());
        }

        public static void Launch(Turtle turtle)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = File.OpenWrite("data.tgc"))
            {
                bf.Serialize(fs, turtle.Data);
            }

            ProcessStartInfo info = new ProcessStartInfo("TurtleGraphics.exe", (turtle.FullScreen ? "-f " : "") + "data.tgc");
            using (Process p = new Process() { StartInfo = info })
            {
                p.EnableRaisingEvents = true;
                p.Start();
            }
        }
    }
}
