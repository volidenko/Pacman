using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameMaster master1;
    // Start is called before the first frame update
    void Start()
    {
        master1=GameObject.Find("GameObject").Getcomponent<GameObject>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name=="Enemy"){
            Destroy(other.gameObject);
            master1.enemyCount--;
            print("Enemy fall");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
