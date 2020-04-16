using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS1
{
    public class MyStack<T>
    {
        private Stack<T> stack;

        public MyStack()
        {
            stack = new Stack<T>();
        }
       
        public void Push(T arg)
        {
            stack.Push(arg);
            
        }

        public T Pop()
        {
            if (stack.Count() > 0)
            {
                return stack.Pop();
                
            }
            else
            {
                return default;
            }
        }
    }
}
