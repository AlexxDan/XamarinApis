using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModel
{
   public class DoctorViewModel:ViewModelBase
    {
        ServiceDoctores serviceDoctores;

        public DoctorViewModel(ServiceDoctores service)
        {
            this.serviceDoctores = service;
            this.Doctor = new Doctores();
        }

        private Doctores _Doctor;

        public Doctores Doctor
        {
            get { return this._Doctor;}
            set
            {
                this._Doctor = value;
                OnPropertyChanged("Doctor");
            }
        }

        public Command InsertarDoctor
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceDoctores.InsertDoctor(Doctor.IdDoctores,Doctor.Apellido,
                        Doctor.Especialidad,Doctor.IdHospital,Doctor.Salario);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Doctor Insertado", "OK");

                });
            }
        }

        public Command ModificarDoctor
        {
            get
            {
                return new Command(async () =>
                {
                    await this.serviceDoctores.UpdateDoctor(Doctor.IdDoctores, Doctor.Apellido,
                        Doctor.Especialidad, Doctor.IdHospital, Doctor.Salario);
                    await Application.Current.MainPage.DisplayAlert("Alert", "Datos actualizados", "OK");
                });
            }
        }
    }
}
