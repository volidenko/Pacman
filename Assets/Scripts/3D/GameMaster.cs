using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public int playerScore=0;
    public int enemyCount=4;
    public int playerLive=100;
    public GameObject btn;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GameObject.Find("EnemySmasher").GetСomponent<Rigidbody>;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount==0) {
            btn.SetActive(true);
        }
        if(playerScore>=10 && rb.isKinematic==true) {
           rb.isKinematic=false;
        }
        playerLive=Mathf.Clamp(playerLive, 0, 100);
        print(playerLive);
    }



    // void Update()
    // {
    //     if(playerScore==40||enemyCount==0) {
    //         btn.SetActtive(true);
    //         print("Win");
    //     }
    // }
}