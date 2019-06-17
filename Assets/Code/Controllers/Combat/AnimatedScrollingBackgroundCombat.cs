using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedScrollingBackgroundCombat : MonoBehaviour
{
    public float xVelocity, yVelocity;

    private Material material;
    private Vector2 offset;

    private void Awake()
    {
        material = PersistenceManager.manager.returnBgMaterial(PersistenceManager.manager.stageIdentifier);
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = material;
    }

    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }

}


