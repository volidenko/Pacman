using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour {
    public int playerScore=0;
    [SerializeField]
    public int enemyCount=3;
    public int playerLive=100;
    public GameObject btn;
    public Rigidbody rb;
    public bool isWin=false;
    Light dLight;
    Color blue;
    Color colDef;
    // Start is called before the first frame update
    void Start()
    {
        dLight=GameObject.Find("Directional Light").GetComponent<Light>();
        rb=GameObject.Find("EnemySmasher").GetComponent<Rigidbody>();
        blue=Color.blue;
        colDef=dLight.color;
        print(enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        print(playerScore);
        if(enemyCount==0||playerScore>20) {
            btn.SetActive(true);
            print("Win");
            isWin=true;
        }
        if(playerScore>=10 && rb.isKinematic==true) {
           rb.isKinematic=false;
           StartCoroutine("BlueHalo");
        }
        if (playerScore==0)
        {
            print("Lose");
        }

        playerLive=Mathf.Clamp(playerLive, 0, 100);
        //print(playerLive);
    }
    IEnumerator BlueHalo(){
        dLight.color=blue;
        yield return new WaitForSeconds(10.0f);
        dLight.color=colDef;
        StopCoroutine("BlueHalo");
    }


    // void Update()
    // {
    //     if(playerScore==40||enemyCount==0) {
    //         btn.SetActtive(true);
    //         print("Win");
    //     }
    // }
}