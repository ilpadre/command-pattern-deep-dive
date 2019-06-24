using System;

namespace reference_implementation
{
    /// <summary>
    /// MainApp startup class for Reference
    /// Command Design Pattern.
    /// </summary>
    class MainApp

    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create receiver, command, and invoker

            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            // Set and execute command

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command
    {
        protected Receiver receiver { get; set; }

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    class ConcreteCommand : Command
    {

        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class Invoker
    {
        private Command _command { set; get; }

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}