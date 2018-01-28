using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour {

    private LevelManager LevelManager;

	void Start ()
    {
        LevelManager = FindObjectOfType<LevelManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            LevelManager.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
