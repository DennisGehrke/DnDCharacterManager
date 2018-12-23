using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace DnDCharacterManager
{
    public class App : Application
    {
        public App()
        {
            var cCharManager = new CharManager();
            MainPage = new ListViewSpells(cCharManager.lSpellList);
            
        }
    }
}
