using Final.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Final
{
    public partial class MainPage : ContentPage
    {
        
        private const string url = "https://products-xamarin-api.herokuapp.com/api/productos/";

        private ObservableCollection<Productos> productos;
        public MainPage()
        {
            InitializeComponent();
        }
        async void AgregarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Agregar());
        }

        protected override async void OnAppearing()
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            List<Productos> productosClase = JsonConvert.DeserializeObject<List<Productos>>(content);
            Console.WriteLine("contenido" +content);
            productos = new ObservableCollection<Productos>(productosClase);
            MiLista.ItemsSource = productos;
            base.OnAppearing();
        }

        private void producto_seleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as Productos;
            string url = $"https://products-xamarin-api.herokuapp.com/api/productos/{itemSelectedData._id}";

            var httpClient = new HttpClient();
            httpClient.DeleteAsync(String.Format(url));

            Navigation.PushAsync(new MainPage());

        }
        
    }

}
