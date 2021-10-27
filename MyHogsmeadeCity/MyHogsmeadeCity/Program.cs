using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Net.Sockets;

namespace MyHogsmeadeCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10,10);
            game.Update();
        } 
    }
}
