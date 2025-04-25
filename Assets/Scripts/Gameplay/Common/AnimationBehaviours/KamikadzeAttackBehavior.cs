using System.Collections.Generic;
using Gameplay;
using Gameplay.Common;
using UnityEngine;

public class KamikadzeAttackBehavior : StateMachineBehaviour
{
    private List<GameObject> _kamikadzeParts = new();
    private bool _shouldCast = true;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyStateProvider>().FinishAttack();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float stopThreshold = 0.3f;
        if (stateInfo.normalizedTime > 0.2f && _shouldCast)
        {
            animator.GetComponent<MeleeDamageCaster>().EnebleDamageCast(1);
            _shouldCast = false;
        }

        if (stateInfo.normalizedTime > stopThreshold)
        {
            _kamikadzeParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/BodyParts01"),
                animator.transform.position + new Vector3(0, 1, 0), Quaternion.identity));

            _kamikadzeParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/BodyParts02"),
                animator.transform.position + new Vector3(1, 1, 0), Quaternion.identity));

            _kamikadzeParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/BodyParts03"),
                animator.transform.position + new Vector3(0, 1, 1), Quaternion.identity));

            _kamikadzeParts.Add(Instantiate(Resources.Load<GameObject>("Prefabs/BodyParts04"),
                animator.transform.position + new Vector3(0, 1, 2), Quaternion.identity));

            foreach (GameObject kamikadzePart in _kamikadzeParts)
            {
                kamikadzePart.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 50f, ForceMode.Impulse);
                kamikadzePart.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 50f, ForceMode.Impulse);
            }

            animator.GetComponent<HealthComponentBase>().TakeDamage(1000);
        }
    }
}