using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DnDCharacterManager
{
    class ListViewDetail
    {
        private bool _expanded;
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StateIcon"));
                    if (_expanded)
                    {
                        this.AddRange(hotelRooms);
                    }
                    else
                    {
                        this.Clear();
                    }
                }
            }
        }
    }
}
