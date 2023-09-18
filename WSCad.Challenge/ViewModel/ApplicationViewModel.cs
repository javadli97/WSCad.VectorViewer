using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WSCad.Challenge.Model;
using WSCad.Challenge.Services.Abstractions;
using WSCad.Challenge.Services.Commands;

namespace WSCad.Challenge.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private readonly IFileService _fileService;
        private readonly IDialogService _dialogService;
        private readonly IDataReader<Shape> _dataReader;
        private ObservableCollection<Shape> _lines = new ObservableCollection<Shape>();
        private ObservableCollection<Circle> _cirles = new ObservableCollection<Circle>();

        public ObservableCollection<Shape> Lines
        {
            get => _lines;
            set
            {
                _lines = value;
                OnPropertyChanged(nameof(Lines));
            }
        }

        public ObservableCollection<Circle> Circles
        {
            get => _cirles;
            set
            {
                _cirles = value;
                OnPropertyChanged(nameof(Circles));
            }
        }


        public ApplicationViewModel(IDialogService dialogService, IFileService fileService, IDataReader<Shape> dataReader)
        {
            _dialogService = dialogService;
            _fileService = fileService;
            _dataReader = dataReader;
        }

        private RelayCommand _importCommand;

        public RelayCommand ImportCommand
        {
            get
            {
                return _importCommand ??
                    (_importCommand = new RelayCommand(obj =>
                    {

                        try
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

                            if (openFileDialog.ShowDialog() == true)
                            {
                                var json = File.ReadAllText(openFileDialog.FileName);
                                List<Shape> items = _dataReader.Deserialize(json);
                                foreach (var item in items)
                                {
                                    if (item is Line)
                                    {
                                        Lines.Add(item);
                                    }

                                    if (item is Triangle)
                                    {
                                        var triangle = item as Triangle;
                                        Lines.Add(new Line(triangle.A, triangle.B));
                                        Lines.Add(new Line(triangle.B, triangle.C));
                                        Lines.Add(new Line(triangle.A, triangle.C));
                                    }

                                    if (item is Circle)
                                    {
                                        var circle = item as Circle;
                                        Circles.Add(new Circle(circle.Center, circle.Radius, circle.Filled));
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            _dialogService.ShowMessage(ex.Message);
                        }

                    }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
