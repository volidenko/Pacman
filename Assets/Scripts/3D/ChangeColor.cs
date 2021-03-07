using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] mat_s;
    public void OnMouseDown() {
        gameObject.GetComponent<Renderer>().material=mat_s[Random.Range(0, mat_s.Length)];
    }
}