using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    public static LevelManager LM;
    public PlayerController player;
    public KeyCode jump { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode shield { get; set; }
    public KeyCode interact { get; set; }
    public KeyCode attack { get; set; }
    public KeyCode rift1 { get; set; }
    public KeyCode rift2 { get; set; }
    public KeyCode rift3 { get; set; }
    public KeyCode weapon1 { get; set; }
    public KeyCode weapon2 { get; set; }
    public KeyCode weapon3 { get; set; }
    public KeyCode weapon4 { get; set; }
    public KeyCode weapon5 { get; set; }
    public KeyCode pause { get; set; }

    private void Awake()
    {
        
        if (LM == null)
        {
            DontDestroyOnLoad(gameObject);
            LM = this;
        }else if(LM != this)
        {
            Destroy(gameObject);
        }
        
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "W"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        shield = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shieldKey", "S"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "E"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "Space"));
        rift1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rift1Key", "B"));
        rift2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rift2Key", "N"));
        rift3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rift3Key", "M"));
        weapon1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("weapon1Key", "Alpha1"));
        weapon2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("weapon2Key", "Alpha2"));
        weapon3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("weapon3Key", "Alpha3"));
        weapon4 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("weapon4Key", "Alpha4"));
        weapon5 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("weapon5Key", "Alpha5"));
        pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
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
