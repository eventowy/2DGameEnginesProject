using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsReset : MonoBehaviour {

    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 startScale;

  
    private Rigidbody2D myRigidbody;

	void Start ()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        startScale = transform.localScale;

        if(GetComponent<Rigidbody2D>() != null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

	}

    public void ResetObject()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        transform.localScale = startScale;


        if(myRigidbody != null)
        {
            myRigidbody.velocity = Vector3.zero;
        }

    }
}
