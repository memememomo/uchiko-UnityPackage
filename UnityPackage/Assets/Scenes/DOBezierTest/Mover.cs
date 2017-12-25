using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using DG.Tweening;
using UnityEngine;

namespace TestScene.DOBezierTest
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform destinationPosition;

        [SerializeField] private float flyDuration;
        [SerializeField] private float centerXDiff;
        [SerializeField] private float centerYDiff;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(StartGet(transform, destinationPosition));
        }
        
        IEnumerator StartGet(Transform parent, Transform destination)
        {
            bool complete = false;

            if (destination != null) {
                parent.DOBezier(destination, flyDuration, centerXDiff, centerYDiff)
                    .SetEase(Ease.InCubic)
                    .OnComplete(() => complete = true);
            }
            else {
                complete = true;
            }
            
            yield return new WaitUntil(() => complete);
        }
    }
}
