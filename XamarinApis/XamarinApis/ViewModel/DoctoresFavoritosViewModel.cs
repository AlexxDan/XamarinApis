using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinApis.Base;
using XamarinApis.Models;
using XamarinApis.Services;

namespace XamarinApis.ViewModel
{
    public class DoctoresFavoritosViewModel:ViewModelBase
    {
        public DoctoresFavoritosViewModel()
        {
            SessionServices session =
            App.ServiceLocator.SessionServices;
            this.Doctores =
            new ObservableCollection<Doctores>(session.Favoritos);
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
        

    }
}
