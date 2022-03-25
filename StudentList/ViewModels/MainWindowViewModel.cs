using ReactiveUI;
using StudentList.Views;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace StudentList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
        public MainWindowViewModel()
        {
            this.Content = new MainViewModel();
        }
        // ReactiveCommand<Unit, Unit> ShowAbout { get; }
    }
}
