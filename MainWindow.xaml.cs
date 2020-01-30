﻿using Registro.BLL;
using Registro.Entidades;
using Registro.UI.Registros;
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

        private void PersonasMenuItem_Click(object sender , RoutedEventArgs e) {

            RegistroPersonas registroPersonas = new RegistroPersonas();
            registroPersonas.Owner = this;
            registroPersonas.ShowDialog();

        }
    }
}
