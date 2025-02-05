namespace DocumentCode.Interfaces
{
    using System;

    /// <summary>
    /// An interface for handling keyboard input and checking if pressed key is available
    /// </summary>
    public interface IKeyboardHandler
    {
        ConsoleKey PressedKey { get; }

        bool IsKeyAvailable { get; }
    }
}