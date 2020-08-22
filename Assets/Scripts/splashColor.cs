using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setColor(Color _Color) {
        gameObject.GetComponent<MeshRenderer>().material.color = _Color;
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", _Color);
        gameObject.GetComponent<Light>().color = _Color;
    }
}
