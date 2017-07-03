using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    PolygonCollider2D collider;

    [SerializeField]
    private float speed;
    private float linkerGrens = -2.5f;
    private float rechterGrens = 2.5f;
    private Vector2 velocity;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }
    
    public void Update()
    {
        // Input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity = Vector2.right * speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity = Vector2.left * speed;
        }
        else
        {
            velocity = Vector2.zero;
        }

        // Movement
        transform.position += ((Vector3)velocity) * 5 / 120; //5 en 120 zijn de snelheid waarmee het poppetje moet bewegen op 60 fps
        transform.position = (Vector3) new Vector2(Mathf.Clamp(transform.position.x, linkerGrens, rechterGrens), 0f);
    }
}