using System;
using System.Collections.Generic;

class TextEditor
{
    static void Main()
    {
        Stack<string> actions = new Stack<string>();
        actions.Push("Type A");
        actions.Push("Type B");
        actions.Push("Delete C");
        actions.Push("Type D");

        Console.WriteLine("Undo last 3 actions:");
        for (int i = 0; i < 3; i++) Console.WriteLine("Undo: " + actions.Pop());

        Console.WriteLine("\nCurrent top action:");
        Console.WriteLine(actions.Peek());

        Stack<string> redo = new Stack<string>();
        redo.Push("Redo Delete C");
        Console.WriteLine("\nRedo stack:");
        foreach (var r in redo) Console.WriteLine(r);
    }
}
