using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [Header("Rope Targets")]
    public Transform player1;
    public Transform player2;

    [Header("Rope Physics")]
    public int resolution = 20;
    public float maxSag = 1.5f;
    public float maxDistance = 5f;

    [Header("Ground Collision")]
    public bool preventGoingBelowGround = true;
    public float distanceToFeet = 0.5f;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = resolution;
    }

    void Update()
    {
        if (player1 == null || player2 == null) return;

        Vector3 p1 = player1.position;
        Vector3 p2 = player2.position;

        float currentDistance = Vector3.Distance(p1, p2);
        float sagMultiplier = Mathf.Max(0, 1f - (currentDistance / maxDistance));
        float currentSag = maxSag * sagMultiplier;

        Vector3 midPoint = (p1 + p2) / 2f;
        midPoint.y -= currentSag;

        if (preventGoingBelowGround)
        {
            float floorY = Mathf.Min(p1.y, p2.y) - distanceToFeet;

            midPoint.y = Mathf.Max(midPoint.y, floorY);
        }

        for (int i = 0; i < resolution; i++)
        {
            float t = i / (float)(resolution - 1);
            Vector3 pointPosition = CalculateQuadraticBezierPoint(t, p1, midPoint, p2);
            line.SetPosition(i, pointPosition);
        }
    }

    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }
}
