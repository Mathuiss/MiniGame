using System.Collections;
using System.Collections.Generic;
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
    

    private float waitTime = 1f;


	// Use this for initialization
	void Start () {
        SpawnObject(tree_01, tree_02);
	}


    public void SpawnObject(GameObject tree_01, GameObject tree_02)
    {
        float linkerGrens = -2.5f;
        float rechterGrens = 2.5f;
        float bovenGrens = 18f;
        float onderGrens = 6f;

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
    }
}
