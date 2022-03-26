using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Models
{
    internal class Student: INotifyPropertyChanged
    {
        public string Name { set; get; }
        public ObservableCollection<ControlMark> ControlMarks { get; set; }
        float? average;
        Avalonia.Media.IBrush averageBrush;
        public Avalonia.Media.IBrush AverageBrush
        {
            get
            {
                return this.averageBrush;
            }
            private set
            {
                this.averageBrush = value;
                RaisePropertyChangedEvent("AverageBrush");
            }
        }

        public bool isChecked { get; set; }

        public float? Average
        {
            get
            {
                return this.average;
            }
            private set 
            {
                if (value is not null)
                {
                    if (value < 1.5)
                    {
                        this.AverageBrush = Brushes.Yellow;
                        this.average = value;
                    }
                    if (value < 1)
                    {
                        this.AverageBrush = Brushes.Red;
                        this.average = value;
                    }
                    if (value >= 1.5)
                    {
                        this.AverageBrush = Brushes.LightGreen;
                        this.average = value;
                    }
                }
                else
                {
                    this.average = null;
                    this.AverageBrush = Brushes.White;
                }
       
                RaisePropertyChangedEvent("Average");
            }
        }

        public void CalculateAverage()
        {
            if (ControlMarks.Any(mark => mark.Mark is null))
            {
                this.Average = null;
            }
            else
            { 
                float sum = 0;
                foreach (ControlMark mark in ControlMarks)
                {
                    sum += (float)mark.Mark;
                }
                this.Average =  sum / 3;
            }

        }


        public Student(string name)
        {
            this.Name = name;
            this.ControlMarks = new ObservableCollection<ControlMark>();
            this.ControlMarks.CollectionChanged += MyItemsSource_CollectionChanged;
            ControlMarks.Add(new ControlMark(0));
            ControlMarks.Add(new ControlMark(0));
            ControlMarks.Add(new ControlMark(0));
            this.isChecked = false;
            CalculateAverage();
        }

        void MyItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (ControlMark item in e.NewItems)
                    item.PropertyChanged += MyType_PropertyChanged;

            if (e.OldItems != null)
                foreach (ControlMark item in e.OldItems)
                    item.PropertyChanged -= MyType_PropertyChanged;
        }

        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculateAverage();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

    }
}
