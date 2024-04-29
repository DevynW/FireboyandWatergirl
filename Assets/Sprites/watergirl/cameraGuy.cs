using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

public class cameraGuy : MonoBehaviour
{
    [SerializeField] GameObject WaG;
    [SerializeField] GameObject FiB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3 ((WaG.transform.position.x + FiB.transform.position.x)/2, (WaG.transform.position.y + FiB.transform.position.y) / 2, gameObject.transform.position.z);
       // Camera.
    }
}
