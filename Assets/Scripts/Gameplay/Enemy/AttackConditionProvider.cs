using Gameplay.BehComponents;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class AttackConditionProvider : MonoBehaviour
    {
        [SerializeField] private EnemyConditions _conditions;

        public void FinishAnimation()
        {
            /*GetComponent<ChaseComponent>().enabled = true;
            
            GetComponent<PatrolComponent>().enabled = true;
            GetComponent<AttackComponent>().enabled = false;*/
            _conditions.IsOnAnimation = false;
            /*GetComponent<ChaseComponent>().enabled = true;
            GetComponent<PatrolComponent>().enabled = true;*/
        }

        public void StartAnimation()
        {
            /*GetComponent<AttackComponent>().enabled = true;
            
            GetComponent<ChaseComponent>().enabled = false;
            GetComponent<PatrolComponent>().enabled = false;*/
           
            _conditions.IsOnAnimation = true;
        }
    }
}