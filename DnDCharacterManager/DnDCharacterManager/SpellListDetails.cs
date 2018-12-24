using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;

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
            Label lblName = new Label()
            {
                FontSize = 25,
                Margin = 10,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label lblDuration = new Label();
            Label lblRange = new Label();

            StackLayout wrapper = new StackLayout();
            StackLayout details = new StackLayout();

            lblName.SetBinding(Label.TextProperty, new Binding("SName"));
            lblDuration.SetBinding(Label.TextProperty, new Binding("SDuration"));
            lblRange.SetBinding(Label.TextProperty, new Binding("SRange"));
            details.SetBinding(StackLayout.IsVisibleProperty, new Binding("IsVisible"));

            details.Children.Add(lblRange);
            details.Children.Add(lblDuration);
            wrapper.Children.Add(lblName);
            wrapper.Children.Add(details);

            View = wrapper;
        }
    }
}
