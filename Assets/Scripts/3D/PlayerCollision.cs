using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    GameMaster master;
    public GameObject btnLose;
    public bool isBurn=false;
    public bool isHeal=false;
    Pulse light1;

    // Start is called before the first frame update
    void Start()
    {
        master=GameObject.Find("GameMaster").GetComponent<GameMaster>();
        light1=GameObject.Find("Player").GetComponent<Pulse>();

    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag=="Enemy"){
            //btnLose.SetActive(true);
            master.playerLive-=10;
            //print("master.playerLive");
            //print ("Lose");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Crystall"){
            Destroy(other.gameObject);
            master.playerScore++;
            //print(master.playerScore);
        }
        if (other.gameObject.name=="Fire"){
            isBurn=true;
            StartCoroutine("Burn");
        }
        if (other.gameObject.name=="Water"){
            isBurn=false;
            light1.lPoint.enabled=false;
            StopCoroutine("Burn");
        }
        if (other.gameObject.name=="Health"){
            isHeal=true;
            StartCoroutine("Heal");
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="Health"){
            isHeal=false;
            light1.lPoint.enabled=false;
            StopCoroutine("Heal");
        }
    }

    IEnumerator Heal(){
        while(true){
            master.playerLive+=2;
            print(master.playerLive);
            yield return new WaitForSeconds(2.0f);
        }    
    }

    IEnumerator Burn(){
        while(true){
            master.playerLive-=2;
            print(master.playerLive);
            yield return new WaitForSeconds(2.0f);
        }    
    }
}