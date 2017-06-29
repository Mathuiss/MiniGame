using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {

    private float speed = -0.1f;
    

    // Use this for initialization
    void Start()
    {
        
	}
	
    public void Reset()
    {
        Vector2 linkerGrens = new Vector2(-2.5f, 6);
        Vector2 rechterGrens = new Vector2(2.5f, 6f);
        transform.position = new Vector2(Random.Range(linkerGrens.x, rechterGrens.x), 6f);
    }

	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, speed, 0);

        if (transform.position.y <= -6f)
        {
            Reset();
        }
    }
}
