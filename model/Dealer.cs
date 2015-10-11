using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        
        List<IBlackJackObserver> m_observers;

        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetNewWinnerRule();

            m_observers = new List<IBlackJackObserver>();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver(a_player))
            {
                m_deck = new Deck();

                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            int score = a_player.CalcScore();

            if (m_deck != null && (score <= g_maxScore) && !IsGameOver(a_player))
            {
                NewCard(m_deck, a_player);
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
                    NewCard(m_deck, this);
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
            return m_winnerRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver(Player a_player)
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ ((m_hitRule.DoHit(this) != true) || a_player.CalcScore() >= 21))
            {
                return true;
            }
            return false;
        }

        public void NewCard(Deck aDeck, Player aPlayer, bool showCard = true)
        {
            Card newCardFromDeck = aDeck.GetCard();
            newCardFromDeck.Show(showCard);
            aPlayer.DealCard(newCardFromDeck);

            foreach (IBlackJackObserver observer in m_observers)
            {
                observer.newCardDelt();
            }
        }

        public void AddSubscriber(IBlackJackObserver a_sub)
        {
            m_observers.Add(a_sub);
        }
    }
}
