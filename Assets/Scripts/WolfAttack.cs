using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttack : MonoBehaviour {

    public bool inRange;
    public Wolf wolf;
    private Animator anim;

    void Start()
    {
        wolf = FindObjectOfType<Wolf>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wolf.anim.SetBool("inRange", true);
            wolf.movingSpeed = 10f;
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            wolf.anim.SetBool("inRange", false);
            wolf.movingSpeed = 5f;
            inRange = false;
        }
    }
}


