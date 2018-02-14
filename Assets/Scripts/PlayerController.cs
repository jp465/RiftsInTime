using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speedOfPlayerWalk;
	private Rigidbody2D playerRB;
	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	public bool isGrounded;
	private Animator playerAnim;
	public Vector3 respawnLocation;
	private LevelManager levMan;
	public int wallet;

    public Slider healthBar;

    //Shooting
    public GameObject laser_projectile;
    public Transform projectileSpawn;
    int direction=1;
    bool allowFire = true;

    //public AudioClip jump;
    //public AudioClip damage;
    //public AudioClip coin;

    // Use this for initialization
    void Start () {
		playerRB = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<Animator>();
		respawnLocation = transform.position;
		levMan = FindObjectOfType<LevelManager>();
		levMan.updateUI();
		wallet = PlayerPrefs.GetInt("coins");
	}
	
	// Update is called once per frame
	void Update () {
		playerMovementController();
        playerWeaponController();
        healthBar.value = levMan.currentHealth;
	}

	void playerMovementController(){
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		//Controls
		if(Input.GetAxisRaw("Horizontal")>0f){
			playerRB.velocity = new Vector2(speedOfPlayerWalk, playerRB.velocity.y);
			transform.localScale = new Vector3(1f,1f,1f);
            direction = 1;
		} else if(Input.GetAxisRaw("Horizontal")<0f){
			playerRB.velocity = new Vector2(-speedOfPlayerWalk, playerRB.velocity.y);
			transform.localScale = new Vector3(-1f,1f,1f);
            direction = -1;
		} else {
			playerRB.velocity = new Vector2(0f, playerRB.velocity.y);
		}

		if(Input.GetKeyDown(KeyCode.W)){
			playerJump();
		}

		playerAnim.SetFloat("speed", Mathf.Abs(playerRB.velocity.x));
		playerAnim.SetBool("isGrounded", isGrounded);
	}

	void playerJump(){
		if(isGrounded){
			//AudioSource.PlayClipAtPoint(jump,transform.position);
			playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
		}
	}

    void playerWeaponController() {
        if (Input.GetKeyDown(KeyCode.Space)&allowFire==true)
        {
            Debug.Log("shoot");
            fire();
        }
    }

    void fire()
    {
        allowFire = false;
        var shoot = Instantiate(laser_projectile, projectileSpawn.position, projectileSpawn.rotation);
        shoot.GetComponent<Rigidbody2D>().velocity = projectileSpawn.transform.right * direction * 7;
        StartCoroutine("fireRateCap");
        
    }

    IEnumerator fireRateCap()
    {
        yield return new WaitForSeconds(.2f);
        allowFire = true;
    }
    
    void OnTriggerEnter2D(Collider2D other){
		if(other.tag=="Kill Plane"){
			//AudioSource.PlayClipAtPoint(damage,transform.position);
			levMan.Respawn();
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
		//AudioSource.PlayClipAtPoint(coin,transform.position);
		wallet+=coins;
		PlayerPrefs.SetInt("coins",wallet);
		levMan.updateUI();
	}

}
