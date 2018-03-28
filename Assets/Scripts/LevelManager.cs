using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager LM;
    public PlayerController player;
    public Slider healthBar;
    //Slow Time
    public bool timeSlowed = false;
    public float slowMod;

    private void Awake()
    {
        /*
        if (LM == null)
        {
            DontDestroyOnLoad(gameObject);
            LM = this;
        }
        else if (LM != this)
        {
            Destroy(gameObject);
        }
        */
    }

    private void Update()
    {
        healthBar.value = player.currentHealth;
        if (timeSlowed == true)
            slowMod = .1f;
        else
            slowMod = 1f;
    }
    public void Respawn()
    {
        player.currentHealth = 0;
        player.updateUI();
        Debug.Log(player.respawnLocation + "respawn");
        player.currentHealth = 0;
        StartCoroutine("RespawnDelayCo");
        player.updateUI();
    }

    IEnumerator RespawnDelayCo()
    {

        Instantiate(player.deathParticles, player.transform.position, player.transform.rotation);
        player.gameObject.SetActive(false);
        Debug.Log(player.respawnLocation + " respawnco1 " + player.respawnDelay + " seconds");
        yield return new WaitForSeconds(player.respawnDelay);
        Debug.Log(player.respawnLocation + " respawnco2");
        player.transform.position = player.respawnLocation;
        player.gameObject.SetActive(true);
        player.currentHealth = player.maxHealth;
        player.updateUI();
    }
}
