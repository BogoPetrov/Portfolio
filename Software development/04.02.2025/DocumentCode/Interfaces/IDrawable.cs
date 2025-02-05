namespace DocumentCode.Interfaces
{
    /// <summary>
    /// An interface for specifying drawing on the game screen
    /// </summary>
    public interface IDrawable
    {
        void Draw(IDrawer drawer);
    }
}