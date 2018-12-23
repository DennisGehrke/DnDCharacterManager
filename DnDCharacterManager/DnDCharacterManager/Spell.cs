using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterManager
{
    public class Spell : IComparable<Spell>
    {
        public string SName { get; private set; }
        public readonly int iLevel;
        public readonly List<string> lClasses;
        public readonly string sCastingTime;
        public readonly string sRange;
        public readonly string sSpellType;
        public readonly List<string> lComponents;
        public readonly string sDuration;
        public readonly string sDesc;
        public readonly string sShortDesc;

        public Spell(string sName, int iLevel, List<string> lClasses, string sCastingTime, string sRange, string sSpellType, List<string> lComponents, string sDuration, string sDesc, string sShortDesc)
        {
            SName = sName;
            this.iLevel = iLevel;
            this.lClasses = lClasses;
            this.sCastingTime = sCastingTime;
            this.sRange = sRange;
            this.sSpellType = sSpellType;
            this.lComponents = lComponents;
            this.sDuration = sDuration;
            this.sDesc = sDesc;
            this.sShortDesc = sShortDesc;
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
