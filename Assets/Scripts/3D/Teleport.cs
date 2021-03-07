using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private GameObject g1;
    private GameObject g2;

    // Start is called before the first frame update
    void Start()
    {
        g1=GameObject.Find("Teleport1");
        g2=GameObject.Find("Teleport2");
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name=="Player"){
            if(this.name=="Teleport1"){
                other.transform.position=g2.transform.position-new Vector3(5,0,0);
                print(other.transform.position);
            }
            if(this.name=="Teleport2"){
                other.transform.position=g1.transform.position+new Vector3(5,0,0);
                print(other.transform.position);
            }
        }
    }
}