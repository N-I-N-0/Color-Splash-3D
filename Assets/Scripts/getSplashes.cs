using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSplashes : MonoBehaviour {
    public Text text;
    int splashes;

	// Use this for initialization
	void Start () {
        splashes = PlayerPrefs.GetInt("score");
        text.text = string.Format("Du hast {0} Splashes hinterlassen!", splashes);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
