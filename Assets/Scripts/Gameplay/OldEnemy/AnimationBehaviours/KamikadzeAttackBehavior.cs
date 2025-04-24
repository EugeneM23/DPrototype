using System.Collections.Generic;
using Gameplay;
using UnityEngine;

/*public class KamikadzeAttackBehavior : StateMachineBehaviour
{
    private List<GameObject> _kamikadzeParts = new();

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float stopThreshold = 0.2f;
        if (stateInfo.normalizedTime > stopThreshold)
        {
            /*animator.GetComponent<Enemy>().Kill();
            Instantiate(Resources.Load<GameObject>("Prefabs/Spikes attack"), animator.transform.position,
                Quaternion.identity);#1#

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
        }

        animator.GetComponent<AttackAnimationProvider>().FinishAttackAnimation();
    }
}*/