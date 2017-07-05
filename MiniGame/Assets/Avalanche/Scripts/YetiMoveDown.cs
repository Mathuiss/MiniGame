using UnityEngine;

public class YetiMoveDown : MonoBehaviour
{

    [SerializeField]
    private float speed = -0.1f;
    [SerializeField]
    private float speedUp = 0.01f;

    /// <summary>
    /// This class does the same thing as MoveDown except for the reset
    /// Once the yeti is out of the screen it will stay there untill the scene is reloaded
    /// The prefab cannot be destroyed since it will not be able to spawn in the IEnumerator in SpawnObstacle
    /// </summary>
    public void Reset()
    {
        Vector2 linkerGrens = new Vector2(-2.5f, 6);
        Vector2 rechterGrens = new Vector2(2.5f, 6f);
        transform.position = new Vector2(Random.Range(linkerGrens.x, rechterGrens.x), 6f);

    }

    // Update is called once per frame
    void Update()
    {
        //the position of the object constantly moves down
        transform.position += new Vector3(0, speed, 0);
    }
}
