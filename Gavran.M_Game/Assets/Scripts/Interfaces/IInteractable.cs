using UnityEngine.PlayerLoop;

namespace GavranGame
{
    public interface IInteractable : IAction
    {
        bool isInteractable { get; }
    }
}