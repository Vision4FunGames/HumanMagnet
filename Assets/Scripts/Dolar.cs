using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Dolar : MonoBehaviour
{
    public Transform moveTransform;

    public void DolarAnimation(float delay,float scaleDuration,float moveDuration)
    {
        transform.DOScale(new Vector3(1, 1, 1), scaleDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMove(moveTransform.position, moveDuration).SetDelay(delay).SetEase(Ease.Linear).OnComplete(() =>
            {
                moveTransform.DOKill();
                moveTransform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.01f).SetEase(Ease.Linear).OnComplete(() =>
                {
                   moveTransform.DOScale(new Vector3(1, 1, 1), 0.01f).SetEase(Ease.Linear);
                });
                Destroy(gameObject,0.01f);
            });
        });
    }
}
