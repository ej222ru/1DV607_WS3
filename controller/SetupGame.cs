using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class SetupGame
    {
        /* Class used to setup/config a game of BlackJack
        * rules for
        *  - Who wins at dealer gets 17
        *  - Who wins at a draw (player-dealer same points)
        *  - GUI language 
        *  - game rules how it is played 
        */
        view.GameSetupView setup;
        view.IView gameView;

        public SetupGame()
        {
            setup = new view.GameSetupView();
        }
        public view.WinnerAtDraw GetWinnerAtDrawRules(){
            return setup.GetWinnerAtDrawRules();
        }
        public view.Soft17 GetDealer17Rules()
        {
            return setup.GetDealer17Rules();
        }
        public view.GameRules GetGameRules()
        {
            return setup.GetGameRules();
        }

        public view.IView GetLanguageView()
        {
            view.Language selectLanguage = setup.GetLanguage();
            if (selectLanguage == view.Language.ENGLISH)
            {
                gameView = new view.SimpleView();
            }
            else if (selectLanguage == view.Language.SWEDISH)
            {
                gameView = new view.SwedishView();
            }
            else
            {
                gameView = new view.SimpleView();
            }
            return gameView;
        }
    }
}
