using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    private PlayerController Player;
    public float moveSpeed;
    public float sightRange;
    public bool playerInRange;
    public LayerMask playerLayer;


	void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
	}
	
	void Update ()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, sightRange, playerLayer);

        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }
        if (moveSpeed < 8f)
        {
            moveSpeed += Time.deltaTime;
        }
    }

    public IEnumerator WaitForHitCo()
    {
        moveSpeed = 0f;

        yield return new WaitForSeconds(2f);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("WaitForHitCo");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
