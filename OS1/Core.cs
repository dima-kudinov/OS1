using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS1
{
    public class Core
    {
        MyStack<string> stack;
        public Dictionary<int, SystemCall> SystemCalls;

        public Core(MyStack<string> stack)
        {
            this.stack = stack;
            SystemCalls = new Dictionary<int, SystemCall>();
            SystemCalls[0] = new SystemCall(new List<string> { "arg" });
            SystemCalls[1] = new SystemCall(new List<string> { "arg", "arg" });
            SystemCalls[2] = new SystemCall(new List<string> { "arg2" });
            SystemCalls[3] = new SystemCall(
                new List<string> { "arg", "arg2", "arg", "arg" });
            SystemCalls[4] = new SystemCall(
                new List<string> { "arg", "arg", "arg", "arg", "arg" });
        }
        

        public void ExecuteCall(int id)
        {
            int countA = 0;
            Console.WriteLine("Пытаюсь вызвать системный вызов № " + id );

            if (!SystemCalls.ContainsKey(id))
            {
                Console.WriteLine("Вызов номер " + id + " не существует");
                return;
            }

            // List<string> args = SystemCalls[id].Arguments;  

            // MyStack<string> tmp = new MyStack<string>(); 

            //int stackSize = 0;

            //while (true)
            //{
            //    try
            //    {
            //        tmp.Push(stack.Pop());
            //        stackSize++;
            //    }
            //    catch (Exception ex)
            //    {
            //        break;
            //    }
            //}

            //if (stackSize != args.Count())
            //{
            //    Console.WriteLine("Аргументы не совпадают по количеству");
            //    return;
            //}
            

            for (int i = SystemCalls[id].Arguments.Count() - 1; i >= 0; i--)
            {
                var arg = stack.Pop();
                if (arg == null)
                {
                    Console.WriteLine("Агрументов введено меньше, ожидалось " + SystemCalls[id].Arguments.Count() + ", получено " + countA);
                    countA = 0;
                    return;

                }
                else
                {
                    countA++;
                    if (!SystemCalls[id].Arguments[i].Equals(arg))
                    {
                        Console.WriteLine("Агрументы не совпадают по значению, ожидалось " + SystemCalls[id].Arguments[i] + ", а пришло " + arg);
                        countA = 0;
                        return;
                    }
                    

                }

            }

            if (stack.Pop() != null)
            {
                countA++;
                while (stack.Pop() != null)
                    countA++;

                Console.WriteLine("Агрументов введено больше, ожидалось " + SystemCalls[id].Arguments.Count() + ", получено " + countA);
                countA = 0;
                return;
            }
            countA = 0;
            Console.WriteLine(SystemCalls[id].Execute());
            while (stack.Pop() != null)
            {
                stack.Pop();
            }          
        }

        public void Calls()
        {
            foreach (var sc in SystemCalls)
            {
                Console.WriteLine(sc.Key + " " + String.Join(" ", sc.Value.Arguments));
            }
        }
    }
}
