using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        async void Continue_Tapped(object sender, EventArgs e)
        {
            if(await validarFormulario())
            {
                await DisplayAlert("Exito", "Todos los campos cumplieron las validaciones", "OK");
            }
        }
        private async Task<bool> validarFormulario()
        {
            if (String.IsNullOrWhiteSpace(UserName.Text) & String.IsNullOrWhiteSpace(UserLastName.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo nombre es obligatorio", "OK");
                return false;
            }
            else if (!UserName.Text.ToArray().All(char.IsLetter))
            {
                await this.DisplayAlert("Advertencia", "Tu informacion contiene numeros", "OK");
                return false;
            }
            else
            {
                string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
                bool resultado = Regex.IsMatch(UserName.Text, caractEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracteres especiales", "OK");
                    return false;
                }
            }
            if (String.IsNullOrWhiteSpace(UserEmail.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo nombre es obligatorio", "OK");
                return false;
            }
            else {
                bool isEmail = Regex.IsMatch(UserEmail.Text, @"\A(?:[a-z0-
                9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-
                z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-
                9])?\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del correo electronico es incorrecto, reviselo e intente de nuevo","OK");
                    return false;
                }

            }
            if (String.IsNullOrWhiteSpace(UserCelular.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo nombre es obligatorio", "OK");
                return false;
            }
            else if (UserCelular.Text.Length != 10)
            {
                await this.DisplayAlert("Advertencia", "Faltan digitos, favor ingresar los 10 digitos", "OK");
                return false;
            }
            else
            {
                if (!UserCelular.Text.ToArray().All(char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "El formato del celular es incorrecto, por favor ingrese solo numeros", "OK");
                    return false;
                }
            }
            return true;
        }

	}
}
