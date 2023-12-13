using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Food : MonoBehaviour
{
    private float xBound = 12;
    private float zBound = 3;
    private Rigidbody foodRb;
    private GameManager gameManager;
    private PlayerController playerController;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        foodRb = GetComponent<Rigidbody>();
        transform.position = GenerateSpawnPosition();

        playerController = GameObject.Find("Plate").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPosition()
    {
        // create a random spawn location for the food
        return new Vector3(Random.Range(-xBound, xBound), 20, Random.Range(-zBound, zBound));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the food makes contact with the plate
        if (collision.gameObject.CompareTag("Plate"))
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.anchor = contact.point;
                fixedJoint.connectedBody = collision.rigidbody;
            }
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore();
            playerController.IncreaseSpeed();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.UpdateLives();
            Instantiate(dirtParticle, transform.position, explosionParticle.transform.rotation);
        }
    }
}
