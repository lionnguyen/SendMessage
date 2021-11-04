using System;
using System.Diagnostics;
namespace ASM2_SendMessage
{
    class Queue
    {
        public int max;
        public char[] Q;
        public int r;
        public int f;
        public Queue(int max, char[] Q)
        {
            r = 0;
            f = 0;
            this.max = max;
            this.Q = Q;
        }
        public int Enum()
        {
            if (r == f)
            {
                return 0;
            }
            else
                return (((max - f) + r) % max);
        }
        public bool isEmpty()
        {
            if (f == r)
            {
                Console.WriteLine("\tQueue is empty");
                return true;
            }
            else
                return false;
        }
        public void enQueue(char x)
        {
            Q[r] = x;
            r = (r + 1) % max;
        }
        public char deQueue()
        {
            char dQ = ' ';
            dQ = Q[f];
            f = (f + 1) % max;
            return dQ;
        }
    }
    class Stack
    {
        public int MAX;
        public int top;
        public char[] stack;
        public Stack()
        {
            top = -1;
            MAX = 250;
            stack = new char[MAX];
        }
        public void Push(char data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("\tStack Overflow");
            }
            else
            {
                top = top + 1;
                stack[top] = data;
            }
        }

        public char Pop()
        {
            char value = ' ';
            if (top < 0)
            {
                Console.WriteLine("\tStack Underflow");
                return value;
            }
            else
            {
                value = stack[top--];
                return value;
            }
        }
    }
    class SendMessage
    {
        public void SendMess(char[] input)
        {
            var queue = new char[250];
            var message2 = new char[250];
            Stack mystack = new Stack();
            Queue myqueue = new Queue(250, queue);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tNumber elements of string: {0}", input.Length);
            Console.ResetColor();
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    mystack.Push(input[i]);
                }
                for (int i = 0; i < input.Length; i++)
                {
                    myqueue.enQueue(mystack.Pop());
                }
                for (int i = input.Length; i > 0; i--)
                {
                    message2[i] = myqueue.deQueue();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\tYour input after transfer: ");
                Console.ResetColor();
                Console.Write(message2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SendMessage mysend = new SendMessage();
            Stopwatch st = new Stopwatch();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t========================================");
            Console.WriteLine("\tThe program transmits message via buffer");
            Console.WriteLine("\t========================================");
            Console.Write("\tEnter your characters (max 250) : ");
            Console.ResetColor();
            st.Start();
            string input = Console.ReadLine();
            if (input.Length >= 250)
            {
                string new_input = input.Substring(0, 250);
                char[] message1 = new_input.ToCharArray();
                mysend.SendMess(message1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tWe just send message with 250 characters.");
                Console.ResetColor();
            }
            else if (input.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tError! Array null...");
                Console.ResetColor();
            }
            else
            {
                char[] message1 = input.ToCharArray();
                mysend.SendMess(message1);
            }
            st.Stop();
            Console.WriteLine("                               ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t{0} giay", st.Elapsed.ToString());
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
