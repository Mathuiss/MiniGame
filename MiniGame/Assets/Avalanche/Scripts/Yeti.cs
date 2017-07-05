using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yeti : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed = 3f;

    private float playerPosX;
    private float playerPosY;

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;
	}

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosX, playerPosY), speed * Time.deltaTime);
    }
}
