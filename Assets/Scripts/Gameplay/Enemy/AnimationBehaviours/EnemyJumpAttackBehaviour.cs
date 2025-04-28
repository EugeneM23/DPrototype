using DPrototype.Game;
using Game;
using Gameplay;
using UnityEngine;
using Zenject;

public class EnemyJumpAttackBehaviour : StateMachineBehaviour
{
    [Inject] private CameraShakeComponent _cameraShake;
    [Inject] private PlayerTransform _player;
    private bool _isShaked;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isShaked = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float stopThreshold = 0.5f;
        if (stateInfo.normalizedTime < stopThreshold)
        {
            Vector3 direction = (_player.transform.position - animator.transform.position).normalized;
            float moveSpeed = 6.5f;

            animator.transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (!_isShaked)
            {
                Instantiate(Resources.Load<GameObject>("Prefabs/Spikes attack"), animator.transform.position,
                    Quaternion.identity);
                _isShaked = true;
                _cameraShake.CameraShake(0.3f, 1);
            }
        }
    }
}