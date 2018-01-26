using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float offset;
    private Material currentMaterial;
	
	void Start ()
    {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	void Update ()
    {
        offset += speed * Time.deltaTime;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
