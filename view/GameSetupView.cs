using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    public enum Language { English = 1, Swedish = 2 };
    public enum Soft17 { UseSoft17 = 1, NoSoft17 = 2 };
    public enum WinnerAtDraw { Dealer = 1, Player = 2 };
    public enum GameRules { American = 1, International = 2 };
    class GameSetupView
    {


        public Language GetLanguage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide language: ");
            System.Console.WriteLine("Type '1' for English\n");
            System.Console.WriteLine("Type '2' for Swedish\n");
            return (GetUserAction() == 1 ? Language.English : Language.Swedish);
        }

        public WinnerAtDraw GetWinnerAtDrawRules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide who wins at a draw: ");
            System.Console.WriteLine("Type '1' for Dealer\n");
            System.Console.WriteLine("Type '2' for Player\n");
            return (GetUserAction() == 1 ? WinnerAtDraw.Dealer : WinnerAtDraw.Player);
        }
        public GameRules GetGameRules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide game strategy rules: ");
            System.Console.WriteLine("Type '1' for American\n");
            System.Console.WriteLine("Type '2' for International\n");
            return (GetUserAction() == 1 ? GameRules.American : GameRules.International);
        }
        public Soft17 GetDealer17Rules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide dealer soft 17: ");
            System.Console.WriteLine("Type '1' for using soft17 rule\n");
            System.Console.WriteLine("Type '2' for not using soft17 rule\n");
            return (GetUserAction() == 1 ? Soft17.UseSoft17 : Soft17.NoSoft17);
        }

        public int GetUserAction()
        {
            bool done = false;
            while (!done)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.D1: { return 1;  }
                    case ConsoleKey.D2: { return 2;  }
                    default: break;
                }
                System.Console.WriteLine("You have to type either '1' or '2'\n");
            }
            return 0;
        }
    }
}
