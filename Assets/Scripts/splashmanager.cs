using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashmanager : MonoBehaviour {

    public GameObject[] Splashes;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(Color _Color)
    {
        foreach(GameObject Splash in Splashes)
        {
            Splash.GetComponent<splashColor>().setColor(_Color);
        }
    }
}
