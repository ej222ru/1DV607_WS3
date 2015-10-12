using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class SetupGame
    {
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
            if (selectLanguage == view.Language.English)
            {
                gameView = new view.SimpleView();
            }
            else if (selectLanguage == view.Language.Swedish)
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
