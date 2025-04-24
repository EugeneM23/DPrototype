using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class AttackAnimationProvider : MonoBehaviour
    {
        [Inject] private EnemyStateObserver _conditions;

        public void FinishAttack()
        {
            Debug.Log("finishAttack");
            _conditions.IsBusy = false;
        }
    }
}