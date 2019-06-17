using UnityEngine;

public class Parallax : MonoBehaviour
{
    public bool scrolling, parallax, followVertically;

    public float backgroundSize;
    public float parallaxSpeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewzone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (parallax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        if (scrolling)
        {

            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewzone))
            {
                ScrollLeft();
            }

            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewzone))
            {
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        int LastRight = rightIndex;
        layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, layers[leftIndex].position.y, transform.position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int LastLeft = leftIndex;
        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, layers[rightIndex].position.y, transform.position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
