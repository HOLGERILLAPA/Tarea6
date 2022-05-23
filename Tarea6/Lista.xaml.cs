using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista(Datos estudiante)
        {
            InitializeComponent();
            txtCodigo.Text = estudiante.codigo.ToString();
            txtNombre.Text = estudiante.nombre.ToString();
            txtApellido.Text = estudiante.apellido.ToString();
            txtEdad.Text = estudiante.edad.ToString();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var codigo = txtCodigo.Text;
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var edad = txtEdad.Text;

            cliente.UploadString("http://192.168.1.109/moviles/post.php?codigo=" + codigo + "&nombre=" + nombre + "&apellido=" + apellido + "&edad=" + edad, "PUT", "");
            await DisplayAlert("Alerta", "Informacion Actualizado con Exito", "ok");
        }

        private async void bntElminar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var codigo = txtCodigo.Text;
            cliente.UploadString("http://192.168.1.109/moviles/post.php?codigo=" + codigo, "DELETE", "");
            await DisplayAlert("Alerta", "Dato Eliminado con Exito", "ok");
        }
    }
}