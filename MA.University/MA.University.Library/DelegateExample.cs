using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Library
{
    public class DelegateExample
    {
        public delegate void MyDelegate(int a, int b);

        public static void Add(int a, int x)
        {
            Console.WriteLine(a + x);
        }

        public static void Subtract(int z, int x)
        {
            Console.WriteLine(z - x);
        }

        public void DoStuff()
        {
            MyDelegate myVerySpecialDelegate = Add;
            myVerySpecialDelegate += (a, b) => { Console.WriteLine(a + b); };
            myVerySpecialDelegate -= (a, b) => { Console.WriteLine(a + b); };

            //Action<int, int> myVerySpecialAction = null;

            //myVerySpecialAction = (int a, int b) => { Console.WriteLine(a + b); };

            //myVerySpecialAction = (a, b) => { Console.WriteLine(a + b); };

            myVerySpecialDelegate += Subtract;

            myVerySpecialDelegate -= Subtract;

            myVerySpecialDelegate(100, 34);
            //myVerySpecialAction(100, 34);
        }
    }
}
