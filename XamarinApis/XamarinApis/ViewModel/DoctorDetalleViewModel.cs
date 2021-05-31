using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModel
{
    public class DoctorDetalleViewModel:ViewModelBase
    {
        ServiceDoctores serviceDoctores;

        public DoctorDetalleViewModel(ServiceDoctores service)
        {
            this.serviceDoctores = service;
        }
        private Doctores _Doctor;

        public Doctores Doctor
        {
            get { return this._Doctor; }
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        public Command EliminarDoctor
        {
            get
            {
                return new Command(async() =>
                {
                    await this.serviceDoctores.DeleteDoctorAsync(Doctor.IdDoctores);
                    MessagingCenter.Send(App.ServiceLocator.DoctoresViewModel, "REFRESH");
                    await Application.Current.MainPage.DisplayAlert("Alert","Doctor "
                        +Doctor.Apellido+" eliminado","OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }

        public Command MarcarFavorito
        {
            get
            {
                return new Command(async () =>
                {
                    SessionServices session = App.ServiceLocator.SessionServices;
                    session.Favoritos.Add(this.Doctor);
                    await Application.Current.MainPage.DisplayAlert
                    ("Alert","Doctor almacenados", "OK");
                });
            }
        }
    }
}
