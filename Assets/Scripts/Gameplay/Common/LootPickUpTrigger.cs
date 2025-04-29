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
        Vector3 originalScale = transform.localScale;
        Vector3 enlargedScale = originalScale * 1.7f; // Можешь изменить на свой вкус

        float elapsed = 0f;

        // Анимация движения (слежение за игроком и парабола)
        DOTween.To(() => 0f, x =>
            {
                elapsed = x;

                Vector3 currentTargetPos = target.position;
                Vector3 newPos = Vector3.Lerp(startPos, currentTargetPos, x / jumpDuration);
                float yOffset = jumpPower * Mathf.Sin(Mathf.PI * (x / jumpDuration));
                newPos.y += yOffset;

                transform.position = newPos;
            }, jumpDuration, jumpDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() => Destroy(gameObject)); // Удалить объект после прыжка

        // Анимация масштаба: увеличение к середине и уменьшение к концу
        Sequence scaleSequence = DOTween.Sequence();
        scaleSequence.Append(transform.DOScale(enlargedScale, jumpDuration / 2f).SetEase(Ease.OutQuad));
        scaleSequence.Append(transform.DOScale(Vector3.zero, jumpDuration / 2f).SetEase(Ease.InQuad));
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