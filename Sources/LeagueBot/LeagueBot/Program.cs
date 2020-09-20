﻿using LeagueBot.DesignPattern;
using LeagueBot.Game;
using LeagueBot.Game.Enums;
using LeagueBot.Image;
using LeagueBot.IO;
using LeagueBot.Patterns;
using LeagueBot.Texts;
using LeagueBot.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static LeagueBot.Windows.Interop;

namespace LeagueBot
{
    /* 
     * The user input settings (game mode, champion , champion behaviour)
     * -> We create SessionParameters.cs that we pass to each scripts.
     * Or
     * 
     * The user input settings (game mode, champion , champion behaviour)
     * -> We create Session.cs that call scripts.
     */


    /* *** Final Goal ***
     * Todo -> Champion script (GameLoop() function is relative the champion)
     * Dont use dynamic in LCU , use classes definitions of LCU instead.
     * Object architecture of ApiMembers<>, MainPlayer property are defined in MainPlayer.cs and Coop.cs (dead property for example. Thats sucks)
     * Use Task<T> and Parallelism instead of GameLoop()
     * Optimize pixel searching ? it is possible faster than FastBitmap.cs (LockBits) ?
     * Make solo pattern instead of following ally.
     */
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Logger.OnStartup();

            StartupManager.Initialize(Assembly.GetExecutingAssembly());

            HandleCommand();

            Console.Read();
        }
        static void HandleCommand()
        {
            Logger.Write("Enter a pattern filename, type 'help' for help.", MessageState.INFO);

            string line = Console.ReadLine();

            if (line == "help" || !PatternsManager.Contains(line))
            {
                Logger.Write(PatternsManager.ToString());
                HandleCommand();
                return;
            }


            PatternsManager.Execute(line);

            HandleCommand();
        }
    }
}
