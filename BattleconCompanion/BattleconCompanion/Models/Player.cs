using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BattleconCompanion.Models
{
    public class Player : INotifyPropertyChanged
    {
        public Player()
        {
            LifeTotal = 20;
            CurrentForce = 2;
        }

        int _lifeTotal;
        int _currentForce;

        public int LifeTotal
        { 
            get { return _lifeTotal; }
            set {
                _lifeTotal = value;
                OnPropertyChanged();
            }
        }

        public int CurrentForce
        {
            get { return _currentForce; }
            set
            {
                _currentForce = value;
                OnPropertyChanged();
            }
        }

        public bool PowerOverload { get; set; }
        public bool PriorityOverload { get; set; }
        public bool StunGuardOverload { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Required for the interface implementation whenever any property is changed
        /// </summary>
        /// <param name="propertyName"></param>
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
