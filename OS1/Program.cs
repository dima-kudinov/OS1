using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<string>();          
            Core core = new Core(stack);
           
            

            // while (true)
            //{


            // string line = lis[l];//Console.ReadLine();



            stack.Push("arg");
            core.ExecuteCall(0);

            stack.Push("arg");
            stack.Push("arg");
            stack.Push("arg");
            core.ExecuteCall(0);

            stack.Push("arm");
            core.ExecuteCall(0);

            core.ExecuteCall(0);



            Console.ReadLine();
        }
    }
}


   
