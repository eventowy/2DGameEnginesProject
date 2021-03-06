﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private LevelManager theLevelManager;

    public int dmgToGive;
    public int MonsterHealth;
    public GameObject DeathExplosion;


	void Start ()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.hurtPlayer(dmgToGive);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerAttack")
        {
            MonsterHealth--;
            if (MonsterHealth == 0)
            {
                Instantiate(DeathExplosion, gameObject.transform.position, gameObject.transform.rotation);
                gameObject.SetActive(false);
                MonsterHealth = 1;
            }
        }
    }
}
