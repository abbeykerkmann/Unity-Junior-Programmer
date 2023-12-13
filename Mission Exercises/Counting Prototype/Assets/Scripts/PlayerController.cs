using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;

    private float speed = 10.0f;
    private float xBound = 12;
    private float zBound = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gather user inputs
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plate based on user inputs
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        //prevent the plate from leaving the playing area
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, 0, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, 0, transform.position.z);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, 0, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, 0, -zBound);
        }
    }

    public void IncreaseSpeed()
    {
        speed += 5;
    }
}
