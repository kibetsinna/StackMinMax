using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMinMax
{
 
    class Program
    {
        private static Stack<MinMaxNodeValue> stack;

        private static void Push(int intInput)
        {
            MinMaxNodeValue peekedNode = null;
            if (stack.Count == 0)
            {
                peekedNode = null;
            }
            else
            {
                peekedNode = stack.Peek();
            }
            int min = 0;
            int max = 0;
            if (peekedNode != null)
            {
                min = peekedNode.Minimum;
                max = peekedNode.Maximum;
                if (intInput < min)
                {
                    min = intInput;
                }
                if (intInput > max)
                {
                    max = intInput;
                }

            }
            else
            {
                min = intInput;
                max = intInput;
            }
            MinMaxNodeValue newNode = new MinMaxNodeValue();
            newNode.Value = intInput;
            newNode.Minimum = min;
            newNode.Maximum = max;
            stack.Push(newNode);
        }

        private static void PrintMinMax()
        {
            Console.WriteLine(string.Format("Max number {0}; Minimum number {1}", stack.Peek().Maximum, stack.Peek().Minimum));
        }
        private static void Main(string[] args)
        {
            stack = new Stack<MinMaxNodeValue>();

            string value = "";

            while (!value.Equals("Exit"))
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 for Push Number");
                Console.WriteLine("Enter 2 for Pop Number");
                Console.WriteLine("Enter 3 for Pint Min Max Number");
                Console.WriteLine("Enter 4 to Exit");
                Console.WriteLine();
                string input = Console.ReadLine();
                int intInput = -1;
                bool parseResult = Int32.TryParse(input, out intInput);
                if (parseResult)
                {
                    switch (intInput)
                    {
                        case 1:
                            input = Console.ReadLine();
                            parseResult = Int32.TryParse(input, out intInput);
                            if (parseResult)
                                Push(intInput);
                            else
                                Console.WriteLine("Not integer, try again");
                            break;
                        case 2:
                            stack.Pop();
                            break;
                        case 3:
                            PrintMinMax();
                            break;
                        case 4:
                            value = "Exit";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not integer, try again");
                }


            }
        }

    }
}
