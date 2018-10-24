using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public void AddPlayer()
        {
            Players.Add(new Player());
        }

        public void RemovePlayer(int playerNumber)
        {
            Players.RemoveAt(playerNumber);
        }


        int _forceRemaining;
        int _currentBeat;

        public int ForceRemaining
        {
            get { return _forceRemaining; }
            set
            {
                _forceRemaining = value;
                OnPropertyChanged();
            }
        }

        public int CurrentBeat
        {
            get { return _currentBeat; }
            set
            {
                _currentBeat = value;
                OnPropertyChanged();
            }
        }

        public List<Player> Players { get; set; }
        public int GameLength { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
