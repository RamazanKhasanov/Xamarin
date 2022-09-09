using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using MvvmApp.Models;

namespace MvvmApp.ViewModels
{
    public class FlowerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FlowersListViewModel lvm;

        public Flower Flower { get; set; }

        public FlowerViewModel()
        {
            Flower = new Flower();
        }

        public FlowersListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Flower.Name; }
            set
            {
                if (Flower.Name != value)
                {
                    Flower.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Color
        {
            get { return Flower.Color; }
            set
            {
                if (Flower.Color != value)
                {
                    Flower.Color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        public string Variety
        {
            get { return Flower.Variety; }
            set
            {
                if (Flower.Variety != value)
                {
                    Flower.Variety = value;
                    OnPropertyChanged("Variety");
                }
            }
        }

        public string Class
        {
            get { return Flower.Class; }
            set
            {
                if (Flower.Class != value)
                {
                    Flower.Class = value;
                    OnPropertyChanged("Class");
                }
            }
        }

        public string Order
        {
            get { return Flower.Order; }
            set
            {
                if (Flower.Order != value)
                {
                    Flower.Order = value;
                    OnPropertyChanged("Order");
                }
            }
        }

        public string Family
        {
            get { return Flower.Family; }
            set
            {
                if (Flower.Family != value)
                {
                    Flower.Family = value;
                    OnPropertyChanged("Family");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                (!string.IsNullOrEmpty(Color.Trim())) ||
                (!string.IsNullOrEmpty(Variety.Trim())) ||
                (!string.IsNullOrEmpty(Class.Trim())) ||
                (!string.IsNullOrEmpty(Order.Trim())) ||
                (!string.IsNullOrEmpty(Family.Trim())));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
