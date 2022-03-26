using ReactiveUI;
using StudentList.Views;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using StudentList.Models;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Linq;

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

        public void AddNewStudent()
        {
            Items.Insert(0, new Student("NEW STUDENT"));
        }

        public void RemoveCheckedStudents()
        {
            var neededStudents = this.Items.Where(x => ! x.isChecked).ToList();
            this.Items.Clear();
            foreach (var neededStudent in neededStudents)
            {
                this.Items.Add(neededStudent);
            }
            
        }

        public MainWindowViewModel()
        {
            this.Items = new ObservableCollection<Student>();
            Items.Add(new Student("������ ���� AKA �����"));
            Items.Add(new Student("�������� �����"));
            Items.Add(new Student("������� ��������"));
            Items.Add(new Student("����� ���������"));
            Items.Add(new Student("���������� ����"));
            this.Content = new MainViewModel();
        }
        
        
    }
}
