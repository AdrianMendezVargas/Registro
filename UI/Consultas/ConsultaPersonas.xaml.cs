using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.UI.Consultas {
    /// <summary>
    /// Interaction logic for ConsultaPersonas.xaml
    /// </summary>
    public partial class ConsultaPersonas : Window {
        public ConsultaPersonas() {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {

            CargarResultados();
        }

        private void CargarResultados() {

            var listado = new List<Persona>();

            if (CriterioTextBox.Text.Trim().Length > 0) {

                switch (FiltroComboBox.SelectedIndex) {

                    case 0://Todo
                        listado = PersonasBLL.GetList(p => true);
                        break;

                    case 1://ID
                        int id;
                        int.TryParse(CriterioTextBox.Text , out id);
                        listado = PersonasBLL.GetList(p => p.PersonaID == id);
                        break;

                    case 2://Nombre
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 3://Cédula
                        listado = PersonasBLL.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 4://Dirección
                        listado = PersonasBLL.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }

                if (!string.IsNullOrWhiteSpace(DesdeDatePicker.SelectedDate.ToString()) && !string.IsNullOrWhiteSpace(HastaDatePicker.SelectedDate.ToString()) ) {

                    listado = listado.Where(p => p.FechaNacimiento >= DesdeDatePicker.SelectedDate && p.FechaNacimiento <= HastaDatePicker.SelectedDate).ToList();
                }

            } else {

                listado = PersonasBLL.GetList(p => true);

                if (!string.IsNullOrWhiteSpace(DesdeDatePicker.SelectedDate.ToString()) && !string.IsNullOrWhiteSpace(HastaDatePicker.SelectedDate.ToString())) {

                    listado = listado.Where(p => p.FechaNacimiento >= DesdeDatePicker.SelectedDate && p.FechaNacimiento <= HastaDatePicker.SelectedDate).ToList();
                }

                
            }

            ResultadosDataGrid.ItemsSource = listado;
            //ResultadosDataGrid.ItemsSource = null;
        }

        private void ResultadosDataGrid_SelectionChanged(object sender , SelectionChangedEventArgs e) {

        }
    }
}
