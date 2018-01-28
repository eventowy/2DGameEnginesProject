using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMechanics : MonoBehaviour {

    private PlayerController Player;

    void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
	}
	
	void Update ()
    {
        if (Player.onRope == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(Player.Connection);
                Player.onRope = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Player.Connection == false)
            {
                Player.Connection = Player.gameObject.AddComponent<HingeJoint2D>();
                Player.Connection.connectedBody = gameObject.GetComponent<Rigidbody2D>();
                Player.onRope = true;
            }
            else
            {
                return;
            }
        }
    }
}
