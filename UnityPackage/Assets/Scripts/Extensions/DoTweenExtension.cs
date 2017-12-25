

using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;

public static class DoTweenTransformExtension
{
    public static Tween DOBezier(this Transform transform, Transform target, float duration, float centerXDiff,
        float centerYDiff)
    {
        var v = 0f;
        
        transform.SetParent(target);
        var center = transform.localPosition / 2;

        center.y -= center.y * centerYDiff;
        center.x += center.x * centerXDiff;

        var curve = BezierCurve.CreateBezier(
            transform.localPosition,
            center,
            Vector3.zero
        );

        return DOTween.To(
            () => v,
            nv => {
                v = nv;
                transform.localPosition = curve.GetValue(v);
            },
            1f,
            duration
        );

    }
}
