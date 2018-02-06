using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DropTrackParts : MonoBehaviour {

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.rb.useGravity = false;
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.rb.useGravity = true;
        }
    }

}
