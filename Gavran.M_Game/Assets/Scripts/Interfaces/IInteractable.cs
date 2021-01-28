using UnityEngine.PlayerLoop;

namespace GavranGame
{
    public interface IInteractable : IAction, IInitialization
    {
        bool isInteractable { get; }
    }
}