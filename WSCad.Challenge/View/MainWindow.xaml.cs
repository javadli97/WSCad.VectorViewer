using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WSCad.Challenge.Services;
using WSCad.Challenge.Services.Abstractions;
using WSCad.Challenge.ViewModel;
using Shape = WSCad.Challenge.Model.Shape;

namespace WSCad.Challenge.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new JsonFileService(), new JsonDataReader<Shape>());
        }
    }
}
