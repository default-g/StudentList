using ReactiveUI;
using StudentList.Views;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using StudentList.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace StudentList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase content;
        ObservableCollection<Student> Items { get; set; }
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainWindowViewModel()
        {
            this.Items = new ObservableCollection<Student>();
            Items.Add(new Student("Обухов Артём"));
            Items.Add(new Student("АВА"));
            this.Content = new MainViewModel();
        }
        
        
    }
}
