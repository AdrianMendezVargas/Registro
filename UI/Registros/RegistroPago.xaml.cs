using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.UI.Registros {
    /// <summary>
    /// Interaction logic for RegistroPago.xaml
    /// </summary>
    public partial class RegistroPago : Window {
        public RegistroPago() {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender , RoutedEventArgs e) {
            Limpiar();
        }

        private void GuardarButton_Click(object sender , RoutedEventArgs e) {

            bool guardado = false;
            int inscripcionId;
            decimal monto;

            if (!Validar()) {
                return;
            }

            //todo: encerrar en try catch
            try {
                inscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
                monto = Convert.ToDecimal(MontoPagarTextBox.Text);

            } catch (Exception) {

                throw;
            }
            Inscripcion inscripcion = InscripcionesBLL.Buscar(inscripcionId);
            inscripcion.Balance -= monto;

            guardado = InscripcionesBLL.Modificar(inscripcion);

            if (guardado) {
                MessageBox.Show("Pago Realizado.");
            } else {
                MessageBox.Show("Error al pagar.");
            }


        }

        private bool Validar() {

            bool validados = true;

            int inscripcionId = 0;

            Inscripcion inscripcion; 

            try { //es Numero?

               inscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("Inscripción id debe se un numero entero > 0");
                InscripcionIdTextBox.Focus();
                validados = false;
            }

            try { //es Numero?

                decimal monto = Convert.ToInt32(InscripcionIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("Monto debe se un numero > 0");
                MontoPagarTextBox.Focus();
                validados = false;
            }

            //verificando si la inscripción existe
            inscripcion = InscripcionesBLL.Buscar(inscripcionId);

            if(inscripcion == null) {
                validados = false;
                MessageBox.Show("Este Inscripción id no existe");
                InscripcionIdTextBox.Focus();
            }

            return validados;
        }



        private void Limpiar() {
            InscripcionIdTextBox.Text = "";
            MontoPagarTextBox.Text = "";
        }
    }
}
