using Rover.Constants;

namespace Rover.Contracts
{
    public interface IPosition
    {
        void SetPosition(int x, int y, Directions direction);
        void Move(string commands);
    }
}
