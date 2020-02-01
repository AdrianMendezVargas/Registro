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
    /// Interaction logic for ConsultaInscripciones.xaml
    /// </summary>
    public partial class ConsultaInscripciones : Window {
        public ConsultaInscripciones() {
            InitializeComponent();
        }

        private void ResultadosDataGrid_SelectionChanged(object sender , SelectionChangedEventArgs e) {

        }

        private void BuscarButton_Click(object sender , RoutedEventArgs e) {

            CargarResultados();

        }

        private void CargarResultados() {

            List<Inscripcion> listado = new List<Inscripcion>();

            if (CriterioTextBox.Text.Trim().Length > 0) {

                switch (FiltroComboBox.SelectedIndex) {

                    case 0://Todo
                        listado = InscripcionesBLL.GetList(i => true);
                        break;

                    case 1://InscripcionId
                        int inscripcionId;
                        int.TryParse(CriterioTextBox.Text , out inscripcionId);
                        listado = InscripcionesBLL.GetList(i => i.InscripcionId == inscripcionId);
                        break;

                    case 2://PersonaId
                        int PersonaId;
                        int.TryParse(CriterioTextBox.Text , out PersonaId);
                        listado = InscripcionesBLL.GetList(i => i.PersonaId == PersonaId);
                        break;

                    case 3://Monto
                        decimal monto;
                        decimal.TryParse(CriterioTextBox.Text , out monto);
                        listado = InscripcionesBLL.GetList(i => i.Monto == monto);
                        break;

                    case 4://Balance
                        decimal balance;
                        decimal.TryParse(CriterioTextBox.Text , out balance);
                        listado = InscripcionesBLL.GetList(i => i.Balance == balance);
                        break;

                    case 5://Comentario
                        listado = InscripcionesBLL.GetList(i => i.Comentario.Contains(CriterioTextBox.Text));
                        break;
                }

                if (!string.IsNullOrWhiteSpace(DesdeDatePicker.SelectedDate.ToString()) && !string.IsNullOrWhiteSpace(HastaDatePicker.SelectedDate.ToString())) {

                    listado = listado.Where(i => i.Fecha >= DesdeDatePicker.SelectedDate && i.Fecha <= HastaDatePicker.SelectedDate).ToList();
                }

            } else {

                listado = InscripcionesBLL.GetList(i => true);

                if (!string.IsNullOrWhiteSpace(DesdeDatePicker.SelectedDate.ToString()) && !string.IsNullOrWhiteSpace(HastaDatePicker.SelectedDate.ToString())) {

                    listado = listado.Where(i => i.Fecha >= DesdeDatePicker.SelectedDate && i.Fecha <= HastaDatePicker.SelectedDate).ToList();
                }

            }

            ResultadosDataGrid.ItemsSource = listado;

        }
    }
}
