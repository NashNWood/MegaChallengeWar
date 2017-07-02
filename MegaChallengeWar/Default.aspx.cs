using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Test to see if the Deck initializes properly
            /*
            Deck deck = new Deck();
            foreach (var card in deck._deck)
            {
                resultsLabel.Text += "<br/>" + card.Suit + card.Kind;
            }*/

            Game game = new Game("Player1", "Player2");
            resultsLabel.Text = game.Play();

        }
    }
}