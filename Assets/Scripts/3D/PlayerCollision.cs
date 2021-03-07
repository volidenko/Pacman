using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    GameMaster master;
    public GameObject btnLose;

    // Start is called before the first frame update
    void Start()
    {
        master=GameObject.Find("GameMaster").GetComponent<GameMaster>();
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
            StartCoroutine("Burn");
        }
        if (other.gameObject.name=="Water"){
            StopCoroutine("Burn");
        }
        if (other.gameObject.name=="Health"){
            StartCoroutine("Heal");
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="Health"){
            StopCoroutine("Heal");
        }
    }

                // master.playerLive-=2;
                // yield return new WaitForSeconds(2.0f);



        IEnumerator Heal(){
            while(true){
                master.playerLive+=2;
                print(master.playerLive);
                yield return new WaitForSeconds(2.0f);
            }
    }
}