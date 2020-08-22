using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonspawner : MonoBehaviour {

    public Transform LowerLeftCorner;

    public Transform UpperRightCorner;

    public float TimeUntilNewSpawn = 1.0f;

    public GameObject Prefab;

    private float CurrentTime = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CurrentTime += Time.deltaTime;

        if (CurrentTime > TimeUntilNewSpawn)
        {
            EmitNewBallon();

            CurrentTime = 0.0f;
        }
	}

    void EmitNewBallon()
    {
        float RandX = Random.RandomRange(0.0f, Mathf.Abs(LowerLeftCorner.position.x - UpperRightCorner.position.x));
        float RandZ = Random.RandomRange(0.0f, Mathf.Abs(LowerLeftCorner.position.z - UpperRightCorner.position.z));

        Vector3 NewPosition = LowerLeftCorner.position + new Vector3(RandX, 0, RandZ);

        
        GameObject newballoon = GameObject.Instantiate(Prefab, NewPosition, Quaternion.identity);

        Object.Destroy(newballoon, 15.0f);
    }
    
}
