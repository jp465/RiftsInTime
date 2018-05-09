using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager LM;
    public PlayerController player;
    public Slider healthBar;
    bool gauntletOnCooldown = false;
    public int powerLevel = 0;
    //Slow Time
    public bool timeSlowed = false;
    public bool timeRewind = false;
    public bool timeStopped = false;
    public float stoppedMod;

    private void Awake()
    {
        Time.timeScale = 1f;
        
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

    private void Start()
    {
        ChargeGauntlet();
    }
    private void Update()
    {
        healthBar.value = player.currentHealth;
        
        if (timeSlowed == true)
        {
            Time.timeScale = .25f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (timeStopped == true)
        {
            stoppedMod = 0f;
        }
        else
        {
            stoppedMod = 1f;
        }
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
        SceneManager.LoadScene("LoseScreen");
        Debug.Log(player.respawnLocation + " respawnco2");
        player.transform.position = player.respawnLocation;
        player.gameObject.SetActive(true);
        player.currentHealth = player.maxHealth;
        player.updateUI();
    }

    public void ChargeGauntlet()
    {
        if (powerLevel <= 3 && !gauntletOnCooldown)
        {
            StartCoroutine("PowerLevelCo");
        }
    }

    public void CoolDownGauntlet()
    {
        powerLevel = 0;
        gauntletOnCooldown = true;
        StartCoroutine("CooldownCo");
        
    }

    IEnumerator PowerLevelCo()
    {

       
      for (int i = powerLevel; i < 3; i++)
        {
            yield return new WaitForSeconds(5f);
            powerLevel += 1;
            Debug.Log("PowerLevel =" + powerLevel);
        }
                 
        
        
    }
    IEnumerator CooldownCo()
    {
        Debug.Log("PowerLevel =" + powerLevel+ " CoolingDown");
        
        yield return new WaitForSeconds(10f);
        gauntletOnCooldown = false;
        ChargeGauntlet();

    }
}
