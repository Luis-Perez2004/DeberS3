using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeberS3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuraio.Text;
            string password = txtPassword.Text;

            if (usuario == "lperez" & password == "123456")
            {
                await Navigation.PushAsync(new Formulario(usuario));
            }
            else
            {
                DisplayAlert("Mensaje","Usuario o contraseña invalidos","OK");

                txtUsuraio.Text = "";
                txtPassword.Text = "";
                txtUsuraio.Focus();
            }
        }
    }
}
