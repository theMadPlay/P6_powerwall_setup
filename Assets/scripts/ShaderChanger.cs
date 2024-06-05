using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Meta.XR.MRUtilityKit;

public class ShaderChanger : MonoBehaviour
{
    // Array of shaders to cycle through
    public Material[] materials;
    bool HitOnce = false;


    // Rigidbody component of the ball
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (materials == null || materials.Length == 0)
        {
            Debug.LogError("No shaders assigned!");
        }
    }

    // This method is called when the ball collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Get the renderer component of the object the ball collided with
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        if(renderer == null)
        {
            collision.gameObject.AddComponent<Renderer>();
        }

        // If the object has a renderer and there are shaders to choose from
        if (renderer != null && materials.Length > 0)
        {
            // Apply the new shader to the object's material
            renderer.material = materials[Random.Range(0, materials.Length)];
        }

        if (!HitOnce)
        {
            HitOnce = true;

            //Change Text
            TMP_Text textField = GameObject.Find("LeftHandInfoText").GetComponent<TMP_Text>();
            if (textField != null) textField.text = "Hit a" + collision.collider.name + collision.collider.tag;//string.Join("", collision.collider.GetComponent<MRUKAnchor>().AnchorLabels);
        }
    }
}
