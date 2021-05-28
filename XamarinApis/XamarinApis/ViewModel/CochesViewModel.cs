using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModel
{
    public class CochesViewModel : ViewModelBase
    {
        ServiceCoches services;

        public CochesViewModel()
        {
            this.services = new ServiceCoches();
            Task.Run(async () =>
            {
             await this.LoadCochesAsync();
            });
        }

        private async Task LoadCochesAsync()
        {
            List<Coche> coches =await this.services.GetCochesAsync();
            this.Coches = new ObservableCollection<Coche>(coches);
        }

        private ObservableCollection<Coche> _Coches;

        public ObservableCollection<Coche> Coches
        {
            get
            {
                return this._Coches;
            }
            set
            {
                this._Coches = value;
                OnPropertyChanged("Coches");
            }
        }

        public Command MostrarCoches
        {
            get
            {
                return new Command(async () =>
                {
                    await this.LoadCochesAsync();
                });
            }
        }

    }
}
