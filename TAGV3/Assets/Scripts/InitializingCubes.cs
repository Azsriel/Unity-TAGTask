using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializingCubes : MonoBehaviour
{
    //References
    public RedCubeScript redCube;
    public BlueCubeScript blueCube;

    //public variables
    public int numberOfCubes;
    public float radius = 20f;


    private void Awake()
    {
        for(int i = 0; i < numberOfCubes; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfCubes;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x,10,z);
            float angleDegree = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0,angleDegree,0);
            if (i%2 == 0 )
            {
                Instantiate<RedCubeScript>(redCube, pos, rot);
                Instantiate<BlueCubeScript>(blueCube, pos + new Vector3(0f, 10, 0f), rot);
                
            }
            else
            {
                Instantiate<BlueCubeScript>(blueCube, pos, rot);
                Instantiate<RedCubeScript>(redCube, pos + new Vector3(0f, 10, 0f), rot);
            }
        }
    }

    public int GetNumberOfCubes()
    {
        return numberOfCubes;
    }

}
