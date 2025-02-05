namespace DocumentCode.Interfaces
{
    using Enums;

    /// An interface for specifying movement of the game object
    public interface IMovable
    {
        /// Use the Direction enum in Enums folder as data type
        Direction Direction { get; }

        void Move();

        void ChangeDirection(Direction newDirection);
    }
}