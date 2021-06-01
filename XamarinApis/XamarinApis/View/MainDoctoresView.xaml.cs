using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApis.Code;

namespace XamarinApis.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDoctoresView : MasterDetailPage
    {
        public MainDoctoresView()
        {
            InitializeComponent();
            ObservableCollection<MasterPageItem> menu = new ObservableCollection<MasterPageItem>();

            MasterPageItem doctoresview = new MasterPageItem { 
                Titulo = "Doctores", Tipo = typeof(DoctoresView), Icono = "doctor.png"
            };

            MasterPageItem favoritosview = new MasterPageItem
            {
                Titulo = "Doctores Favoritos",
                Tipo = typeof(DoctoresFavoritosView),
                Icono = "favoritoIcon.png"
            };
            menu.Add(doctoresview);
            menu.Add(favoritosview);

            MasterPageItem insertview = new MasterPageItem
            {
                Titulo = "Insertar Doctores",
                Tipo = typeof(InsertarView),
                Icono = "insert.jpg"
            };
            menu.Add(insertview);

            MasterPageItem modificarview = new MasterPageItem
            {
                Titulo = "Modificar Doctores",
                Tipo = typeof(UpdateDoctor),
                Icono = "modify.png"
            };
            menu.Add(modificarview);

            this.listviewMenu.ItemsSource = menu;


            Detail = new NavigationPage((Page)
                Activator.CreateInstance(typeof(CochesView)));

            this.listviewMenu.ItemSelected += ListviewMenu_ItemSelected;
        }

        private void ListviewMenu_ItemSelected(object sender
            , SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            var tipo = item.Tipo;

            Detail = new NavigationPage((Page)Activator.CreateInstance(tipo));
            IsPresented = false;
        }
    }
}