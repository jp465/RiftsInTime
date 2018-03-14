using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Movement
    public float speedOfPlayerWalk;
	private Rigidbody2D playerRB;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;


	private Animator playerAnim;
	public Vector3 respawnLocation;
	private LevelManager levMan;
	public int wallet;

    //Respawn
    public float respawnDelay;
    public GameObject deathParticles;

    //Coins
    public Text coinCounterText;

    //Health
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;

    //Shooting
    public GameObject laser_projectile;
    public Transform projectileSpawn;
    int direction=1;
    bool allowFire = true;

    public bool timeSlowed = false;
    float slowMod;

    CharMovement playerMove;

    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<Animator>();
        playerMove = GetComponent<CharMovement>();
		respawnLocation = transform.position;
        Debug.Log(respawnLocation);
        coinCounterText.text = "Coins: " + 0;
        currentHealth = maxHealth;
        updateUI();
		wallet = PlayerPrefs.GetInt("coins");
	}
	
	// Update is called once per frame
	void Update () {
		playerMovementController();
        playerWeaponController();
        healthBar.value = currentHealth;

        if (timeSlowed == true)
            slowMod = .5f;
        else
            slowMod = 1f;
	}

	void playerMovementController(){
		//Controls
		if(Input.GetKey(LevelManager.LM.right)){
			playerMove.velocity = new Vector2(speedOfPlayerWalk, playerMove.velocity.y);
			transform.localScale = new Vector3(1f,1f,1f);
            direction = 1;
		} else if(Input.GetKey(LevelManager.LM.left))
        {
            playerMove.velocity = new Vector2(-speedOfPlayerWalk, playerMove.velocity.y);
			transform.localScale = new Vector3(-1f,1f,1f);
            direction = -1;
		} else {
            playerMove.velocity = new Vector2(0f, playerMove.velocity.y);
		}

		if(Input.GetKeyDown(LevelManager.LM.jump))
        {
			playerJump();
		}

		playerAnim.SetFloat("speed", Mathf.Abs(playerMove.velocity.x));
		playerAnim.SetBool("isGrounded", playerMove.isGrounded);
	}

	void playerJump(){
		if(playerMove.isGrounded && !timeSlowed){
            playerMove.velocity = new Vector2(playerMove.velocity.x, jumpHeight);
		}else if(playerMove.isGrounded && timeSlowed)
        {
            //playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight)*(1/slowMod);
            playerMove.velocity = new Vector2(playerMove.velocity.x, jumpHeight);
        }
	}

    void playerWeaponController() {
        if (Input.GetKey(LevelManager.LM.attack) & allowFire==true)
        {
            Debug.Log("shoot");
            fire();
        }
    }

    void fire()
    {
        allowFire = false;
        var shoot = Instantiate(laser_projectile, projectileSpawn.position, projectileSpawn.rotation);
        shoot.GetComponent<Rigidbody2D>().velocity = projectileSpawn.transform.right * direction * 9 * slowMod;
        StartCoroutine("fireRateCap");
        
    }

    IEnumerator fireRateCap()
    {
        yield return new WaitForSeconds(.2f);
        allowFire = true;
    }
    
    public void updateUI()
    {
        coinCounterText.text = "Coins: " + PlayerPrefs.GetInt("coins");
    }

    public void playerDamage(int damage)
    {
        currentHealth -= damage;
    }

    void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Kill Plane"){
			LevelManager.LM.Respawn();
		}

		if(other.tag=="Checkpoint"){
			respawnLocation = other.transform.position;
		}

		if (other.gameObject.CompareTag("Exit")){
			SceneManager.LoadScene(PlayerPrefs.GetString("nextScene"));
		}
 	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag=="MovingPlatform"){
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag=="MovingPlatform"){
			transform.parent = null;
		}
	}

	public void addCoin(int coins){
		wallet+=coins;
		PlayerPrefs.SetInt("coins",wallet);
		updateUI();
	}

}
