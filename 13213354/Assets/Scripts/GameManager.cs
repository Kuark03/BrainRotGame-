using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RenderCanvas;
    public GameObject Capsule;
    public GameObject FpsCanvas;

    private void Start()
    {
        FpsCanvas.SetActive(false);
        StopAllCoroutines();
        RenderCanvas.SetActive(true);
        Capsule.SetActive(false);
        StartCoroutine(beklemeSuresi());
    }

    IEnumerator beklemeSuresi()
    {
        yield return new WaitForSeconds(1f);
        FpsCanvas.SetActive(true);
    }
}
