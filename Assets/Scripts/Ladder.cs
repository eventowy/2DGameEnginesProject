using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private PlayerController Player;

	void Start () {
        Player = FindObjectOfType<PlayerController>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.canClimb = true;
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player" && Player.isGrounded == false)
        {
            Player.onLadder = true;
        }
        else
        {
            Player.onLadder = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.canClimb = false;
            Player.onLadder = false;
        }
    }
}
