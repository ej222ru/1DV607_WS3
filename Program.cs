using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            view.GameSetupView setup = new view.GameSetupView();
            view.IView v;

            view.Language selectLanguage = setup.GetLanguage();
            if (selectLanguage == view.Language.English)
            {
                v = new view.SimpleView(); 
            }
            else if (selectLanguage == view.Language.Swedish)
            {
                v = new view.SwedishView();
            }
            else
            {
                v = new view.SimpleView();
            }

            view.WinnerAtDraw winnerAtDraw = setup.GetWinnerAtDrawRules();
            view.Soft17 soft17 = setup.GetDealer17Rules();
            view.GameRules gameRules = setup.GetGameRules();



            model.Game g = new model.Game(winnerAtDraw, soft17, gameRules);
            controller.PlayGame ctrl = new controller.PlayGame(g, v);

            while (ctrl.Play());
        }
    }
}
