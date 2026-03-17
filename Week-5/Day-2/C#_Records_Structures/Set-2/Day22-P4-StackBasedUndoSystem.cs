using System;

class StackUndo
{
    string[] stack;
    int top = -1;
    int size;

    public StackUndo(int size)
    {
        this.size = size;
        stack = new string[size];
    }

    public void Push(string action)
    {
        if (top == size - 1)
        {
            Console.WriteLine("Stack Overflow - Cannot add more actions.");
            return;
        }

        top++;
        stack[top] = action;
        Console.WriteLine(action + " added.");
        Display();
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow - Nothing to undo.");
            return;
        }

        Console.WriteLine("Undo: " + stack[top]);
        top--;
        Display();
    }

    public void Display()
    {
        if (top == -1)
        {
            Console.WriteLine("Current State: Empty");
            return;
        }

        Console.WriteLine("Current State:");
        for (int i = 0; i <= top; i++)
        {
            Console.WriteLine(stack[i]);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        StackUndo editor = new StackUndo(10);

        editor.Push("Type A");
        editor.Push("Type B");
        editor.Push("Type C");

        editor.Pop(); 
        editor.Pop(); 
    }
}