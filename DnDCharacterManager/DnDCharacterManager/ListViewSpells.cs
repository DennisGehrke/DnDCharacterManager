using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using Expandable;

namespace DnDCharacterManager
{
    class ListViewSpells : ContentPage
    {
        public ListViewSpells(List<Spell> lSpellList)
        {
            var listView = new ListView();
            
        //    var mainStack = new StackLayout();
        //    var mainScroll = new ScrollView();
        //    mainScroll.Content = mainStack;
        //    foreach (Spell spell in lSpellList)
        //    {
        //        string sComponents = "";
        //        foreach (string sComponent in spell.lComponents)
        //        {
        //            if (sComponents != "")
        //                sComponents += sComponents + ", " + sComponent;
        //            else
        //                sComponents = sComponent;
        //        }
        //        var nameLabel = new Label
        //        {
        //            FontSize = 22,
        //            VerticalTextAlignment = TextAlignment.Start,
        //            HorizontalTextAlignment = TextAlignment.Center,
        //            FontAttributes = FontAttributes.Bold,
        //            HeightRequest = 60,
        //            BackgroundColor = Color.White,
        //            TextColor = Color.Black,
        //            Text = spell.sName
        //        };
        //        var tgr = new TapGestureRecognizer();
        //        tgr.Tapped += (s, e) =>
        //        nameLabel.GestureRecognizers.Add(tgr);
                
        //        var newStack = new StackLayout
        //        {
        //            Spacing = 10,
        //            Padding = new Thickness(20, 0),
        //            Children = {
        //                    nameLabel,
        //                    new StackLayout
        //                    {
        //                        Spacing = 10,
        //                        Padding = new Thickness(20, 0),
        //                        Children = {
        //                            new Label
        //                            {
        //                                ClassId = "1",
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 40,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = spell.sSpellType
        //                            },
        //                            new Label
        //                            {
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 40,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = spell.sCastingTime
        //                            },
        //                            new Label
        //                            {
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 40,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = spell.sRange
        //                            },
        //                            new Label
        //                            {
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 40,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = sComponents
        //                            },
        //                            new Label
        //                            {
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 40,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = spell.sDuration
        //                            },
        //                            new Label
        //                            {
        //                                VerticalTextAlignment = TextAlignment.Center,
        //                                HorizontalTextAlignment = TextAlignment.Start,
        //                                HeightRequest = 500,
        //                                BackgroundColor = Color.White,
        //                                TextColor = Color.Black,
        //                                Text = spell.sDesc
        //                            }
        //                        }
        //                    }
        //                }
        //        });
        //        mainStack.Children.Add();
        //    }
        //}
                    //new ExpandableView
                    //{
                    //    PrimaryView = new Label
                    //    {
                    //        FontSize = 22,
                    //        VerticalTextAlignment = TextAlignment.Start,
                    //        HorizontalTextAlignment = TextAlignment.Center,
                    //        FontAttributes = FontAttributes.Bold,
                    //        HeightRequest = 60,
                    //        BackgroundColor = Color.White,
                    //        TextColor = Color.Black,
                    //        Text = spell.sName
                    //    },

                //    SecondaryViewTemplate = new DataTemplate(() => new StackLayout
                //    {
                //        Spacing = 10,
                //        Padding = new Thickness(20, 0),
                //        Children = {
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 40,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = spell.sSpellType
                //        },
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 40,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = spell.sCastingTime
                //        },
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 40,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = spell.sRange
                //        },
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 40,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = sComponents
                //        },
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 40,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = spell.sDuration
                //        },
                //        new Label
                //        {
                //            VerticalTextAlignment = TextAlignment.Center,
                //            HorizontalTextAlignment = TextAlignment.Start,
                //            HeightRequest = 500,
                //            BackgroundColor = Color.White,
                //            TextColor = Color.Black,
                //            Text = spell.sDesc
                //        }
                //    }
                //    })
            //listView.ItemsSource = lOSpellList;

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

        private void ExecuteRefreshItemsCommand(HotelViewModel item)
        {
            if (_oldHotel == item)
            {
                // click twice on the same item will hide it
                item.Expanded = !item.Expanded;
            }
            else
            {
                if (_oldHotel != null)
                {
                    // hide previous selected item
                    _oldHotel.Expanded = false;
                }
                // show selected item
                item.Expanded = true;
            }

            _oldHotel = item;
        }
    }
}
