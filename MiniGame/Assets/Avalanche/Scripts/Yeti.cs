using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yeti : MonoBehaviour {
    
    /// <summary>
    /// This class determines the behaviour of the yeti
    /// A GameObject player is set. The players position gets an X and a Y axis
    /// These are used as a target for the yeti to go
    /// The yeti moves slower than the player so you should be able to evade it
    /// </summary>
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed = 3f;

    private float playerPosX;
    private float playerPosY;

    Rigidbody2D rb;

    // Sets to coordinates for the yeti to lock onto
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;
	}

    /// <summary>
    /// Every frame the transform.position of the yeti is updated with a Vector2.MoveTowards
    /// Which takes a current position, a target (in this case a new Vector2), and a speed at which to move
    /// </summary>
    void FixedUpdate()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosX, playerPosY), speed * Time.deltaTime);
    }
}
