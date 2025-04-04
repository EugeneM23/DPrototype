using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class Enemy : MonoBehaviour
    {
        [Inject] private Player _player;
    }
}