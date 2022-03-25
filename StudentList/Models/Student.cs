using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList.Models
{
    internal class Student
    {
        public string Name { private set; get; }
        public int[] ControlMarks = new int[3] { 0, 0, 0 };
        public float CalculateAverage()
        {
            float sum = 0;
            foreach (var controlMark in ControlMarks)
            {
                sum += controlMark;
            }
            return sum / 3;
        }
        public Student(string name)
        {
            this.Name = name;
        }
    }
}
