using System;
using System.Collections.Generic;

namespace sprint3;
{
    public static class Stacks
    {
        public static void Run()
        {
            //set up game and explain rules
            Console.WriteLine("Welcome to the stacks of Hanoi game!")
            Console.WriteLine()
            Console.WriteLine("The goal is to move all 3 blocks from stack 1 to stack 3 in the least amount of moves.")
            Console.WriteLine("The stacks behave like the datastructure 'stack' where you can pop and push blocks from stacks.")
            Console.WriteLine("The only rule is you cannot push a large block onto a samller block.")
            Console.WriteLine()
            Console.WriteLine("Good Luck!")
            Console.WriteLine()

            var stack1 = new Stack<int>(new[] { 3, 2, 1 });//set up stack 1 with all 3 blocks
            var stack2 = new Stack<int>();//create stack 2
            var stack3 = new Stack<int>();//create stack 3
            int count = 0;//set up a counter for the number of moves
            var keepGoing = true;//set the game to continue after every move until the player has won

            while (keepGoing)//loop until player wins
            {
                Console.Clear();//clear console
                DrawStacks(stack1, stack2, stack3);//draw each stack with their blocks
                DrawMenu();//display menu options for user

                var consoleKeyInfo = Console.ReadKey(true);
                var command = consoleKeyInfo.KeyChar;

                if (command == 'm')
                {
                    DrawMove(); 
                    MoveBlock(from, to); //setting up var to hold stack user wants to move from and to or set up the stack pop/push here?
                }
            }
        }
        private static void MoveBlock(Stack<int> source, Stack<int> destination)
        {
            if (source.Count > 0 && (destination.Count == 0 || source.Peek() < destination.Peek()))
            {
                destination.Push(source.Pop());
            }
        }

        private static void DrawStacks(Stack<int> stack1, Stack<int> stack2, Stack<int> stack3)
        {
            //calls the DrawStack function for each stack
            DrawStack(stack1);
            DrawStack(stack2);
            DrawStack(stack3);
        }

        private static void DrawStack(Stack<int> stack)
        {
            //draw individual stack
            foreach (int item in stack)//iterate through each "block" in the stack
            {
                DrawBlock(item);//call the DrawBlock function for each block
            }
            Console.WriteLine(); // Separate Stacks
        }

        private static void DrawBlock(int block)
        {
            //drawblocks
            string block = new string('=', item);//each block will be represented by "=". The more "=" the bigger the block
            Console.WriteLine(block.PadLeft(5 + item).PadRight(9));
        }

        private static void DrawMenu()
        {
            DrawString("m: Move Block");
            //add further for moving using from and to var to call which stacks to move from. Make a class for Menu and call it here.
            Console.SetCursorPosition(0, 15);
        }
        private static void DrawMove()//*see comment in DrawMenu method
        {
            Console.WriteLine("stack you want to move from: ");
            var from = Console.ReadLine();
            Console.WriteLine("stack you want to move to: ");
            var to = Console.ReadLine();
        }
        private static void DrawString(string str)
        {
            Console.WriteLine(str);
        }
    }
}
