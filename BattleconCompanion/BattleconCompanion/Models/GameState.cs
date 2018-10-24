using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

            AdvanceToNextBeat = new Command(
                execute: () =>
                {
                    CurrentBeat++;
                    foreach(var player in Players)
                    {
                        var forceAmount = 1;

                        if(player.LifeTotal <= 7)
                        {
                            forceAmount++;
                        }

                        ForceRemaining -= forceAmount;
                        player.CurrentForce += forceAmount;

                        //Maximum 10 force
                        player.CurrentForce = player.CurrentForce > 10 ? 10 : player.CurrentForce;
                    }
                }
            );

            //Refactor these later, this is gross
            DamagePlayer = new Command<string>(
                execute: (string playerNumber) =>
                {
                    Players[int.Parse(playerNumber)].LifeTotal--;
                });

            HealPlayer = new Command<string>(
                execute: (string playerNumber) =>
                {
                    Players[int.Parse(playerNumber)].LifeTotal++;
                    Players[int.Parse(playerNumber)].LifeTotal = Players[int.Parse(playerNumber)].LifeTotal > 20 ? 20 : Players[int.Parse(playerNumber)].LifeTotal;
                });
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

        public ICommand AdvanceToNextBeat { private set; get; }
        public ICommand UpdateForce { private set; get; }
        public ICommand DamagePlayer { private set; get; }
        public ICommand HealPlayer { private set; get; }

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
