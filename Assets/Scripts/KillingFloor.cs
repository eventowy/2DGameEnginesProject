using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingFloor : MonoBehaviour {

    public GameObject target;

	void Update ()
    {
        transform.position = new Vector3(target.transform.position.x, -2f);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
