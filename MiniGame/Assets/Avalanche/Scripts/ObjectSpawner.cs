using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

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
    

    private float waitTime = 10f;

    private float linkerGrens = -2.5f;
    private float rechterGrens = 2.5f;
    private float bovenGrens = 18f;
    private float onderGrens = 6f;


    // Use this for initialization
    void Start () {
        SpawnObject(tree_01, tree_02, steen, treeStomp, ramp);
        StartCoroutine(SpawnYeti());
	}

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
