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
    /// Interaction logic for RegistroPersonas.xaml
    /// </summary>
    public partial class RegistroPersonas : Window {
        public RegistroPersonas() {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender , RoutedEventArgs e) {

            Limpiar();

        }

        private void btnGuardar_Click(object sender , RoutedEventArgs e) {

            Persona persona;
            bool guardado = true;

            if (!CamposValidos()) {
                return;
            }

            persona = LlenaClasePersona();

            if (tbID.Text == "0") {

                guardado = PersonasBLL.Guardar(persona);

            } else {

                if (!ExisteEnLaBaseDatos()) {
                    MessageBox.Show("Este ID no se puede modificar porque no existe");
                    tbID.Focus();
                    return;
                }
                guardado = PersonasBLL.Modificar(persona);

            }

            if (guardado) {
                MessageBox.Show("Guardado :)" , "EXITO" , MessageBoxButton.OK , MessageBoxImage.Exclamation);
            } else {
                MessageBox.Show("No se ah Guardado :(" , "ERROR" , MessageBoxButton.OK , MessageBoxImage.Error);
            }






        }

        private void btnEliminar_Click(object sender , RoutedEventArgs e) {

            int id = 0;
            Persona persona = new Persona();

            try {

                id = Convert.ToInt32(tbID.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero");
                tbID.Focus();
                return;

            }

            persona = PersonasBLL.Buscar(id);

            if (persona != null) {
                PersonasBLL.Eliminar(id);
                MessageBox.Show("Persona Eliminada");
            } else {
                MessageBox.Show("Esta Persona no existe");
            }


        }

        private void btnBuscar_Click(object sender , RoutedEventArgs e) {

            int id = 0;
            Persona persona = new Persona();

            try {

                id = Convert.ToInt32(tbID.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero");
                tbID.Focus();

            }

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null) {

                LlenaCamposInterfaz(persona);
                MessageBox.Show("Encontrada!");
            } else {
                MessageBox.Show("No encontrada");
            }

        }

        private void Limpiar() {

            tbID.Text = "";
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbCedula.Text = "";
            tbDireccion.Text = "";
            dpFechaNacimiento.SelectedDate = DateTime.Parse("01/01/1999");

        }

        private Persona LlenaClasePersona() {

            Persona persona = new Persona();

            persona.PersonaID = Convert.ToInt32(tbID.Text);
            persona.Nombre = tbNombre.Text;
            persona.Cedula = tbCedula.Text;
            persona.Telefono = tbTelefono.Text;
            persona.Direccion = tbDireccion.Text;
            persona.FechaNacimiento = (DateTime) dpFechaNacimiento.SelectedDate;

            return persona;
        }

        private void LlenaCamposInterfaz(Persona persona) {

            tbID.Text = persona.PersonaID.ToString();
            tbNombre.Text = persona.Nombre;
            tbCedula.Text = persona.Cedula;
            tbTelefono.Text = persona.Telefono;
            tbDireccion.Text = persona.Direccion;
            dpFechaNacimiento.SelectedDate = persona.FechaNacimiento;

        }

        private bool CamposValidos() {

            bool validados = true;

            int id;

            try {

                id = Convert.ToInt32(tbID.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero");
                tbID.Focus();
                validados = false;

            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text)) {
                MessageBox.Show("El Nombre no puede estar vacio");
                tbNombre.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbCedula.Text)) {
                MessageBox.Show("La cedula no puede estar vacia");
                tbCedula.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbTelefono.Text)) {
                MessageBox.Show("El Telefono no puede estar vacio");
                tbTelefono.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbDireccion.Text)) {
                MessageBox.Show("La direccion no puede estar vacia");
                tbDireccion.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(dpFechaNacimiento.SelectedDate.ToString())) {
                MessageBox.Show("Seleccione una Fecha de Nacimiento");
                dpFechaNacimiento.Focus();
                validados = false;
            }

            return validados;
        }

        private bool ExisteEnLaBaseDatos() {

            Persona persona = PersonasBLL.Buscar(Convert.ToInt32(tbID.Text));
            return (persona != null);

        }
    }
}
