using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [Header("Rope Targets")]
    public Transform player1;
    public Transform player2;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        // Every frame, update the start and end coordinates of the line 
        // to exactly match the current positions of both players
        if (player1 != null && player2 != null)
        {
            line.SetPosition(0, player1.position);
            line.SetPosition(1, player2.position);
        }
    }
}
