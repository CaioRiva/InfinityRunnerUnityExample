using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        Screen.SetResolution(320, 480, false);

        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("mainScene");
        }
	}
}
