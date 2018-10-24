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
        int player1Life;
        int player2Life;

        int player1Force;
        int player2Force;

        int forcePool;
        int beatNumber;

        public MainPage()
        {
            player1Life = 20;
            player2Life = 20;
            forcePool = 45;

            InitializeComponent();
            p1Life.RelRotateTo(180);
        }

        private void p1Life_Clicked(object sender, EventArgs e)
        {
            player1Life--;
            p1L.Text = player1Life.ToString();
        }

        private void p2Life_Clicked(object sender, EventArgs e)
        {
            player2Life--;
            p2L.Text = player2Life.ToString();
        }
    }
}
