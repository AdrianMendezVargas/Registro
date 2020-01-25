using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender , RoutedEventArgs e) {

            Limpiar();

        }

        private void btnGuardar_Click(object sender , RoutedEventArgs e) {
            


        }

        private void btnEliminar_Click(object sender , RoutedEventArgs e) {

        }

        private void btnBuscar_Click(object sender , RoutedEventArgs e) {

        }

        private void Limpiar() {
            tbID.Text = "";
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbCedula.Text = "";
            tbDireccion.Text = "";
            tbFechaNacimiento.Text = "";
        }

        private Persona LlenaClasePersona() {

            Persona persona = new Persona();

            persona.PersonaID = Convert.ToInt32(tbID.Text);

            return persona;
        }

    }
}
