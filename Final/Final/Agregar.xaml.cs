using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregar : ContentPage
    {
        private const string url = "https://products-xamarin-api.herokuapp.com/api/productos/";
        public Agregar()
        {
            InitializeComponent();
        }
        async void CancelarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void AgregarClicked(object sender, EventArgs e)
        {
            ModeloProd md = new ModeloProd {descripcion= descripcion.Text , precio = precio.Text};
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(md);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpClient.PostAsync(String.Format(url), httpContent);
            Console.WriteLine("Producto Agregado" + httpContent);

            Navigation.PopAsync();


        }
    }
}