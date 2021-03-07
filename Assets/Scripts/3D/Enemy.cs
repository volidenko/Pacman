using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyLive=100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyLive=Mathf.Clamp(enemyLive, 0, 100);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name=="EnemySmasher"){
            Destroy(collision.gameObject);
            master1.enemyCount--;
            print("Enemy fall");
            enemyLive-=100;
        }
    }
}
