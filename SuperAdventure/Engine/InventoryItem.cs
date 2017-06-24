using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private Item _details;  //These are then Backing variables
        private int _quantity;

        public Item Details
        {
            get { return _details; }
            set
            {
                _details = value;
                OnPropertyChanged("Details");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Description");
            }
        }

        public string Description
        {
            get
            {
                return Quantity > 1 ? Details.NamePlural :
                Details.Name;
            }
        }
        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }


        // Generic INotify... Methods
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(
                this, new PropertyChangedEventArgs(name));
            }
        }

        public Item ToItem()
        {
            return new Engine.Item(_details.ID, _details.Name, _details.NamePlural);
        }
    }

}
