using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchanger : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer _rendererHeart;

    public GameObject obj;

    public Texture2D tex;
    void Start()
    {
        _rendererHeart=obj.GetComponent<Renderer>();
        _rendererHeart.material.SetTexture("_Maintex",tex);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
