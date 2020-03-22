using System;
using System.Collections.Generic;
using System.Text;
using Advanced.Framework;

namespace AdvancedNet.Models
{
    public class Student
    {
        public int Id { get; set; } //property


        [MyCustom]
        public string Name { get; set; }

        public int Age; //field

        [return: MyCustom]
        public string Study([MyCustom]string course)
        {
            return course + "课";
        }

        [MyCustom(1)]
        [MyCustom]
        public void Answer()
        {

        }


    }
}
