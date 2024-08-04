using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour // class which calls commands
{
    private static List<ICommand> _commands = new List<ICommand>();
    public static bool isExecuting;

    public static void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public static void ExecuteCommand()
    {
        if (_commands.Count != 0 && !isExecuting)
        {
            ICommand command = _commands[0];
            _commands.RemoveAt(0);
            command.Execute();
        }
    }
}
