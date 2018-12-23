using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Expandable;

namespace DnDCharacterManager
{
    class ListViewSpells : ContentPage
    {
        public ListViewSpells(List<Spell> lSpellList)
        {
            ObservableCollection<Spell> spellList = new ObservableCollection<Spell>(lSpellList);

            ListView listView = new ListView
            {
                ItemsSource = spellList,
                ItemTemplate = new DataTemplate(typeof(SpellListDetails))
            };

            // Using ItemTapped
            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            // If using ItemSelected
            //listView.ItemSelected += (sender, e) => {
            //    if (e.SelectedItem == null) return;
            //    Debug.WriteLine("Selected: " + e.SelectedItem);
            //    ((ListView)sender).SelectedItem = null; // de-select the row
            //};
            
            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
    }
}
