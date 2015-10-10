using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            UserAction userAction = a_view.GetUserAction();
            switch (userAction)
            {
                case UserAction.Play :  { a_game.NewGame(); break; }
                case UserAction.Hit :   { a_game.Hit(); break; }
                case UserAction.Stand : { a_game.Stand(); break; }
                case UserAction.Quit :  { return false; }
                default: break;    
            }
            return true;
        }
    }
}
