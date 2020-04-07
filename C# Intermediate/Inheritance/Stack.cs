using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    public class Stack
    {
        private object[] _stack = new object[100];
        private int _top = -1;

        public void Push(Object obj)
        {
            _top++;
            _stack[_top] = obj;
        }

        public object Pop()
        {
            object obj;
            if(_top == -1)
                throw new InvalidOperationException("Stack in Underflow condition");

            obj = _stack[_top];
            _top--;

            return obj;
        }

        public void Show()
        {
            for (int i = 0; i <= _top; i++)
            {
                Console.WriteLine("Stack[{0}] = {1}",i,_stack[i]);
            } 
        }
        public void Clear()
        {
            Array.Clear(_stack, 0, _top + 1);
            _top = -1;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            int ch;
            
            
            do
            {
                Console.WriteLine("Stack Operation\n1. Push()\n2. Pop\n3. Show All()\n4. Clear()\n5. Exit()");
                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter object: ");
                        var input = Console.ReadLine();
                        
                        stack.Push(input);
                        break;
                    case 2:
                        var obj = stack.Pop();
                        Console.WriteLine("Poped Value: {0}",obj);
                        break;
                    case 4:
                        stack.Clear();
                        Console.WriteLine("Stack cleared");
                        break;
                    case 3:
                        stack.Show();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Enter valid input");
                        break;
                } 
	          
            }while(ch != 5);  
        }
    }
}
