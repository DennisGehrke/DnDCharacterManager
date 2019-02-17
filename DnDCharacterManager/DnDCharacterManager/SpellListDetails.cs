using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Reflection;

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
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };
            Label lblClasses = new Label();
            Label lblPreClasses = new Label() { Text = "Classes: " };
            Label lblSpellType = new Label();
            Label lblCastingTime = new Label();
            Label lblPreCastingTime = new Label() { Text = "Casting Time: " };
            Label lblRange = new Label();
            Label lblPreRange = new Label() { Text = "Range: " };
            Label lblComponents = new Label();
            Label lblPreComponents = new Label() { Text = "Components: " };
            Label lblDuration = new Label();
            Label lblPreDuration = new Label { Text = "Duration: " };
            Label lblShortDesc = new Label();
            Label lblDesc = new Label();
            Button btnFav = new Button
            {
                HorizontalOptions = LayoutOptions.End
            };
            btnFav.Image = "favorite_star_unselected.png";
            Image imgFav = new Image
            {
                Source = ImageSource.FromResource("DnDCharacterManager.Resources.favorite_star_unselected.png", typeof(SpellListDetails).GetTypeInfo().Assembly),
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 30
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if (imgFav.Source == ImageSource.FromResource("DnDCharacterManager.Resources.favorite_star_unselected.png", typeof(SpellListDetails).GetTypeInfo().Assembly))
                {
                    imgFav.Source = ImageSource.FromResource("DnDCharacterManager.Resources.favorite_star_selected.png", typeof(SpellListDetails).GetTypeInfo().Assembly);
                }
                else
                {
                    imgFav.Source = ImageSource.FromResource("DnDCharacterManager.Resources.favorite_star_unselected.png", typeof(SpellListDetails).GetTypeInfo().Assembly);
                }
            };
            imgFav.GestureRecognizers.Add(tapGestureRecognizer);
            
            StackLayout slWrapper = new StackLayout() { BackgroundColor = Color.DarkOliveGreen};
            StackLayout slTitle = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Aqua,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout slDetails = new StackLayout();
            StackLayout slClasses = new StackLayout() { Orientation = StackOrientation.Horizontal };
            StackLayout slCastingTime = new StackLayout() { Orientation = StackOrientation.Horizontal };
            StackLayout slRange = new StackLayout() { Orientation = StackOrientation.Horizontal };
            StackLayout slComponents = new StackLayout() { Orientation = StackOrientation.Horizontal };
            StackLayout slDuration = new StackLayout() { Orientation = StackOrientation.Horizontal };

            lblName.SetBinding(Label.TextProperty, new Binding("SName"));
            lblClasses.SetBinding(Label.TextProperty, new Binding("SAllClasses"));
            lblSpellType.SetBinding(Label.TextProperty, new Binding("SSpellType"));
            lblCastingTime.SetBinding(Label.TextProperty, new Binding("SCastingTime"));
            lblRange.SetBinding(Label.TextProperty, new Binding("SRange"));
            lblComponents.SetBinding(Label.TextProperty, new Binding("SAllComponents"));
            lblDuration.SetBinding(Label.TextProperty, new Binding("SDuration"));
            lblShortDesc.SetBinding(Label.TextProperty, new Binding("SShortDesc"));
            lblDesc.SetBinding(Label.TextProperty, new Binding("SDesc"));

            slDetails.SetBinding(StackLayout.IsVisibleProperty, new Binding("IsVisible"));

            slClasses.Children.Add(lblPreClasses);
            slClasses.Children.Add(lblClasses);

            slCastingTime.Children.Add(lblPreCastingTime);
            slCastingTime.Children.Add(lblCastingTime);

            slRange.Children.Add(lblPreRange);
            slRange.Children.Add(lblRange);

            slComponents.Children.Add(lblPreComponents);
            slComponents.Children.Add(lblComponents);

            slDuration.Children.Add(lblPreDuration);
            slDuration.Children.Add(lblDuration);

            slDetails.Children.Add(slClasses);
            slDetails.Children.Add(slCastingTime);
            slDetails.Children.Add(slRange);
            slDetails.Children.Add(slComponents);
            slDetails.Children.Add(slDuration);
            slDetails.Children.Add(lblDesc);

            slTitle.Children.Add(lblName);
            slTitle.Children.Add(imgFav);

            slWrapper.Children.Add(slTitle);
            slWrapper.Children.Add(slDetails);

            View = slWrapper;
        }
    }
}
