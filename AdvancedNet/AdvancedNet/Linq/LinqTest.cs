using System;
using System.Collections.Generic;
using System.Text;
using AdvancedNet.Models;

namespace AdvancedNet.Linq
{
    public class LinqTest
    {
        private List<Student> GetStudentList()
        {
            var list = new List<Student>();
            list.Add(new Student() { });
            return list;
        }

        public void MyLinqTest()
        {
            var list = new List<Student>();
            var filterList = list.MyWhere(item => item.Name == "dadsa");


        }

    }
}
