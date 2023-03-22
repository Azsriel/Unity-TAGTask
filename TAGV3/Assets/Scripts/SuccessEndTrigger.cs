using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessEndTrigger : MonoBehaviour
{
    public GameObject floor;
    public bool working = false;

    private void OnTriggerEnter(Collider other)
    {
        working = true;
        floor.SetActive(false);
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(3);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("EndSuccessScreen");
    }



}
