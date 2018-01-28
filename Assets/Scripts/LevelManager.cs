using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;

    public GameObject DeathExplosion;
    public int coinCount;

    public Text coinText;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healthCount;

    private bool respawning;
    public bool invicible;

    public int currentLives;
    public int startingLives;
    public Text livesText;
    public string MainMenu;

    public GameObject gameOver;

    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        coinText.text = ""+coinCount;
        healthCount = maxHealth;
        currentLives = startingLives;
        livesText.text = "x" + currentLives;
	}
	
	void Update ()
    {
		if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
            thePlayer.knockbackLength = 0f;
            thePlayer.knockbackForce = 0f;

        }
	}

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "x" + currentLives;

        if(currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOver.SetActive(true);
            StartCoroutine("Restart");
        }
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(5f);
        gameOver.SetActive(false);
        SceneManager.LoadScene(MainMenu);
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        Instantiate(DeathExplosion, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        healthCount = maxHealth;
        respawning = false;
        HeartUpdate();
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinText.text = "" + coinCount;
    }

    public void hurtPlayer(int damageToTake)
    {
        if (!invicible)
        {
            healthCount -= damageToTake;
            HeartUpdate();

            thePlayer.Knockback();
        }
    }

    public void HeartUpdate()
    {
        switch (healthCount)
        {
            case 6:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartFull;
                return;
            case 5:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartHalf;
                return;
            case 4:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartFull;
                Heart3.sprite = heartEmpty;
                return;
            case 3:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartHalf;
                Heart3.sprite = heartEmpty;
                return;
            case 2:
                Heart1.sprite = heartFull;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;
            case 1:
                Heart1.sprite = heartHalf;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;
            case 0:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;
            default:
                Heart1.sprite = heartEmpty;
                Heart2.sprite = heartEmpty;
                Heart3.sprite = heartEmpty;
                return;
        }
    }
}
