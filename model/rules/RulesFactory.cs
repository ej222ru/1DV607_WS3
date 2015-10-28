using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        view.Soft17 m_hitRule;
        view.WinnerAtDraw m_winnerAtDraw;
        view.GameRules m_gameRules;

        public RulesFactory(view.WinnerAtDraw winnerAtDraw, view.Soft17 soft17, view.GameRules gameRules)
        {
            m_hitRule = soft17;
            m_winnerAtDraw = winnerAtDraw;
            m_gameRules = gameRules;

        }
        public IHitStrategy GetHitRule()
        {
            if (m_hitRule == view.Soft17.NOSOFT17)
                return new BasicHitStrategy();
            else
                return new Soft17HitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            if (m_gameRules == view.GameRules.AMERICAN)
                return new AmericanNewGameStrategy();
            else
                return new InternationalNewGameStrategy();
        }

        public IWinnerStrategy GetNewWinnerRule()
        {
            if (m_winnerAtDraw == view.WinnerAtDraw.DEALER)
                return new StandardWinnerStrategy();
            else
                return new PlayerPlusWinnerStrategy();
        }

    }
}
