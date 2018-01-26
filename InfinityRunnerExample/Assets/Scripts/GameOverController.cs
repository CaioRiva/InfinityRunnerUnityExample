using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text score;
    [SerializeField]
    private UnityEngine.UI.Text record;

    void Start ()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        record.text = PlayerPrefs.GetInt("record").ToString();
    }
	
	
	void Update ()
    {
		
	}
}
