﻿using Registro.BLL;
using Registro.Entidades;
using System;
using System.Windows;

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
            bool guardado = false;

            if (!Validar()) {
                return;
            }

            persona = LlenaClase();

            if (tbID.Text == "0" || string.IsNullOrWhiteSpace(tbID.Text)) {

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

                MessageBoxResult messageBoxResult = MessageBox.Show("Desea eliminar esta persona?" , "Atención" , MessageBoxButton.YesNo , MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes) {
                    PersonasBLL.Eliminar(id);
                    MessageBox.Show("Persona Eliminada.");
                }

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

                LlenaCampos(persona);
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
            tbBalance.Text = "";
            dpFechaNacimiento.SelectedDate = DateTime.Parse("01/01/1999");

        }

        private Persona LlenaClase() {

            Persona persona = new Persona();

            persona.PersonaID = Convert.ToInt32(tbID.Text);
            persona.Nombre = tbNombre.Text;
            persona.Cedula = tbCedula.Text;
            persona.Telefono = tbTelefono.Text;
            persona.Direccion = tbDireccion.Text;
            persona.FechaNacimiento = (DateTime) dpFechaNacimiento.SelectedDate;

            return persona;
        }

        private void LlenaCampos(Persona persona) {

            tbID.Text = persona.PersonaID.ToString();
            tbNombre.Text = persona.Nombre;
            tbCedula.Text = persona.Cedula;
            tbTelefono.Text = persona.Telefono;
            tbDireccion.Text = persona.Direccion;
            tbBalance.Text = persona.Balance.ToString();
            dpFechaNacimiento.SelectedDate = persona.FechaNacimiento;

        }

        private bool Validar() {

            bool validados = true;

            int id;

            try {

                id = Convert.ToInt32(tbID.Text);

            } catch (Exception) {

                MessageBox.Show("El ID debe ser un numero. \nIngrese el numero \"0\" para crear una persona nueva");
                tbID.Focus();
                validados = false;

            }

            if (string.IsNullOrWhiteSpace(tbNombre.Text)) {
                MessageBox.Show("El Nombre no puede estar vacío");
                tbNombre.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbCedula.Text)) {
                MessageBox.Show("La cédula no puede estar vacía");
                tbCedula.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbTelefono.Text)) {
                MessageBox.Show("El Teléfono no puede estar vacía");
                tbTelefono.Focus();
                validados = false;
            }
            if (string.IsNullOrWhiteSpace(tbDireccion.Text)) {
                MessageBox.Show("La dirección no puede estar vacía");
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
