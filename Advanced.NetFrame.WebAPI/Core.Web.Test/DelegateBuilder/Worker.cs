using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Test.DelegateBuilder
{
    public class Worker
    {
        public delegate int AutoMachine(string str);

        public int SendCommand(AutoMachine load, string input) {
            return load.Invoke(input);
        }

        public int myTest(string str) => Convert.ToInt32(str);
        public void Test() {
            int ivalue =SendCommand(myTest, "2");
           

        }


    }


}
