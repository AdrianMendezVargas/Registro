using Registro.UI.Consultas;
using Registro.UI.Herramientas;
using Registro.UI.Registros;
using System.Windows;

namespace Registro {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RegistroPersonasMenuItem_Click(object sender , RoutedEventArgs e) {

            RegistroPersonas registroPersonas = new RegistroPersonas();
            registroPersonas.Owner = this;
            registroPersonas.ShowDialog();

        }

        private void ConsultaPersonasMenuItem_Click(object sender , RoutedEventArgs e) {
            ConsultaPersonas consultaPersonas = new ConsultaPersonas();
            consultaPersonas.Owner = this;
            consultaPersonas.ShowDialog();
        }

        private void RegistroInscripcionMenuItem_Click(object sender , RoutedEventArgs e) {

            RegistroInscripcion registroInscripcion = new RegistroInscripcion();
            registroInscripcion.Owner = this;
            registroInscripcion.ShowDialog();

        }

        private void ConsultaInscripcionesMenuItem_Click(object sender , RoutedEventArgs e) {

            ConsultaInscripciones consultaInscripciones = new ConsultaInscripciones();
            consultaInscripciones.Owner = this;
            consultaInscripciones.ShowDialog();

        }

        private void ReistroPagoMenuItem_Click(object sender , RoutedEventArgs e) {

            RegistroPago registroPago = new RegistroPago();
            registroPago.Owner = this;
            registroPago.ShowDialog();

        }

        private void HerramientasBaseDatosMenuItem_Click(object sender , RoutedEventArgs e) {
            HerramientasBaseDatos herramientasBaseDatos = new HerramientasBaseDatos();
            herramientasBaseDatos.Owner = this;
            herramientasBaseDatos.ShowDialog();
        }
    }
}
