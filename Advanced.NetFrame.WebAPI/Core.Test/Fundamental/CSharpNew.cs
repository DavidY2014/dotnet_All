using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Test.Fundamental
{
    public class CSharpNew
    {
        public void NewFeature() {
            #region 空值运算符
            int? iValue = 10;
            //无需判断ivalue是否为空，防止抛出异常
            Console.WriteLine(iValue?.ToString());
            string name = null;
            Console.WriteLine(name?.ToString());
            #endregion

            #region 对象初始化器(Index Initializers)
            IDictionary<int, string> dicOld = new Dictionary<int, string>()
            {
                {1,"first"},
                { 2,"second"}
            };

            IDictionary<int, string> dicNew = new Dictionary<int, string>()
            {
                [4]="first",
                [5]="second"
            };


            #endregion

            #region 元组

            var result = GetValues();
            var a = result.Item1;
            var b = result.Item2;
            var c = result.Item3;
            var tupleResult = GetTupleValues();
            var name2 =tupleResult.name;
            var address = tupleResult.address;
            var age = tupleResult.age;

            #endregion
        }

        public (string, string, int) GetValues() {
            return ("a", "b", 1);
        }

        public (string name, string address, int age) GetTupleValues() 
        {
            return ("aa", "address", 10);
        }




    }
}
