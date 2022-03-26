using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudentList.Models
{
    internal class ControlMark
    {
        double mark;
        public Avalonia.Media.IBrush Brush { get; private set; }
        public double Mark
        {
            set
            {
                this.mark = value;
                switch(Mark)
                {
                    case 0:
                        this.Brush = Brushes.Red;
                        break;
                    default:
                        this.Brush = Brushes.Blue;
                        break;
                }
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
    }
}
