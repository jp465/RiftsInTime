using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Movement
    public float speedOfPlayerWalk;
    Transform groundCheck;
    const float groundedRadius = .2f;
    bool isGrounded;
    [SerializeField] LayerMask whatIsGround;
    Rigidbody2D playerRB;

    //Jumping
    public float maxJumpHeight;
    Vector3 currentJumpPosition;
    bool isJumping;
    [SerializeField] bool airControl = false;

    //Misc
    private Animator playerAnim;
    private SpriteRenderer sprRen;
    LevelManager LM;

    //Respawn
    public Vector3 respawnLocation;
    public Vector3 ogRespawn;
    public float respawnDelay;
    public GameObject deathParticles;
    
    //Coins
    public Text coinCounterText;
    public int wallet;

    //Health
    public int maxHealth;
    public int currentHealth;
    //public Slider healthBar;

    //Shooting
    public GameObject laser_projectile;
    public Transform projectileSpawn;
    public float pistolDamage;
    int direction=1;
    bool allowFire = true;
    float projSpawnX;

    public float knockbackForce;
    public float knockbackLength;
    float knockbackCounter;
    //Slow Time
    //public bool timeSlowed = false;
    //float slowMod;
    
    //Progression 
    public int playerLevel;
    public int playerSkillPoints;


    private void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("GroundCheck");
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        sprRen = GetComponent<SpriteRenderer>();
        projSpawnX = projectileSpawn.transform.localPosition.x;
        LM = FindObjectOfType<LevelManager>();
    }

    // Use this for initialization
    void Start () {
		respawnLocation = transform.position;
        ogRespawn = transform.position;
        coinCounterText.text = "Coins: " + 0;
        currentHealth = maxHealth;
        updateUI();
		wallet = PlayerPrefs.GetInt("coins");
	}
	
	// Update is called once per frame
	void Update () {
        playerWeaponController();
        //healthBar.value = currentHealth;
        /*
        if (timeSlowed == true)
            slowMod = .5f;
        else
            slowMod = 1f;
       */
	}

    private void FixedUpdate()
    {
        isGrounded = false;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
     }

    public void playerMovementController(float move, bool jump)
    {
        


        if (knockbackCounter <= 0)
        {
            //only control the player if grounded or airControl is turned on
            if (isGrounded || airControl)
            {
                // Move the character
                playerRB.velocity = new Vector2(move * speedOfPlayerWalk, playerRB.velocity.y);
                
                
               
                if (move > 0)
                {
                    sprRen.flipX = false;

                    direction = 1;
                    projectileSpawn.transform.localPosition = new Vector3(projSpawnX, 0f, 0f);
                }
                else if (move < 0)
                {
                    sprRen.flipX =  true;
                    direction = -1;
                    projectileSpawn.transform.localPosition = new Vector3(-projSpawnX, 0f, 0f);
                }
            }



            // If the player should jump...
            if (isGrounded && jump)
            {
                // Add a vertical force to the player.
                isGrounded = false;
                airControl = true;
                playerRB.velocity = new Vector2(0f, maxJumpHeight);
            }
        }

        if (knockbackCounter > 0)
        {
            knockbackCounter -= Time.deltaTime;
            if (sprRen.flipX == false) {
                playerRB.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            }
            else
            {
                playerRB.velocity = new Vector3(knockbackForce, knockbackForce, 0f);

            }
        }
        playerAnim.SetFloat("speed", Mathf.Abs(playerRB.velocity.x));
        playerAnim.SetBool("isGrounded", isGrounded);
    }

    void knockback()
    {
        knockbackCounter = knockbackLength;
    }

    void playerWeaponController() {
        if (Input.GetKey(InputManager.IM.attack) && allowFire==true && !LM.timeRewind)
        {
            Debug.Log("shoot");
            fire();
        }
    }

    void fire()
    {
        allowFire = false;
        var shoot = Instantiate(laser_projectile, projectileSpawn.position, projectileSpawn.rotation);
        shoot.GetComponent<Rigidbody2D>().velocity = projectileSpawn.transform.right * direction * 9;
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
        knockback();
    }

    void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Kill Plane"){
			LM.Respawn();
		}

       if (other.tag=="Checkpoint"){
			respawnLocation = other.transform.position;
		}

		if (other.gameObject.CompareTag("Exit")){
            PlayerPrefs.SetInt("coins", 0);
            ogRespawn = respawnLocation;
            SceneManager.LoadScene("WinScreen");
		}

        

    }

    

    void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag=="MovingPlatform"){
			transform.parent = other.transform;
		}
        if (other.gameObject.tag == "Enemy")
        {
            playerDamage(1);
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
