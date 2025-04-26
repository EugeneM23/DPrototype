using UnityEngine;
using Zenject;

namespace Game
{
    public class PlayerTransform : MonoBehaviour
    {
        [Inject] private CharacterController _character;
        public Transform Transform => gameObject.transform;

        public Vector3 GetVelocity() => _character.velocity;
    }
}