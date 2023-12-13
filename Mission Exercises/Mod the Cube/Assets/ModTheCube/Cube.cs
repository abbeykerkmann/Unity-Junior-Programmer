using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speed;
    
    void Start()
    {
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        // Rotate the cube in all directions
        transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f);
        transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
        transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime);

        // Change the cube's colour randomly
        Material material = Renderer.material;
        material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
