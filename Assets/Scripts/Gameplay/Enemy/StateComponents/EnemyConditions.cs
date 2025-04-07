using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.BehComponents
{
    public class EnemyConditions : MonoBehaviour
    {
        public bool IsChasing;
        public bool IsPatroling;
        public bool IsAidling;
        public bool IsAttaking;
        public bool IsOnAnimation;
    }
}