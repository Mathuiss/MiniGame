using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The first 4 sprites are all the states in which the player can be
    /// Left, Right, Down and Dead
    /// </summary>
    [SerializeField]
    private Sprite playerLeft;

    [SerializeField]
    private Sprite playerRight;

    [SerializeField]
    private Sprite playerDown;

    [SerializeField]
    private Sprite playerDead;

    /// <summary>
    /// This can potentially be used to create a ramp
    /// </summary>
    [SerializeField]
    private float jumpTime = 0.25f;

    /// <summary>
    /// To make sure the player controls well a speed is given and borders are made
    /// The player cannot cross these borders
    /// Therefore the player cannot be out of the range of the screen
    /// </summary>
    [SerializeField]
    private float speed = 5;
    private float linkerGrens = -2.5f;
    private float rechterGrens = 2.5f;

    /// <summary>
    /// Once a player has hit an obstacle a cooldownTime is initiated
    /// During this time the player is temporarily invincible
    /// </summary>
    [SerializeField]
    private float cooldownTime = 2f;
    private float hitDuration = 0.5f;
    private float lastCollisionTime;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    void Start()
    {
        //To make sure the player does not start with a cooldown
        lastCollisionTime = -cooldownTime;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    /// <summary>
    /// In the update in the controls section once a button is pressed the player will move in that general direction
    /// The sprite of the player, indicating the playerstate, will also be updated
    /// </summary>
    public void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * speed;
            spriteRenderer.sprite = playerRight;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * speed;
            spriteRenderer.sprite = playerLeft;
        }
        else
        {
            rb.velocity = Vector2.zero;
            spriteRenderer.sprite = playerDown;
        }

        //Once a player is hit his position will go down with a speed of 4f
        if (Time.time - lastCollisionTime < hitDuration)
        {
            rb.velocity += Vector2.down * 4f;   //Speed with which the player moves down
            spriteRenderer.sprite = playerDead; //Sets the sprite indicating the playerstate to Dead
        }
        //Using Mathf.Clap to bound the player movement to a certain area
        transform.position = (Vector3) new Vector2(Mathf.Clamp(transform.position.x, linkerGrens, rechterGrens), transform.position.y);
    }

    /// <summary>
    /// This method is called once a collision has been detected
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerStay2D(Collider2D collider)
    {
        
        if (Time.time - lastCollisionTime > cooldownTime)
        {
            //Once a collision with the avalanche has been detected the game will be over
            if (collider.tag == "Avelanche")
            {
                SceneManager.LoadScene("MainMenuScene");
            }
            else
            {
                //InvisibilityFrames is an IEnumerator that waits for the cooldown and temporarily sets the color to relatively transparant
                StartCoroutine(InvinsibilityFrames());
                lastCollisionTime = Time.time;
            }
        }
    }

    /// <summary>
    /// Sets to color to transparants
    /// Waits for the cooldown to finish
    /// Resets the color back to it's default state
    /// </summary>
    /// <returns></returns>
    IEnumerator InvinsibilityFrames()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(cooldownTime);
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}