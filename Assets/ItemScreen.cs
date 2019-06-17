using UnityEngine;

public class ItemScreen : MonoBehaviour
{
    public float distance = 10;
    public float goDepth = 4;
    private Vector3 v3ViewPort;
    private Vector3 v3BottomLeft;
    private Vector3 v3TopRight;

    void Start()
    {
        distance -= (goDepth * 0.5f);

        v3ViewPort.Set(0, 0, distance);
        v3BottomLeft = Camera.main.ViewportToWorldPoint(v3ViewPort);
        v3ViewPort.Set(1, 1, distance);
        v3TopRight = Camera.main.ViewportToWorldPoint(v3ViewPort);

        transform.localScale = new Vector3(v3BottomLeft.x - v3TopRight.x, v3BottomLeft.y - v3TopRight.y, goDepth);
    }
}
