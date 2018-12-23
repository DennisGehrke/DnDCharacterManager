using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DnDCharacterManager
{
    class SpellListDetails : ViewCell
    { 
        //public static readonly BindableProperty NameProperty =
        //        BindableProperty.Create("sName", typeof(string), typeof(SpellListDetails), "sName");

        //public string Name
        //{
        //    get { return (string)GetValue(NameProperty); }
        //    set { SetValue(NameProperty, value); }
        //}

        public SpellListDetails()
        {
            Label lblName = new Label();
            StackLayout wrapper = new StackLayout();
            lblName.SetBinding(Label.TextProperty, new Binding("SName"));
            wrapper.Children.Add(lblName);
            View = wrapper;
        }
    }
}
