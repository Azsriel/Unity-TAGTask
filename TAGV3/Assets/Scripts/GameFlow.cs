using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public GameObject OpenDoor;
    public GameObject CloseDoor;
    public GameObject exit1;
    public GameObject exit2;
    public InitializingCubes cubes;
    public GameObject cleanSphere;

    InitializingCubes script;
    private int TotalTargets;
    public int NumberOfTargetsHit = 0;
    public bool correct;
    public bool wrong;

    private void Awake()
    {
        script = cubes.GetComponent<InitializingCubes>();
        TotalTargets = script.numberOfCubes * 2;
        correct = false;
        wrong = false;
        OpenDoor.SetActive(false);
        CloseDoor.SetActive(true);
        exit1.SetActive(false);
        exit2.SetActive(false);
    }

    private void Update()
    {
        
        if (correct)
        {
            NumberOfTargetsHit++;
            correct = false;
        }
        if (wrong)
        {
            wrong = false;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync("EndFailScene");
        }
        
        if(NumberOfTargetsHit >= TotalTargets) 
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
            for(int i = 0; i < TotalTargets/2; ++i)
            {
                cleanSphere = GameObject.Find("Sphere(Clone)");
                Destroy(cleanSphere);
            }
            exit1.SetActive(true);
            exit2.SetActive(true);
        }
    }


}
