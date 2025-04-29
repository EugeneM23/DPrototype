using System;
using DG.Tweening;
using Gameplay;
using UnityEngine;

public class JumpToMovingTarget : MonoBehaviour
{
    public float jumpPower = 2f;
    public float jumpDuration = 1f;

    private Transform target;
    private bool isAsd;

    public void JumpTo(Transform playerTransform)
    {
        target = playerTransform;
        Vector3 startPos = transform.position;

        float elapsed = 0f;

        DOTween.To(() => 0f, x =>
            {
                elapsed = x;

                // Текущая позиция игрока
                Vector3 currentTargetPos = target.position;

                // Плавное движение к цели
                Vector3 newPos = Vector3.Lerp(startPos, currentTargetPos, x / jumpDuration);

                // Добавляем параболу по Y
                float yOffset = jumpPower * Mathf.Sin(Mathf.PI * (x / jumpDuration));
                newPos.y += yOffset;

                transform.position = newPos;
            }, jumpDuration, jumpDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() => Destroy(gameObject)); // <-- Удаляем объект после прыжка
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAsd) return;

        if (other.TryGetComponent<PlayerTransform>(out PlayerTransform playerTransform))
        {
            isAsd = true;

            JumpTo(playerTransform.transform);
        }
    }
}