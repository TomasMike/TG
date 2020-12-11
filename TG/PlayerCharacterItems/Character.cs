using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TG.Enums;

namespace TG.PlayerCharacterItems
{

    public class Character : INotifyPropertyChanged
    {
        public Character() { }

        public Character(
            CharacterName cn,
            CharacterArchetype ca,
            int agg,
            int cou,
            int pra,
            int emp,
            int cau,
            int spi,
            int mhp,
            int chp,
            int men,
            int cen,
            int mte,
            int cte,
            int fod,
            int rep,
            int wea,
            int exp,
            int mag)
        {
            CharacterName = cn;
            Archetype = ca;
            Aggression = agg;
            Courage = cou;
            Practicality = pra;
            Empathy = emp;
            Caution = cau;
            Spirituality = spi;
            MaxHealth = mhp;
            CurrentHealth = chp;
            MaxEnergy  = men;
            CurrentEnergy = cen;
            MaxTerror = mte; 
            CurrentTerror = cte;
            Food = fod;
            Reputation = rep;
            Wealth = wea;
            Experience = exp;
            Magic = mag;
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
            private set
            {
                if (value == _aggression) return;
                _aggression = value;
                NotifyPropertyChanged();
            }
        }

        public int Courage
        {
            get => _courage;
            private set
            {
                if (value == _courage) return;
                _courage = value;
                NotifyPropertyChanged();
            }
        }

        public int Practicality
        {
            get => _practicality;
            private set
            {
                if (value == _practicality) return;
                _practicality = value;
                NotifyPropertyChanged();
            }

        }

        public int Empathy

        {
            get => _empathy;
            private set
            {
                if (value == _empathy) return;
                _empathy = value;
                NotifyPropertyChanged();
            }
        }

        public int Caution
        {
            get => _caution;
            private set
            {
                if (value == _caution) return;
                _caution = value;
                NotifyPropertyChanged();
            }
        }

        public int Spirituality
        {
            get => _spirituality;
            private set
            {
                if (value == _spirituality) return;
                _spirituality = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxHealth
        {
            get => _maxHealth;
            private set
            {
                if (value == _maxHealth) return;
                _maxHealth = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                if (value < 0)
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
            private set
            {
                if (value == _maxEnergy) return;
                _maxEnergy = value;
                NotifyPropertyChanged();
            }
        }


        public int CurrentEnergy
        {
            get => _currentEnergy;
            private set
            {
                if (value < 0)
                    throw new Exception("energy nemoze byt menej ako 0 ?");
                if (value == _currentEnergy) return;
                if (value > _maxEnergy)
                    _currentEnergy = _maxEnergy;
                else
                    _currentEnergy = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxTerror
        {
            get => _maxTerror;
            private set
            {
                if (value == _maxTerror) return;
                _maxTerror = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentTerror
        {
            get => _currentTerror;
            private set
            {
                if (value < 0)
                {
                    _currentTerror = 0;
                    return;
                    // LOG throw new Exception("terror nemoze byt menej ako 0 ?");
                }
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
            private set
            {
                if (value == _food) return;
                _food = value;
                NotifyPropertyChanged();
            }
        }


        public int Reputation
        {
            get => _reputation;
            private set
            {
                if (value == _reputation) return;
                _reputation = value;
                NotifyPropertyChanged();
            }
        }


        public int Wealth
        {
            get => _wealth;
            private set
            {
                if (value == _wealth) return;
                _wealth = value;
                NotifyPropertyChanged();
            }
        }


        public int Experience
        {
            get => _experience;
            private set
            {
                if (value == _experience) return;
                _experience = value;
                NotifyPropertyChanged();
            }
        }

        public int Magic
        {
            get => _magic;
            private set
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


        public void EditCharProperty(CharacterAttribute attr, EditCharPropertyChangeType type = 0, int value = 0)
        {
            CheckInvalidAtributeChange(attr, type, value);
            
            switch (attr)
            {
                case CharacterAttribute.Aggression:
                    ++Aggression;
                    break;
                case CharacterAttribute.Courage:
                    ++Courage;
                    break;
                case CharacterAttribute.Practicality:
                    ++Practicality;
                    break;
                case CharacterAttribute.Empathy:
                    ++Empathy;
                    break;
                case CharacterAttribute.Caution:
                    ++Caution;
                    break;
                case CharacterAttribute.Spirituality:
                    ++Spirituality;
                    break;
                case CharacterAttribute.CurrentHealth:
                    CurrentHealth = EditHET(CurrentHealth, type, value);
                    break;
                case CharacterAttribute.CurrentEnergy:
                    CurrentEnergy = EditHET(CurrentEnergy, type, value);
                    break;
                case CharacterAttribute.CurrentTerror:
                    CurrentTerror = EditHET(CurrentTerror, type, value);
                    break;
                case CharacterAttribute.MaxHealth:
                case CharacterAttribute.MaxEnergy:
                case CharacterAttribute.MaxTerror:
                    throw new NotImplementedException();
                case CharacterAttribute.Food:
                    Food = EditFRWEM(Food, type, value);
                    break;
                case CharacterAttribute.Reputation:
                    Reputation = EditFRWEM(Reputation, type, value);
                    break;
                case CharacterAttribute.Wealth:
                    Wealth = EditFRWEM(Wealth, type, value);
                    break;
                case CharacterAttribute.Experience:
                    Experience = EditFRWEM(Experience, type, value);
                    break;
                case CharacterAttribute.Magic:
                    Magic = EditFRWEM(Magic, type, value);
                    break;
                default:
                    break;
            }
        }

        private int EditFRWEM(int i, EditCharPropertyChangeType t, int value)
        {
            //cant call max on this one
            if (t == EditCharPropertyChangeType.ToMax)
                throw new Exception();

            if (t == EditCharPropertyChangeType.Add)
               return i += value;
            else if (t == EditCharPropertyChangeType.Subtract)
                return i -= value;
            else
                return 0;
        }

        private int EditHET(int i, EditCharPropertyChangeType t, int value)
        {
            if (t == EditCharPropertyChangeType.Add)
                return i += value;
            else if (t == EditCharPropertyChangeType.Subtract)
                return i -= value;
            else if (t == EditCharPropertyChangeType.ToZero)
                return 0;
            else
                return int.MaxValue;
        }

        private void CheckInvalidAtributeChange(CharacterAttribute attr, EditCharPropertyChangeType type, int value = 0)
        {
            var onlyAdd = new List<EditCharPropertyChangeType>(new[] { 
                EditCharPropertyChangeType.Subtract, 
                EditCharPropertyChangeType.ToMax, 
                EditCharPropertyChangeType.ToZero });

            var exceptMax = new List<EditCharPropertyChangeType>(new[] {
                EditCharPropertyChangeType.Subtract,
                EditCharPropertyChangeType.ToMax,
                EditCharPropertyChangeType.ToZero });

            switch (attr)
            {
                case CharacterAttribute.Aggression:
                case CharacterAttribute.Courage:
                case CharacterAttribute.Practicality:
                case CharacterAttribute.Empathy:
                case CharacterAttribute.Caution:
                case CharacterAttribute.Spirituality:
                    if (onlyAdd.Contains(type) || value <= 0)
                        throw new Exception();
                    break;
                case CharacterAttribute.CurrentHealth:
                    
                    break;
                case CharacterAttribute.CurrentEnergy:
                    break;
                case CharacterAttribute.CurrentTerror:
                    break;
                case CharacterAttribute.MaxHealth:
                    break;
                case CharacterAttribute.MaxEnergy:
                    break;
                case CharacterAttribute.MaxTerror:
                    break;
                case CharacterAttribute.Food:
                case CharacterAttribute.Reputation:
                case CharacterAttribute.Wealth:
                case CharacterAttribute.Experience:
                case CharacterAttribute.Magic:
                    if (type == EditCharPropertyChangeType.ToMax || value <= 0) throw new Exception();
                    break;
                default:
                    break;
            }
        }
    }

    public enum CharacterAttribute
    {
        Aggression,
        Courage,
        Practicality,
        Empathy,
        Caution,
        Spirituality,
        CurrentHealth,
        CurrentEnergy,
        CurrentTerror,
        MaxHealth,
        MaxEnergy,
        MaxTerror,
        Food,
        Reputation,
        Wealth,
        Experience,
        Magic,
    }

    public enum EditCharPropertyChangeType
    {
        None,
        Add,
        Subtract,
        ToZero,
        ToMax,
    }

}