using Gameplay;
using UnityEngine;
using Zenject;

public class JumpAttackBehaviour : StateMachineBehaviour
{
    [Inject] private readonly Player _player;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float stopThreshold = 0.5f;
        if (stateInfo.normalizedTime < stopThreshold)
        {
            Vector3 direction = (_player.transform.position - animator.transform.position).normalized;
            float moveSpeed = 6.5f;

            animator.transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}