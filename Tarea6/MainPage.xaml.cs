using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace Tarea6
{
   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void bntInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.1.109/moviles/post.php", "POST", parametros);
                await DisplayAlert("Alerta", "Registro Exitoso!!", "ok");

            }
            catch (Exception ex)


            {
                await DisplayAlert("Alerta", "Error" + ex.Message, "ok");
            }
        }
        private async  void bntRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}