using UnityEngine;

namespace Gameplay
{
    public class RotationToTarget
    {
        public void Rotation(Transform objToRotation, Transform target)
        {
            Vector3 direction = target.transform.position - objToRotation.position;
            direction.y = 0;

            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            objToRotation.rotation =
                Quaternion.Slerp(objToRotation.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}