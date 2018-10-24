using BattleconCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BattleconCompanion
{
    public partial class MainPage : ContentPage
    {
        GameState currentGameState;

        public MainPage(GameState gameState)
        {
            gameState.AddPlayer();
            gameState.AddPlayer();

            InitializeComponent();
            BindingContext = gameState;

            currentGameState = gameState;
            p1Life.RelRotateTo(180);
        }

        private void p1Life_Clicked(object sender, EventArgs e)
        {
            currentGameState.Players[0].LifeTotal--;
        }

        private void p2Life_Clicked(object sender, EventArgs e)
        {
            currentGameState.Players[1].LifeTotal--;
        }
    }
}
