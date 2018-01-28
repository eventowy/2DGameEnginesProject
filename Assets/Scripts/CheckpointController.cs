using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite Empty;
    public Sprite Checkpointed;

    private SpriteRenderer theSpriteRenderer;

    public bool checkpointActive;


	void Start ()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theSpriteRenderer.sprite = Checkpointed;
            checkpointActive = true;
        }
    }
}
