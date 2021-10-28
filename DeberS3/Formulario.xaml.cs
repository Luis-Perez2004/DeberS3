using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeberS3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario(string usuario)
        {
            InitializeComponent();
            lbusuario.Text = "Usuario: " + usuario;

        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                double NotaS1 = 0, NotaE1 = 0, Notaparcial1 = 0, E_NP1 = 0;
                double NotaS2 = 0, NotaE2 = 0, Notaparcial2 = 0, E_NP2 = 0;

                //Parcial 1
                NotaS1 = Convert.ToDouble(NS1.Text);
                NotaE1 = Convert.ToDouble(EP1.Text);
                Notaparcial1 = (NotaS1 * 0.6) + (NotaE1 * 0.4);
                E_NP1 = ((NotaS1 * 0.6) + (NotaE1 * 0.4)) / 2;

                //Parcial 2
                NotaS2 = Convert.ToDouble(NS2.Text);
                NotaE2 = Convert.ToDouble(EP2.Text);
                Notaparcial2 = (NotaS2 * 0.6) + (NotaE2 * 0.4);
                E_NP2 = ((NotaS2 * 0.6) + (NotaE2 * 0.4)) / 2;

                //Validación
                if (NotaS1 < 0 | NotaS1 > 11)
                {
                    DisplayAlert("Alerta", "La nota de seguimiento debe ser de 1 a 10", "OK");
                    NotaS1 = 0;
                    NS1.Text = "";
                    NS1.Focus();
                }
                else
                {
                    if (NotaE1 < 0 | NotaE1 > 11)
                    {
                        DisplayAlert("Alerta", "La nota del examen debe ser de 1 a 10", "OK");
                        NotaE1 = 0;
                        EP1.Text = "";
                        EP1.Focus();
                    }
                    else
                    {
                        if (NotaS2 < 0 | NotaS2 > 11)
                        {
                            DisplayAlert("Alerta", "La nota de seguimiento debe ser de 1 a 10", "OK");
                            NotaS2 = 0;
                            NS2.Text = "";
                            NS2.Focus();
                        }
                        else
                        {
                            if (NotaE2 < 0 | NotaE2 > 11)
                            {
                                DisplayAlert("Alerta", "La nota del examen debe ser de 1 a 10", "OK");
                                NotaE2 = 0;
                                EP2.Text = "";
                                EP2.Focus();
                            }
                        }
                    }
                }

                //Cálculo
                if (NotaS1 > 0 & NotaS1 < 11 & NotaE1 > 0 & NotaE1 < 11 & NotaS2 > 0 & NotaS2 < 11 & NotaE2 > 0 & NotaE2 < 11)
                {
                    ENS1.Text = Convert.ToString(NotaS1 * 0.6);
                    EEP1.Text = Convert.ToString(NotaE1 * 0.4);
                    NP1.Text = Convert.ToString(Notaparcial1);
                    ENP1.Text = Convert.ToString(((NotaS1 * 0.6) + (NotaE1 * 0.4)) / 2);

                    ENS2.Text = Convert.ToString(NotaS2 * 0.6);
                    EEP2.Text = Convert.ToString(NotaE2 * 0.4);
                    NP2.Text = Convert.ToString(Notaparcial2);
                    ENP2.Text = Convert.ToString(((NotaS2 * 0.6) + (NotaE2 * 0.4)) / 2);

                    //Nota final
                    NF.Text = Convert.ToString(E_NP1 + E_NP2);

                    //Estado
                    if ((E_NP1 + E_NP2) >= 7 & (E_NP1 + E_NP2) <= 10)
                    {
                        ES.Text = "APROBADO";
                    }
                    else
                    {
                        if ((E_NP1 + E_NP2) < 7 & (E_NP1 + E_NP2) >= 5)
                        {
                            ES.Text = "SUPLETORIO";
                        }
                        else
                        {
                            if ((E_NP1 + E_NP2) < 5)
                            {
                                ES.Text = "REPROBADO";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }

        }
    }
}