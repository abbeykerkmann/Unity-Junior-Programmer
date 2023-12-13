using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputId;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    [SerializeField] float speed = 10.0f;
    [SerializeField] float turnSpeed = 50f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputId);
        forwardInput = Input.GetAxis("Vertical" + inputId);

        // Moves the car forward based on up/down arrow keys
        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);

        // Rotates the car based on left/right arrow keys
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
