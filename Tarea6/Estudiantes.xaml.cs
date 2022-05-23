using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace Tarea6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Estudiantes : ContentPage
    {
        private const string Url = "http://192.168.1.109/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Tarea6.Datos> _post;
       

        public Estudiantes()
        {
            InitializeComponent();
        }

        private async void bntConsultar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Tarea6.Datos> posts = JsonConvert.DeserializeObject<List<Tarea6.Datos>>(content);
            _post = new ObservableCollection<Tarea6.Datos>(posts);
                    
          
            MyListView.ItemsSource = _post;

        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Estudiante = (Datos)e.SelectedItem;
            try
            {
                await Navigation.PushAsync(new Lista(Estudiante));
            
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}