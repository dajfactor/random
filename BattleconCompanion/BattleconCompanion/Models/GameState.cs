using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BattleconCompanion.Models
{
    public class GameState : INotifyPropertyChanged
    {
        public GameState()
        {
            ForceRemaining = 45;
            CurrentBeat = 1;
            GameLength = 15;

            Players = new List<Player>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddPlayer()
        {
            Players.Add(new Player());
        }

        public void RemovePlayer(int playerNumber)
        {
            Players.RemoveAt(playerNumber);
        }

        public List<Player> Players { get; set; }
        public int ForceRemaining { get; set; }
        public int CurrentBeat { get; set; }
        public int GameLength { get; set; }
    }
}
