using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeScript : MonoBehaviour
{
    public GameObject sphere;
    public GameFlow gameflow;

    GameFlow script;


    public void Awake()
    {
        gameflow = FindObjectOfType<GameFlow>();
        script = gameflow.GetComponent<GameFlow>();
        sphere = GameObject.Find("Sphere");
    }

    public void Damage()
    {
        Destroy(gameObject);
        Debug.Log("Correct");
        script.correct = true;
    }
    
    public void transformIntoSphere()
    {
        Debug.Log("Wrong");
        script.wrong = true;
        Instantiate(sphere,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Red")
        {
            Destroy(collision.gameObject);
            Damage();
        }
        else
        {
            Destroy(collision.gameObject);
            transformIntoSphere();
        }
    }
}
