using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public RemainingBalls remainingBalls;
    public float Intensity = 1.0f;
    public bool isColored = false;
    public GameObject splash;
    public int lifes = 3;
    public float Lifetime = 10.0f;
    public int HitsWithShield = 0;
    int splashes = 0;

    public Transform BallSpawnerPoint;

    public float TimeUntilHitShield = 0.0f;

    // Use this for initialization
    void Start()
    {
        transform.position = BallSpawnerPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilHitShield += Time.deltaTime;

        changeLifesAndSplashes();

        if (TimeUntilHitShield > Lifetime)
        {
            TimeUntilHitShield = 0.0f;

            ResetBall();
        }
    }
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (isColored)
            {
                isColored = false;

                GameObject NewSplash = GameObject.Instantiate(splash, collision.contacts[0].point, Quaternion.identity);

                NewSplash.transform.forward = collision.gameObject.transform.forward;

                NewSplash.GetComponent<splashmanager>().SetColor(GetComponent<MeshRenderer>().material.color);

                gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

                gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);

                gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward, ForceMode.Impulse);

                float randomRotation = Random.Range(0f,360f);

                Quaternion currentRotation = NewSplash.transform.localRotation;

                NewSplash.transform.Rotate(0.0f, 0.0f, randomRotation);

                splashes++;
            }
        }
        else if (collision.gameObject.CompareTag("Game Over"))
        {
            ResetBall();

            lifes--;

            changeLifesAndSplashes();

            if (lifes <= 0)
            {
                GameObject.Destroy(gameObject);

                PlayerPrefs.SetInt("score", splashes);

                splashes = 0;

                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            Vector3 RotationOfShield = other.gameObject.transform.forward;

            //float randomRotation = Random.Range(0f, 2.25f);

            //RotationOfShield = RotationOfShield * randomRotation;

            ResetMovement();

            gameObject.GetComponent<Rigidbody>().AddForce(RotationOfShield * (Intensity + Mathf.Max(0.0f, HitsWithShield) / 20.0f), ForceMode.Impulse);

            TimeUntilHitShield = 0.0f;

            ++HitsWithShield;
        }
        else if (other.gameObject.CompareTag("Balloon"))
        {
            gameObject.GetComponent<MeshRenderer>().material = other.gameObject.GetComponent<MeshRenderer>().material;

            isColored = true;

            GameObject.Destroy(other.gameObject);
        }
    }

    private void ResetMovement()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void ResetBall()
    {
        ResetMovement();

        transform.position = BallSpawnerPoint.position;

        gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);

        isColored = false;

        HitsWithShield = 0;
    }

    public void changeLifesAndSplashes()
    {
        remainingBalls.SetRemainingBalls(lifes, splashes);
    }
}