using System;
using System.Threading;
using Windows.Devices.Spi;
using TetrisEngine;

namespace NanoTetris
{
    public class Program
    {
        public static void Main()
        {
            var display = new Esp32Display();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}