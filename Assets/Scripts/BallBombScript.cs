using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBombScript : MonoBehaviour
{
    public GameObject bombs;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            bombs.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "picker")
        {
            rb.isKinematic = false;
        }
    }
}
