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

            int personaId;

            int.TryParse(PersonaIdTextBox.Text , out personaId); 

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

                MessageBox.Show("Guardado." , "EXITO" , MessageBoxButton.OK , MessageBoxImage.Exclamation);
            } else {
                MessageBox.Show("Error al guardar" , "ERROR" , MessageBoxButton.OK , MessageBoxImage.Error);
            }


        }

        

        private void btnEliminar_Click(object sender , RoutedEventArgs e) {

            int InscripcionId;
            Inscripcion inscripcion;

            try {

                InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("El campo \"Inscripción Id\" debe ser un numero entero ");
                InscripcionIdTextBox.Focus();
                return;
            }

            inscripcion = InscripcionesBLL.Buscar(InscripcionId);

            if (inscripcion != null) {
                InscripcionesBLL.Eliminar(InscripcionId);
                MessageBox.Show("Inscripción eliminada.");
            } else {
                MessageBox.Show("Esta inscripción no existe");
            }

        }

        private void btnBuscar_Click(object sender , RoutedEventArgs e) {

            int InscripcionId;
            
            Inscripcion inscripcion;

            try {

                InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
               

            } catch (Exception) {

                MessageBox.Show("El campo \"Inscripción Id\" debe un ser numero entero.");
                InscripcionIdTextBox.Focus();
                return;
            }

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(InscripcionId);

            if (inscripcion != null) {
                LlenaCampo(inscripcion);
                MessageBox.Show("Inscripción encontrada.");
            } else {
                MessageBox.Show("Inscripción no encontrada.");
            }

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

            Persona persona = new Persona();

            int InscripcionId;
            int PersonaId;

            decimal monto;

            try {   //InscripcionId

                InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero entero. \nIngrese el numero \"0\" para crear una Inscripción nueva.");
                InscripcionIdTextBox.Focus();
                validados = false;
            }

            try {    //PersonaId
                
                PersonaId = Convert.ToInt32(PersonaIdTextBox.Text);

                if (PersonaId <= 0) {
                    MessageBox.Show("El Campo \"PersonaId\" debe ser un numero entero > 0");
                    PersonaIdTextBox.Focus();
                    validados = false;
                }

                persona = PersonasBLL.Buscar(PersonaId);

                if (persona == null) {
                    MessageBox.Show("Esta Persona no existe.\nIntroduzca otra Persona Id.");
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
                    MessageBox.Show("El Monto no puede estar vacío");
                    MontoTextBox.Focus();
                    validados = false;
                }

            } catch (Exception) {

                MessageBox.Show("El Monto debe ser un numero > 0");
                MontoTextBox.Focus();
                validados = false;
            }

            //Fecha
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
            inscripcion.Balance = inscripcion.Monto;

            return inscripcion;
        }
        
        private bool ExisteEnBaseDatos() {
            Inscripcion inscripcion = InscripcionesBLL.Buscar(Convert.ToInt32(InscripcionIdTextBox.Text));
            return (inscripcion != null);
        }

        private void LlenaCampo(Inscripcion inscripcion) {

            InscripcionIdTextBox.Text = inscripcion.InscripcionId.ToString();
            PersonaIdTextBox.Text = inscripcion.PersonaId.ToString();
            MontoTextBox.Text = inscripcion.Monto.ToString();
            BalanceTextBox.Text = inscripcion.Balance.ToString();
            FechaInscripcionDatepicker.SelectedDate = inscripcion.Fecha.Date;
            ComentarioTextBox.Text = inscripcion.Comentario;

        }

    }
}
