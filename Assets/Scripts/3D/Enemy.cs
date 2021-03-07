using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyLive=100;
    GameMaster master;
    public bool EnemyIsBurn=false;
    Light flash;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HealEnemy");
        master=GameObject.Find("GameMaster").GetComponent<GameMaster>();
        Transform child = transform.GetChild(1);
        flash=child.GetComponent<Light>();
        print(flash);
        flash.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        enemyLive=Mathf.Clamp(enemyLive, 0, 100);
        if (enemyLive==0)
        {
            master.enemyCount--;
            flash.enabled=true;
            StartCoroutine("FlashTime");
            // Destroy(this.gameObject);
            // print(master.enemyCount);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name=="EnemySmasher"){
            // Destroy(collision.gameObject);
            // master1.enemyCount--;
            // print("Enemy fall");
            enemyLive-=10;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name=="Fire"){
            EnemyIsBurn=true;
            StartCoroutine("BurnEnemy");
            StopCoroutine("HealEnemy");
        }
        if (other.gameObject.name=="Water"){
            StopCoroutine("BurnEnemy");
            EnemyIsBurn=false;
            StartCoroutine("HealEnemy");
        }
    }

    IEnumerator BurnEnemy(){
        while(true){
            enemyLive-=4;
            yield return new WaitForSeconds(2.0f);
        }    
    }
    IEnumerator HealEnemy(){
        while(true){
            enemyLive++;
            yield return new WaitForSeconds(2.0f);
        }    
    }
    IEnumerator FlashTime(){
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        StopCoroutine("FlashTime");
    }
}
