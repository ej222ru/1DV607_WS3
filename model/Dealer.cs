using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private DistributeCard m_distributeCard = null;

        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_WinnerRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_WinnerRule = a_rulesFactory.GetNewWinnerRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver(a_player))
            {
                m_deck = new Deck();
                m_distributeCard = new DistributeCard();

                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player, m_distributeCard);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            int score = a_player.CalcScore();

            if (m_deck != null && (score <= g_maxScore) && !IsGameOver(a_player))
            {
                m_distributeCard.NewCard(m_deck, a_player);
                /*
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);
                */
                return true;
            }
            return false;
        }
        public bool Stand(Player a_player)
        {
            int score = a_player.CalcScore();
            if (m_deck != null && ( score <= g_maxScore) && !IsGameOver(a_player))
            {
                ShowHand();
                while (m_hitRule.DoHit(this)){
                    m_distributeCard.NewCard(m_deck, this);
                    /*
                    Card c = m_deck.GetCard();
                    c.Show(true);
                    DealCard(c);
                     */ 
                };
                return true;
            }
  
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_WinnerRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver(Player a_player)
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ ((m_hitRule.DoHit(this) != true) || a_player.CalcScore() >= 21))
            {
                return true;
            }
            return false;
        }
    }
}
