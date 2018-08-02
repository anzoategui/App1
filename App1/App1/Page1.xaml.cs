using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}
        void pickMusic1(object sender, System.EventArgs e)
        {
            var elementoSeleccionado = pickMusic.SelectedItem.ToString();
            DisplayAlert("Genero Musica", elementoSeleccionado, "Aceptar");
        }
        void btnSimular_Clicked(object sender,System.EventArgs e)
        {
            var progreso = progressNum.Progress;
            if(progreso== 1)
            {
                progressNum.ProgressTo(.1, 250, Easing.SpringOut);
            }
            else
            {
                progressNum.ProgressTo(.1, 300, Easing.Linear);
            }
        }
        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("Buscando", "Buscando Resultados", "Aceptar");
        }
        void Handle_TextChanged(object sender, System.EventArgs e)
        {
            DisplayAlert("Cambiando", "Este Texto esta cambiando", "Aceptar");
        }
        void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            labCambio.Text = slider.Value.ToString();
        }
        void stepEvent(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            lbDisplay.Text = steeper.Value.ToString();
        }
    }
}