using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using MvvmApp.Views;
using System.IO;

namespace MvvmApp.ViewModels
{
    public class FlowersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FlowerViewModel> Flowers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateFlowerCommand { protected set; get; }
        public ICommand DeleteFlowerCommand { protected set; get; }
        public ICommand SaveFlowerCommand { protected set; get; }
        public ICommand RandomFlowerCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        FlowerViewModel selectedFlower;
        public INavigation Navigation { get; set; }

        public FlowersListViewModel()
        {
            Flowers = new ObservableCollection<FlowerViewModel>();
            CreateFlowerCommand = new Command(CreateFlower);
            RandomFlowerCommand = new Command(RandomFlower);
            DeleteFlowerCommand = new Command(DeleteFlower);
            SaveFlowerCommand = new Command(SaveFlower);
            BackCommand = new Command(Back);
        }

        public FlowerViewModel SelectedFlower
        {
            get { return selectedFlower; }
            set
            {
                if (selectedFlower != value)
                {
                    FlowerViewModel tempFlower = value;
                    selectedFlower = null;
                    OnPropertyChanged("SelectedFlower");
                    Navigation.PushAsync(new FlowerPage(tempFlower));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateFlower()
        {
            Navigation.PushAsync(new FlowerPage(new FlowerViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveFlower(object flowerObject)
        {
            FlowerViewModel flower = flowerObject as FlowerViewModel;
            if (flower != null && flower.IsValid)
            {
                Flowers.Add(flower);
            }
            Back();
        }

        private void DeleteFlower(object flowerObject)
        {
            FlowerViewModel flower = flowerObject as FlowerViewModel;
            if (flower != null)
            {
                Flowers.Remove(flower);
            }
            Back();
        }

        private void RandomFlower(object flowerObject)
        {
            Random rdr = new Random();
            int i = rdr.Next(0, 2);
            string[] name = { "Роза", "Тюльпан", "Пион" };
            string[] family = { "Роза", "Тюльпан", "Пион" };
            string[] variety = { "Розовые", "Тюльпаны", "Пионы" };
            string[] order = { "Розоцветные", "Тюльпаные", "Пионные" };
            string[] color = { "Красный", "Желтый", "Зелыный" };
            string[] cLass = { "Однодольные", "Двудольные", "Другое" };
            
            FlowerViewModel flower = flowerObject as FlowerViewModel;
                flower.Name = name[i];
                flower.Family = family[i];
                flower.Variety = variety[i];
                flower.Order = order[i];
                flower.Class = cLass[i];
                flower.Color = color[i];
                Flowers.Add(flower);
            Back();
        }
    }
}
