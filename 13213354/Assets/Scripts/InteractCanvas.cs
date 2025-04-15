using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCanvas : MonoBehaviour
{
    public GameObject Canvas;
    public Transform PlayerTransform;
    public float Range;

    private void Update()
    {
        Ray ray = new Ray(PlayerTransform.position, PlayerTransform.forward);
        RaycastHit hitler; 
        if (Physics.Raycast(ray, out hitler, Range))
        {
            if (hitler.collider.gameObject.CompareTag("InteractableShit"))
            {
                Canvas.SetActive(true);
            }
        }
        else
        {
            Canvas.SetActive(false);
        }
    }
}
