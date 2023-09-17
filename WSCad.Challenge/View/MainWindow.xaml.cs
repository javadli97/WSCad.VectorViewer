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
        private readonly IDataReader<Shape> _dataReader;
        public MainWindow()
        {
            InitializeComponent();
            _dataReader = new JsonDataReader<Shape>();
            DataContext = new ApplicationViewModel(new DefaultDialogService(), new JsonFileService());
        }

        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(openFileDialog.FileName);
                List<Shape> items = _dataReader.Deserialize(json);
            }
        }
    }
}
