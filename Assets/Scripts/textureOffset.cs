using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureOffset : MonoBehaviour
{
    
    public string textureName = "_MainTex";
    private float animRate = 1.5f;
    private float uvOffset2;
    void LateUpdate()
    {
        uvOffset2 += animRate * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset(textureName, new Vector2(0,uvOffset2));
       
    }
}