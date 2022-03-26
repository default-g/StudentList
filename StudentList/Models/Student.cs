using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      
        public Student(string name)
        {
            this.Name = name;
            this.ControlMarks = new ObservableCollection<ControlMark> { new ControlMark(0), new ControlMark(0), new ControlMark(0) };
        }

    }
}
