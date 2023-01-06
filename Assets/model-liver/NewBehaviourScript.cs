using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Material[] material;
    Renderer rend;
    void Start()
    {
         rend=GetComponent<Renderer>();
        rend.enabled=true;
        rend.sharedMaterial=material[0];
    }

   
    void OnCollisionEnter (Collision col){
        rend.sharedMaterial=material[1];
    }
}
