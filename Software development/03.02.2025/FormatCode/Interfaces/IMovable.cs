namespace FormatCode.Interfaces
{
    using FormatCode.Enums;

    public interface IMovable
    {
        void Move();
        Direction Direction { get; }
        void ChangeDirection(Direction newDirection);
    }
}