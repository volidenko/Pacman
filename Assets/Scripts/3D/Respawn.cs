using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    float dist=0f;
    public Transform pl;
    public GameObject child;
    private bool activ=false;
    private int enemyCount=3;
    // Start is called before the first frame update
    void Start()
    {
        pl=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist=Vector3.Distance(pl.transform.position, transform.position);
        if(dist<15&&activ==false){
            //child.SetActive(true);
            activ=true;
            StartCoroutine("SpawnEnemy");
            print("open");
        }
    }
    IEnumerator SpawnEnemy(){
        if(enemyCount>0){
            Instantiate(pref, transform.position, Quaternion.identity);
            print("enemyspawn");
            yield return new WaitForSeconds(3.0f);
            activ=false;
            enemyCount--;
        }
        StopCoroutine("SpawnEnemy");
        print("close");
    }
}
