using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using TG.Enums;

namespace TG
{
    public class Character : INotifyPropertyChanged
    {
        public CharacterName CharacterName;
        public CharacterArchetype Archetype;

        private int _aggression;
        private int _courage;
        private int _practicality;
        private int _empathy;
        private int _caution;
        private int _spirituality;
        private int _maxHealth;
        private int _currentHealth;
        private int _maxEnergy;
        private int _currentEnergy;
        private int _maxTerror;
        private int _currentTerror;

        private int _food;
        private int _reputation;
        private int _wealth;
        private int _experience;
        private int _magic;

        public int Aggression { get => this._aggression; set { if (value == _aggression) return; _aggression = value; NotifyPropertyChanged(); } }
        public int Courage { get => this._courage; set { if (value == _courage) return; _courage = value; NotifyPropertyChanged(); } }
        public int Practicality { get => this._practicality; set { if (value == _practicality) return; _practicality = value; NotifyPropertyChanged(); } }
        public int Empathy { get => this._empathy; set { if (value == _empathy) return; _empathy = value; NotifyPropertyChanged(); } }
        public int Caution { get => this._caution; set { if (value == _caution) return; _caution = value; NotifyPropertyChanged(); } }
        public int Spirituality { get => this._spirituality; set { if (value == _spirituality) return; _spirituality = value; NotifyPropertyChanged(); } }
        public int MaxHealth { get => this._maxHealth; set { if (value == _maxHealth) return; _maxHealth = value; NotifyPropertyChanged(); } }
        public int CurrentHealth { get => this._currentHealth; set { if (value == _currentHealth) return; _currentHealth = value; NotifyPropertyChanged(); } }
        public int MaxEnergy { get => this._maxEnergy; set { if (value == _maxEnergy) return; _maxEnergy = value; NotifyPropertyChanged(); } }
        public int CurrentEnergy { get => this._currentEnergy; set { if (value == _currentEnergy) return; _currentEnergy = value; NotifyPropertyChanged(); } }
        public int MaxTerror { get => this._maxTerror; set { if (value == _maxTerror) return; _maxTerror = value; NotifyPropertyChanged(); } }
        public int CurrentTerror { get => this._currentTerror; set { if (value == _currentTerror) return; _currentTerror = value; NotifyPropertyChanged(); } }
        public int Food { get => this._food; set { if (value == _food) return; _food = value; NotifyPropertyChanged(); } }
        public int  Reputation { get => this._reputation; set { if (value == _reputation) return; _reputation = value; NotifyPropertyChanged(); } }
        public int Wealth { get => this._wealth; set { if (value == _wealth) return; _wealth = value; NotifyPropertyChanged(); } }
        public int Experience { get => this._experience; set { if (value == _experience) return; _experience = value; NotifyPropertyChanged(); } }
        public int Magic { get => this._magic; set { if (value == _magic) return; _magic = value; NotifyPropertyChanged(); } }

        public object Skills;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Character()
        {

        }
    }

}
