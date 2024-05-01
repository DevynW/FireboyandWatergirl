using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

public class cameraGuy : MonoBehaviour
{
    [SerializeField] GameObject WaG;
    [SerializeField] GameObject FiB;
    [SerializeField] float zoomFac = 1f;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Debug.Log (cam.orthographicSize.ToString ());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3 ((WaG.transform.position.x + FiB.transform.position.x)/2, (WaG.transform.position.y + FiB.transform.position.y) / 2, gameObject.transform.position.z);
        cam.orthographicSize = zoomFac * Vector3.Distance(WaG.transform.position, FiB.transform.position);
        if (cam.orthographicSize < 5)
        {
            cam.orthographicSize = 5;
        }
        if (cam.orthographicSize > 18)
        {
            cam.orthographicSize = 18;
        }
    }
}
