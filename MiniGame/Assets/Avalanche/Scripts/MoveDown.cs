using UnityEngine;

public class MoveDown : MonoBehaviour {

    [SerializeField]
    private float speed = -0.1f;
    [SerializeField]
    private float speedUp = 0.01f;

    /// <summary>
    /// These borders are made to make sure the object does not move out of these bounds
    /// Then a transform.position will reset the object into these borders when they move out of the screen
    /// After they have been reset, they will move down again
    /// </summary>
    public void Reset()
    {
        Vector2 linkerGrens = new Vector2(-2.5f, 6);
        Vector2 rechterGrens = new Vector2(2.5f, 6f);
        transform.position = new Vector2(Random.Range(linkerGrens.x, rechterGrens.x), 6f);
    }

    /// <summary>
    /// The transform.position makes the object move down in a vertical line, since only the y axis is affected
    /// If the object moves out of screen, the objects transform.position will be reset
    /// </summary>
    void Update()
    {
        //the position of the object constantly moves down
        transform.position += new Vector3(0, speed, 0);

        if (transform.position.y <= -6f)
        {
            Reset();
        }
    }
}
