using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace WpfApp3
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        Employees selectedEmployees;

        IFileService fileService;
        IDialogService dialogService;

        public ObservableCollection<Employees> Employees { get; set; }

        private RelayCommand saveXmlCommand;
        public RelayCommand SaveXmlCommand
        {
            get
            {
                return saveXmlCommand ??
                  (saveXmlCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                              fileService.Save(dialogService.FilePath, Employees.ToList());
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }

        }

        private RelayCommand loadXmlCommand;
        public RelayCommand LoadXmlCommand
        {
            get
            {
                return loadXmlCommand ??
                  (loadXmlCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var emp = fileService.Open(dialogService.FilePath);
                              Employees.Clear();
                              foreach (var e in emp)
                                  Employees.Add(e);
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Employees emp = new Employees();
                      Employees.Insert(0, emp);
                      SelectedEmployees = emp;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Employees emp = obj as Employees;
                      if (emp != null)
                          Employees.Remove(emp);
                  },
                 (obj) => Employees.Count > 0));
            }
        }

        public Employees SelectedEmployees
        {
            get { return selectedEmployees; }
            set
            {
                selectedEmployees = value;
                OnPropertyChanged("SelectedEmployees");
            }
        }

        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            Employees = new ObservableCollection<Employees>
            {

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}