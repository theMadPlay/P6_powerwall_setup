using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject prefabToSpawnPreview;
    private GameObject currentPreview;

    private void Start()
    {
        prefabToSpawnPreview = prefabToSpawn;
        currentPreview = Instantiate(prefabToSpawnPreview);
    }

    private void Update()
    {
        Ray ray = new Ray(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {

            currentPreview.transform.position = hit.point;
            currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Instantiate(prefabToSpawn, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }
}
