using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseSpawn : MonoBehaviour
{

    [SerializeField] GameObject rosePerfab;
    [SerializeField] Transform spawnTransform;
    void Start()
    {
        Instantiate(rosePerfab, spawnTransform.position,Quaternion.identity);
    }

   
}
