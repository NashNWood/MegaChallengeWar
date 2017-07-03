using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MegaChallengeWar
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;

        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }

        public string performBattle(Player player1, Player player2)
        {
            // Grabs the top card off the deck
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            performEvaluation(player1, player2, player1Card, player2Card);
            return _sb.ToString();
        }


        private Card getCard(Player player)
        {
            Card card = player.Cards.ElementAt(0);
            player.Cards.Remove(card);
            _bounty.Add(card);
            return card;
        }

        // Determines who the winer is and who the bounty is assigned to
        private void performEvaluation(Player player1, Player player2, Card card1, Card card2)

        {
            displayBattleCards(card1, card2);

            if (card1.cardValue() == card2.cardValue())
                war(player1, player2);
            if (card1.cardValue() > card2.cardValue())
                awardWinner(player1);
            else
                awardWinner(player2);
           
        }

        private void awardWinner(Player player)
        {
            displayBountyCards();
            player.Cards.AddRange(_bounty);
            _bounty.Clear();

            _sb.Append("<br/><strong>");
            _sb.Append(player.Name);
            _sb.Append(" Wins!</strong><br/>");
        }

        private void war(Player player1, Player player2)
        {
            _sb.Append("<br/><span style = color:red>;****************WAR!****************<br/></span>");

            getCard(player1);
            getCard(player1);
            getCard(player1);
            Card warCard1 = getCard(player1);

            getCard(player2);
            getCard(player2);
            getCard(player2);
            Card warCard2 = getCard(player2);

            performEvaluation(player1, player2, warCard1, warCard2);
 
        }

        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/>Battle Cards: ");
            _sb.Append(card1.Kind);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Kind);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);
        }

        private void displayBountyCards()
        {
            _sb.Append("<br/> Bounty:");
            foreach (var card in _bounty)
            {
                _sb.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
                _sb.Append(card.Kind);
                _sb.Append(" of ");
                _sb.Append(card.Suit);
            }
           
        }

    }
}