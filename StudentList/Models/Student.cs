﻿using System;
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
    internal class Student
    {
        public string Name { set; get; }
        public ObservableCollection<ControlMark> ControlMarks { get; set; }

        public float? Average { get; private set; }
        public void CalculateAverage()
        {
            if (ControlMarks.Any(Mark => Mark.Mark == null))
                this.Average = null;
       
                float sum = 0;
                foreach (ControlMark mark in ControlMarks)
                {
                    sum += (float)mark.Mark;
                }
                this.Average =  sum / 3;
            RaisePropertyChangedEvent("Average");

        }

       
        private void OnSensorOnlineChanged(object sender, PropertyChangedEventArgs e)
        {
            CalculateAverage();
        }


        public Student(string name)
        {
            this.Name = name;
            this.ControlMarks = new ObservableCollection<ControlMark>();
            
            this.ControlMarks.CollectionChanged += MyItemsSource_CollectionChanged;
            ControlMarks.Add(new ControlMark(0));
            ControlMarks.Add(new ControlMark(0));
            ControlMarks.Add(new ControlMark(0));
            ControlMarks[0].Mark = 2;

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
