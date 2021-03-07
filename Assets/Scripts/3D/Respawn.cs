using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    float dist=0f;
    private GameObject pl;
    public GameObject pref;
    private bool activ=false;
    private int enemyCount=3;
    Color white;
    Renderer Mat;
    // Start is called before the first frame update
    void Start()
    {
        pl=GameObject.Find("Player");
        Mat=GetComponent<Renderer>();
        white=Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        dist=Vector3.Distance(pl.transform.position, transform.position);
        if(dist<15&&activ==false){
            //child.SetActive(true);
            activ=true;
            StartCoroutine("SpawnEnemy");
            //print("open");
            if(enemyCount==0)
            Mat.material.SetColor("_EmissionColor", white);
        }
    }
    IEnumerator SpawnEnemy(){
        if(enemyCount>0){
            Instantiate(pref, transform.position, Quaternion.identity);
            enemyCount--;
            //print("enemyspawn");
            if(enemyCount==0)
                Mat.material.SetColor("_EmissionColor", white);
            yield return new WaitForSeconds(3.0f);
            activ=false;
        }
        StopCoroutine("SpawnEnemy");
        print("close");
    }
}