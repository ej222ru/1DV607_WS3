using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    public enum Language { ENGLISH = 1, SWEDISH = 2 };
    public enum Soft17 { USESOFT17 = 1, NOSOFT17 = 2 };
    public enum WinnerAtDraw { DEALER = 1, PLAYER = 2 };
    public enum GameRules { AMERICAN = 1, INTERNATIONAL = 2 };
    class GameSetupView
    {


        public Language GetLanguage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide language: ");
            System.Console.WriteLine("Type '1' for English\n");
            System.Console.WriteLine("Type '2' for Swedish\n");
            return (GetUserAction() == 1 ? Language.ENGLISH : Language.SWEDISH);
        }

        public WinnerAtDraw GetWinnerAtDrawRules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide who wins at a draw: ");
            System.Console.WriteLine("Type '1' for Dealer\n");
            System.Console.WriteLine("Type '2' for Player\n");
            return (GetUserAction() == 1 ? WinnerAtDraw.DEALER : WinnerAtDraw.PLAYER);
        }
        public GameRules GetGameRules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide game strategy rules: ");
            System.Console.WriteLine("Type '1' for American\n");
            System.Console.WriteLine("Type '2' for International\n");
            return (GetUserAction() == 1 ? GameRules.AMERICAN : GameRules.INTERNATIONAL);
        }
        public Soft17 GetDealer17Rules()
        {
            System.Console.Clear();
            System.Console.WriteLine("Decide dealer soft 17: ");
            System.Console.WriteLine("Type '1' for using soft17 rule\n");
            System.Console.WriteLine("Type '2' for not using soft17 rule\n");
            return (GetUserAction() == 1 ? Soft17.USESOFT17 : Soft17.NOSOFT17);
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
