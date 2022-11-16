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


namespace S6XImbaquingo
{
    public partial class MainPage : ContentPage
    {
        private const string url = "http://127.0.0.1/factura/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<S6XImbaquingo.WS.Datos> _post;
        public MainPage()
        {
            InitializeComponent();

            
        }
       
        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await cliente.GetStringAsync(url);
            List<S6XImbaquingo.WS.Datos> posts = JsonConvert.DeserializeObject<List<S6XImbaquingo.WS.Datos>>(content);
            _post = new ObservableCollection<S6XImbaquingo.WS.Datos>(posts);

            MyLisView.ItemsSource = _post;
        }

        private  async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());
        }

        
    }
}
