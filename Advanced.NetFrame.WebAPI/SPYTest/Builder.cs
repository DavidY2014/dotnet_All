using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPYTest
{
    public class Builder
    {
        //静态函数，创建的多个实例对象只保存一份函数内存
        public static void Test()
        {
            object objVal = 4;
            int value = (int)objVal;

			//// 0x025C: 00
			//IL_0000: nop
			//// 0x025D: 1A
			//IL_0001: ldc.i4.4
			//// 0x025E: 8C 11 00 00 01
			//IL_0002: box[mscorlib]System.Int32 //装箱
			//// 0x0263: 0A
			//  IL_0007: stloc.0
			//// 0x0264: 06
			//IL_0008: ldloc.0
			//// 0x0265: A5 11 00 00 01
			//IL_0009: unbox.any[mscorlib]System.Int32 //拆箱
			//// 0x026A: 0B
			//IL_000e: stloc.1
			//// 0x026B: 2A
			//IL_000f: ret
		}
	}
}
