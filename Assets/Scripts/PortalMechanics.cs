using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMechanics : MonoBehaviour {

    public PlayerController Player;
    public Transform DestinationPoint;
    public Collider2D Trigger;


	void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.transform.position = DestinationPoint.position;
         
            Trigger.enabled = false;
            StartCoroutine("Wait");

        }

    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Trigger.enabled = true;
    }
}
