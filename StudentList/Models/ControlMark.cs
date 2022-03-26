using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace StudentList.Models
{
    internal class ControlMark : INotifyPropertyChanged
    {
        float? mark;
        public Avalonia.Media.IBrush Brush { get; private set; }
        public float? Mark
        {
            set
            {
                switch (value)
                {
                    case 0:
                        this.Brush = Brushes.Red;
                        this.mark = value;
                        break;
                    case 1:
                        this.Brush = Brushes.Yellow;
                        this.mark = value;
                        break;
                    case 2:
                        this.Brush = Brushes.LightGreen;
                        this.mark = value;
                        break;
                    default:
                        this.Brush = Brushes.White;
                        this.mark = null;
                        break;
                }
                RaisePropertyChangedEvent("Mark");

            }
            get
            {
                return this.mark;
            }
        }
        public ControlMark(float mark)
        {
            this.Mark = mark;
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
