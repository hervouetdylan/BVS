using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMan : MonoBehaviour
{

    private GameObject man;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(man, transform.position, Quaternion.identity);
    }
}
