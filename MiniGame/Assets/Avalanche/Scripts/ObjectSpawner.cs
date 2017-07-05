using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    /// <summary>
    /// These field are here to load GameObjects into these variables
    /// The number of GameObject are also loaded to variables
    /// Only the yeti GameObject is loaded differently
    /// </summary>

    [SerializeField]
    private int numTree01;
    [SerializeField]
    private GameObject tree_01;

    [SerializeField]
    private int numTree02;
    [SerializeField]
    private GameObject tree_02;

    [SerializeField]
    private int numSteen;
    [SerializeField]
    private GameObject steen;

    [SerializeField]
    private int numTreeStomp;
    [SerializeField]
    private GameObject treeStomp;

    [SerializeField]
    private int numRamp;
    [SerializeField]
    private GameObject ramp;

    [SerializeField]
    private GameObject yeti;
    
    /// <summary>
    /// waitTime is the time it takes to spawn another yeti
    /// The borders are ment to indicate a region in which a GameObject can be spawned
    /// </summary>
    private float waitTime = 10f;

    private float linkerGrens = -2.5f;
    private float rechterGrens = 2.5f;
    private float bovenGrens = 18f;
    private float onderGrens = 6f;


    /// <summary>
    /// Start initiates the spawning process
    /// StartCoroutine spawns a yeti every waitTime seconds
    /// </summary>
    void Start () {
        SpawnObject(tree_01, tree_02, steen, treeStomp, ramp);
        StartCoroutine(SpawnYeti());
	}

    /// <summary>
    /// The reason this code looks redundant is because every time an object is spawned it needs to get a new position
    /// Else where would have been many GameObjects spawned at the same location
    /// </summary>
    /// <param name="tree_01">A tall tree</param>
    /// <param name="tree_02">A short tree</param>
    /// <param name="steen">A rock</param>
    /// <param name="treeStomp">A cut down tree</param>
    /// <param name="ramp">A potential ramp. Maybe in the future a ramp can be made out of this object</param>
    public void SpawnObject(GameObject tree_01, GameObject tree_02, GameObject steen, GameObject treeStomp, GameObject ramp)
    {
        for (int i = 0; i < numTree01; i++)
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            Instantiate(tree_01, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }

        for (int i = 0; i < numTree02; i++)
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            Instantiate(tree_02, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }

        for (int i = 0; i < numSteen; i++)
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            Instantiate(steen, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }

        for (int i = 0; i < numTreeStomp; i++)
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            Instantiate(treeStomp, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }

        for (int i = 0; i < numRamp; i++)
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            Instantiate(ramp, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }
    }

    /// <summary>
    /// This IEnumerator creates a range in which it can later spawn a yeti
    /// It waits a waitTime amount of seconds
    /// When it will instantiate the prefab yeti on the coordinates from the generated range
    /// transform.rotation is nessecary in order to avoid errors
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnYeti()
    {
        while (SceneManager.GetActiveScene().name == "Avalanche")
        {
            float xPositie = Random.Range(linkerGrens, rechterGrens);
            float yPositie = Random.Range(bovenGrens, onderGrens);
            yield return new WaitForSeconds(waitTime);
            Instantiate(yeti, new Vector3(xPositie, yPositie, 0f), transform.rotation);
        }
    }
}
