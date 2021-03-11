using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pulse : MonoBehaviour
{
    Color defCol;
    Color orange;
    Color green;
    Renderer Mat;
    Enemy enemy;
    PlayerCollision player;
    public Light lPoint;
    float emis;
    // Start is called before the first frame update
    void Start()
    {
        Mat=GetComponent<Renderer>();
        lPoint=GameObject.Find("Point light").GetComponent<Light>();
        defCol=Mat.material.GetColor("_EmissionColor");
        orange=new Color(1.0f, 0.36f, 0.0f, 1.0f);
        green=Color.green;
        if(lPoint!=null)
        //print("yes");
        if(this.gameObject.tag=="Enemy"){
            enemy=this.GetComponent<Enemy>();
            Transform child=transform.GetChild(0);
            lPoint=child.GetComponent<Light>();
        }
        if(this.gameObject.name=="Player"){
            player=this.GetComponent<PlayerCollision>();
            //print(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        emis = Mathf.PingPong(Time.time*10, 5.0F);
        if(this.gameObject.name=="Player"&&player.isHeal==true){
            Mat.material.SetColor("_EmissionColor", green*emis*2);
            lPoint.color=green;
            lPoint.enabled=true;
        }
        else if(this.gameObject.name=="Player"&&player.isBurn==true){
            Mat.material.SetColor("_EmissionColor", orange*emis*2);
            lPoint.color=orange;
            lPoint.enabled=true;
        }
        else if(this.gameObject.tag=="Enemy"&&enemy.EnemyIsBurn==true){
            Mat.material.SetColor("_EmissionColor", orange*emis*2);
            lPoint.color=orange;
            lPoint.enabled=true;
        }
        else{
            Mat.material.SetColor("_EmissionColor", defCol*emis);
            lPoint.enabled=false;
        }
    }
}
