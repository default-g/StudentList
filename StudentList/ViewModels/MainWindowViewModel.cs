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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

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
            this.Content = new MainViewModel();
        }

        public void WriteToBinaryFile(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Student>));
           
            using (StreamWriter wr = new StreamWriter(filePath))
            {
                xs.Serialize(wr, this.Items);
            }
        }

        public void ReadFromBinaryFile(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Student>));
            using (StreamReader sr = new StreamReader(filePath))
            {
                this.Items.Clear();
                try
                {
                    this.Items = (ObservableCollection<Student>)xs.Deserialize(sr);
                    foreach (Student s in this.Items)
                    {
                        var gradeList = new List<ControlMark>(3);
                        gradeList.Add(s.ControlMarks[3]);
                        gradeList.Add(s.ControlMarks[4]);
                        gradeList.Add(s.ControlMarks[5]);
                        s.ControlMarks.Clear();
                        foreach (ControlMark mark in gradeList)
                        {
                            s.ControlMarks.Add(mark);
                        }
                        s.CalculateAverage();
                    }
                } catch (Exception ex)
                {
                    
                }
            }
           
        }

        public void OpenFileView()
        {
            this.Content = new FileViewModel();
        }

        public void OpenMainView()
        {
            this.Content = new MainViewModel();
        }

    }
}
