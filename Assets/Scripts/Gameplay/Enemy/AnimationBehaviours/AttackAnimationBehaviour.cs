using Gameplay;
using UnityEngine;
using Zenject;

public class AttackAnimationBehaviour : StateMachineBehaviour
{
    [Inject] private readonly AttackAnimationProvider _animationProvider;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animationProvider.StartAttackAnimation();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animationProvider.FinishAttackAnimation();
    }
}