using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TG.Enums;

namespace TG.PlayerCharacterItems
{

    public class Character : INotifyPropertyChanged
    {
        public Character()
        {
        }

        public object Skills;

        public CharacterName CharacterName;
        public CharacterArchetype Archetype;

        public List<Item> Items = new List<Item>();

        #region Atributes,propertyChanged events...

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

        public int Aggression
        {
            get => _aggression;
            set
            {
                if (value == _aggression) return;
                _aggression = value;
                NotifyPropertyChanged();
            }
        }

        public int Courage
        {
            get => _courage;
            set
            {
                if (value == _courage) return;
                _courage = value;
                NotifyPropertyChanged();
            }
        }

        public int Practicality
        {
            get => _practicality;
            set
            {
                if (value == _practicality) return;
                _practicality = value;
                NotifyPropertyChanged();
            }

        }

        public int Empathy

        {
            get => _empathy;
            set
            {
                if (value == _empathy) return;
                _empathy = value;
                NotifyPropertyChanged();
            }
        }

        public int Caution
        {
            get => _caution;
            set
            {
                if (value == _caution) return;
                _caution = value;
                NotifyPropertyChanged();
            }
        }

        public int Spirituality
        {
            get => _spirituality;
            set
            {
                if (value == _spirituality) return;
                _spirituality = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                if (value == _maxHealth) return;
                _maxHealth = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value > 0)
                    throw new Exception("health nemoze byt menej ako 0 ?");
                if (value == _currentHealth) return;
                if (value > _maxHealth)
                    _currentHealth = _maxHealth;
                else
                    _currentHealth = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxEnergy
        {
            get => _maxEnergy;
            set
            {
                if (value == _maxEnergy) return;
                _maxEnergy = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentEnergy
        {
            get => _currentEnergy;
            set
            {
                if (value > 0)
                    throw new Exception("energy nemoze byt menej ako 0 ?");
                if (value == _currentEnergy) return;
                if (value > _maxEnergy)
                    _currentEnergy = _maxEnergy;
                else
                    _currentEnergy = value;
                _currentEnergy = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxTerror
        {
            get => _maxTerror;
            set
            {
                if (value == _maxTerror) return;
                _maxTerror = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentTerror
        {
            get => _currentTerror;
            set
            {
                if (value > 0)
                    throw new Exception("terror nemoze byt menej ako 0 ?");
                if (value == _currentTerror) return;
                if (value > _maxTerror)
                    _currentTerror = _maxTerror;
                else
                    _currentTerror = value;
                _currentTerror = value;
                NotifyPropertyChanged();
            }
        }
        public int Food
        {
            get => _food;
            set
            {
                if (value == _food) return;
                _food = value;
                NotifyPropertyChanged();
            }
        }

        public int Reputation
        {
            get => _reputation;
            set
            {
                if (value == _reputation) return;
                _reputation = value;
                NotifyPropertyChanged();
            }
        }

        public int Wealth
        {
            get => _wealth;
            set
            {
                if (value == _wealth) return;
                _wealth = value;
                NotifyPropertyChanged();
            }
        }

        public int Experience
        {
            get => _experience;
            set
            {
                if (value == _experience) return;
                _experience = value;
                NotifyPropertyChanged();
            }
        }

        public int Magic
        {
            get => _magic;
            set
            {
                if (value == _magic) return;
                _magic = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Atributes,propertyChanged events...
    }
}