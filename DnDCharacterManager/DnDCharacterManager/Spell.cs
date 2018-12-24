using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DnDCharacterManager
{
    public class Spell : IComparable<Spell>, INotifyPropertyChanged
    {
        public string SName { get; private set; }
        public int ILevel { get; private set; }
        public readonly List<string> lClasses;
        public string SAllClasses
        {
            get
            {
                string sTemp = "";
                foreach(string sClass in lClasses)
                {
                    if (sTemp == "")
                        sTemp = sClass;
                    else
                        sTemp += ", " + sClass;
                }
                return sTemp;
            }
        }
        public string SCastingTime { get; private set; }
        public string SRange { get; private set; }
        public string SSpellType { get; private set; }
        public readonly List<string> lComponents;
        public string SAllComponents
        {
            get
            {
                string sTemp = "";
                foreach (string component in lComponents)
                {
                    if (sTemp == "")
                        sTemp = component;
                    else
                        sTemp += ", " + component;
                }
                return sTemp;
            }
        }
        public string SDuration { get; private set; }
        public string SDesc { get; private set; }
        public string SShortDesc { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isVisible;
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                if (isVisible != value)
                    isVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsVisible"));
            }
        }

        public Spell(string sName, int iLevel, List<string> lClasses, string sCastingTime, string sRange, string sSpellType, List<string> lComponents, string sDuration, string sDesc, string sShortDesc)
        {
            SName = sName;
            this.ILevel = iLevel;
            this.lClasses = lClasses;
            this.SCastingTime = sCastingTime;
            SRange = sRange;
            this.SSpellType = sSpellType;
            this.lComponents = lComponents;
            SDuration = sDuration;
            this.SDesc = sDesc;
            this.SShortDesc = sShortDesc;
        }

        public int CompareTo(Spell compareSpell)
        {
            // A null value means that this object is greater.
            if (compareSpell == null)
                return 1;

            else
                return SName.CompareTo( compareSpell.SName);
        }
    }
}
