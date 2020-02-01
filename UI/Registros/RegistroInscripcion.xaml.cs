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
    /// Interaction logic for RegistroInscripcion.xaml
    /// </summary>
    public partial class RegistroInscripcion : Window {
        public RegistroInscripcion() {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender , RoutedEventArgs e) {

            Limpiar();
        }

        private void btnGuardar_Click(object sender , RoutedEventArgs e) {

            if (!Validar()) {
                return;
            }

            Inscripcion inscripcion;
            bool guardado = false;

            inscripcion = LlenaClase();

            if (InscripcionIdTextBox.Text == "0" || string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text)) {

                guardado = InscripcionesBLL.Guardar(inscripcion);

            } else {

                if (!ExisteEnBaseDatos()) {

                    MessageBox.Show("Esta Inscripción no existe; No se puede Modificar");
                    InscripcionIdTextBox.Focus();
                    return;
                } else {

                    guardado = InscripcionesBLL.Modificar(inscripcion);
                }

            }

            if (guardado) {
                MessageBox.Show("Guardado :)" , "EXITO" , MessageBoxButton.OK , MessageBoxImage.Exclamation);
            } else {
                MessageBox.Show("No se ah Guardado :(" , "ERROR" , MessageBoxButton.OK , MessageBoxImage.Error);
            }


        }

        

        private void btnEliminar_Click(object sender , RoutedEventArgs e) {

        }

        private void btnBuscar_Click(object sender , RoutedEventArgs e) {

        }

        private void Limpiar() {

            InscripcionIdTextBox.Text = "";
            PersonaIdTextBox.Text = "";
            MontoTextBox.Text = "";
            BalanceTextBox.Text = "";
            ComentarioTextBox.Text = "";
            FechaInscripcionDatepicker.SelectedDate = DateTime.Now;

        }

        private bool Validar() {

            bool validados = true;

            int id;
            decimal monto;

            try {   //InscripcionId
                id = Convert.ToInt32(InscripcionIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero entero. \nIngrese el numero \"0\" para crear una Inscripción nueva.");
                InscripcionIdTextBox.Focus();
                validados = false;
            }

            try {    //PersonaId
                id = Convert.ToInt32(PersonaIdTextBox.Text);

                if (id <= 0) {
                    MessageBox.Show("El Campo \"PersonaId\" debe ser un numero entero > 0");
                    PersonaIdTextBox.Focus();
                    validados = false;
                }

            } catch (Exception) {

                MessageBox.Show("El Campo \"Persona Id\" debe ser un numero entero > 0");
                PersonaIdTextBox.Focus();
                validados = false;
            }

            try {    //Monto
                monto = Convert.ToDecimal(MontoTextBox.Text);

                if (monto <= 0.0m) {
                    MessageBox.Show("El Monto no puede estar vacio");
                    MontoTextBox.Focus();
                    validados = false;
                }

            } catch (Exception) {

                MessageBox.Show("El Monto debe ser un numero > 0");
                MontoTextBox.Focus();
                validados = false;
            }

            //
            if (string.IsNullOrWhiteSpace(FechaInscripcionDatepicker.Text)) {
                MessageBox.Show("Por favor seleccione una fecha");
                FechaInscripcionDatepicker.Focus();
                validados = false;
            }


            return validados;
        }

        private Inscripcion LlenaClase() {

            Inscripcion inscripcion = new Inscripcion();

            inscripcion.InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
            inscripcion.PersonaId = Convert.ToInt32(PersonaIdTextBox.Text);
            inscripcion.Monto = Convert.ToDecimal(MontoTextBox.Text);
            inscripcion.Comentario = ComentarioTextBox.Text;
            inscripcion.Fecha = (DateTime)FechaInscripcionDatepicker.SelectedDate;

            return inscripcion;
        }
        
        private bool ExisteEnBaseDatos() {
            Inscripcion inscripcion = InscripcionesBLL.Buscar(Convert.ToInt32(InscripcionIdTextBox.Text));
            return (inscripcion != null);
        }

    }
}
