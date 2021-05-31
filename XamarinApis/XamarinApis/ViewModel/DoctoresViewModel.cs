using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;
using XamarinApis.View;

namespace XamarinApis.ViewModel
{
    public class DoctoresViewModel:ViewModelBase
    {

        ServiceDoctores serviceDoctores;
        public DoctoresViewModel(ServiceDoctores service)
        {
            this.serviceDoctores = service;
            Task.Run(async () =>
            {
                await this.CargarDoctores();
            });
            MessagingCenter.Subscribe<DoctorDetalleViewModel>
                (this, "REFRESH", async(sender)=>
                {
                    await this.CargarDoctores();
                });
        }

        private ObservableCollection<Doctores> _Doctores;

        public ObservableCollection<Doctores> Doctores
        {
            get { return this._Doctores; }
            set
            {
                this._Doctores = value;
                OnPropertyChanged("Doctores");
            }
        }
        private async Task CargarDoctores()
        {
            List<Doctores> doctores = await this.serviceDoctores.GetDoctoresAsync();
            this.Doctores = new ObservableCollection<Doctores>(doctores);
        }

        public Command DetalleDoctor
        {
            get {
                return new Command((doctor) =>
                {
                    //Buscamos al doctor y lo mandamos a otra vista/ 
                    //Creamos el viewmodel
                    DoctorDetalleViewModel viewmodel = App.ServiceLocator.DoctorDetalleViewModel;
                    viewmodel.Doctor = doctor as Doctores;

                    DoctoresDetallesView view = new DoctoresDetallesView();

                    view.BindingContext = viewmodel;
                    Application.Current.MainPage
                    .Navigation.PushModalAsync(view);

                });
            }
        }

        public Command MarcarFavoritos
        {
            get
            {
                return new Command(async(doctor) =>
                {
                    SessionServices session = App.ServiceLocator.SessionServices;
                    session.Favoritos.Add(doctor as Doctores);
                    await Application.Current.MainPage.DisplayAlert(
                        "Alert", "Documento almacenado", "OK");
                });
            }
        }

        public Command MostrarFavoritos
        {
            get
            {
                return new Command(async () =>
                {
                    DoctoresFavoritosView view = new DoctoresFavoritosView();
                    await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });

            }
        }
    }
}
