using UnityEngine;

namespace Gameplay
{
    public class AirStrikeAttackbehaviour : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<AirStrikeSpawner>().Spawn();
        }
    }
}