using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed=1f;
    void Start()
    {
        player=GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position+=(player.transform.position-transform.position)*enemySpeed*Time.deltaTime;
    }
}