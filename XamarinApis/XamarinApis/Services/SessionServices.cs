using System;
using System.Collections.Generic;
using System.Text;
using XamarinApis.Models;

namespace XamarinApis.Services
{
   public class SessionServices
    {
        public List<Doctores> Favoritos { get; set; }

        public SessionServices()
        {
            this.Favoritos = new List<Doctores>();
        }
    }
}
