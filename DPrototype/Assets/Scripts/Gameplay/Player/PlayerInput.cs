using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInput
    {
        public Vector3 Axis => new(SimpleInput.GetAxisRaw("Horizontal"), 0, SimpleInput.GetAxisRaw("Vertical"));
    }
}