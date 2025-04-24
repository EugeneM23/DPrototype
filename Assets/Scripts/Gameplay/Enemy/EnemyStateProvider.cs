using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class EnemyStateProvider : MonoBehaviour
    {
        [Inject] private EnemyStateManager _conditions;

        public void FinishAttack()
        {
            _conditions.IsBusy = false;
        }
    }
}