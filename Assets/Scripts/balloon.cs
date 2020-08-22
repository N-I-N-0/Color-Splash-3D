using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour {
    public List<Color> Colors = new List<Color>();
    public float Speed = 0.5f;
    private Light _light;
    private Material _material;

	
	void Start () {
        _light = GetComponent<Light>();
        _material = GetComponent<MeshRenderer>().material;

        int randomIndex = Random.Range(0, Colors.Count);
        var randomColor = Colors[randomIndex];
        _light.color = randomColor;
        _material.color = randomColor;
        _material.SetColor("_EmissionColor", randomColor);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.0f, Speed * Time.deltaTime, 0.0f);
	}
}
