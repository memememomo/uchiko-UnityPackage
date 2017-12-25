using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierCurve
{
    public interface BezierFunc<T>
    {
        T GetValue(float t);
    }

    public static BezierFunc<Vector3> CreateBezier(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        return new BezierVector3(
            new Bezier3Float(p1.x, p2.x, p3.x),
            new Bezier3Float(p1.y, p2.y, p3.y),
            new Bezier3Float(p1.z, p2.z, p3.z)
        );
    }
    
    #region internal

    class Bezier3Float : BezierFunc<float>
    {
        private float x1;
        private float x2;
        private float x3;

        public Bezier3Float(float x1, float x2, float x3)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }

        public float GetValue(float t)
        {
            return 1 * x1 * Mathf.Pow(t, 0) * Mathf.Pow(1 - t, 2) +
                   2 * x2 * Mathf.Pow(t, 1) * Mathf.Pow(1 - t, 1) +
                   1 * x3 * Mathf.Pow(t, 2) * Mathf.Pow(1 - t, 0);
        }
    }

    class BezierVector3 : BezierFunc<Vector3>
    {
        private BezierFunc<float> x;
        private BezierFunc<float> y;
        private BezierFunc<float> z;

        public BezierVector3(BezierFunc<float> x, BezierFunc<float> y, BezierFunc<float> z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 GetValue(float t)
        {
            return new Vector3(
                x.GetValue(t),
                y.GetValue(t),
                z.GetValue(t)
            );
        }
    }
    
    #endregion
}