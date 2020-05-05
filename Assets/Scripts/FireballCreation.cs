using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCreation : MonoBehaviour
{
    public GameObject fireballPrefab;
    private GameObject fireTree;
    public float respawnTime = 1.0f;
    void Start()
    {
        fireTree = transform.gameObject;
        StartCoroutine(fireWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(fireballPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(fireTree.transform.position.x-2, fireTree.transform.position.x+2),fireTree.transform.position.y);
        a.transform.localScale = new Vector2(1.6f,1.6f);
    }
    IEnumerator fireWave()
    {
        while(true) 
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
