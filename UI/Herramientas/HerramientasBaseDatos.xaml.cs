using Microsoft.EntityFrameworkCore;
using Registro.DAL;
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

namespace Registro.UI.Herramientas {
    /// <summary>
    /// Interaction logic for HerramientasBaseDatos.xaml
    /// </summary>
    public partial class HerramientasBaseDatos : Window {
        public HerramientasBaseDatos() {
            InitializeComponent();
        }

        private void EliminarBaseDatos_Click(object sender , RoutedEventArgs e) {
            Contexto db = new Contexto();
            db.Personas.FromSqlRaw("Drop Table dbo.Personas");
            db.Inscripciones.FromSqlRaw("Drop Table dbo.Inscripciones");
            db.SaveChanges();
            db.Dispose();
        }
    }
}
