using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.ViewModel;

namespace XamarinApis.Services
{
    public class ServiceIoC
    {

        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<DoctoresViewModel>();
            builder.RegisterType<DoctorDetalleViewModel>();
            builder.RegisterType<DoctoresFavoritosViewModel>();
            builder.RegisterType<DoctorViewModel>();
            builder.RegisterType<ServiceDoctores>();
            builder.RegisterType<SessionServices>().SingleInstance();
            this.container = builder.Build();
        }

        public DoctoresViewModel DoctoresViewModel
        {
            get
            {
                return this.container.Resolve<DoctoresViewModel>();
            }
        }

        public DoctorDetalleViewModel DoctorDetalleViewModel
        {
            get
            {
                return this.container.Resolve<DoctorDetalleViewModel>();
            }
        }

        public SessionServices SessionServices
        {
            get
            {
                return this.container.Resolve<SessionServices>();
            }
        }

        public DoctoresFavoritosViewModel DoctoresFavoritosViewModel
        {
            get
            {
                return this.container.Resolve<DoctoresFavoritosViewModel>();
            }
        }

        public DoctorViewModel DoctorViewModel
        {
            get
            {
                return this.container.Resolve<DoctorViewModel>();
            }
        }
    }
}
