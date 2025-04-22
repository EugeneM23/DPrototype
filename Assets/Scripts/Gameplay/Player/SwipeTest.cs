using Gameplay;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine;
using Zenject;

public class SwipeTest : MonoBehaviour
{
    [Inject] private readonly PlayerMoveController _playerMove;

    public void ASD(string id)
    {
        switch (id)
        {
            case DirectionId.ID_UP:
                _playerMove.ApplyImpulse(Vector3.forward);
                break;

            case DirectionId.ID_DOWN:
                _playerMove.ApplyImpulse(-Vector3.forward);
                break;

            case DirectionId.ID_LEFT:
                _playerMove.ApplyImpulse(-Vector3.right);
                break;

            case DirectionId.ID_RIGHT:
                _playerMove.ApplyImpulse(Vector3.right);
                break;

            case DirectionId.ID_UP_LEFT:
                ;
                break;

            case DirectionId.ID_UP_RIGHT:
                break;

            case DirectionId.ID_DOWN_LEFT:
                break;

            case DirectionId.ID_DOWN_RIGHT:
                break;
        }
    }
}