using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Sprite playerLeft;

    [SerializeField]
    private Sprite playerRight;

    [SerializeField]
    private Sprite playerDown;

    [SerializeField]
    private Sprite playerDead;

    [SerializeField]
    private float jumpTime = 0.25f;

    [SerializeField]
    private float speed = 5;
    private float linkerGrens = -2.5f;
    private float rechterGrens = 2.5f;

    [SerializeField]
    private float cooldownTime = 2f;
    private float hitDuration = 0.5f;
    private float lastCollisionTime;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    void Start()
    {
        lastCollisionTime = -cooldownTime;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Update()
    {
        // Input
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

        if (Time.time - lastCollisionTime < hitDuration)
        {
            rb.velocity += Vector2.down * 4f;
            spriteRenderer.sprite = playerDead;
        }

        transform.position = (Vector3) new Vector2(Mathf.Clamp(transform.position.x, linkerGrens, rechterGrens), transform.position.y);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        // Collision met bomen en stenen
        if (Time.time - lastCollisionTime > cooldownTime)
        {
            if (collider.tag == "Avelanche")
            {
                SceneManager.LoadScene("MainMenuScene");
            }
            else
            {
                StartCoroutine(InvinsibilityFrames());
                lastCollisionTime = Time.time;
            }
        }
    }

    IEnumerator InvinsibilityFrames()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(cooldownTime);
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }
}