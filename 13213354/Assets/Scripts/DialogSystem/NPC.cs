using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public Dialog dialog;
    public GameObject DialogCanvas;
    private MouseLook mouseLook;

    private void Start()
    {
        mouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();  
    }

    public void TriggerDialog()
    {
        FindAnyObjectByType<DialogManager>().StartDialog(dialog);
    }

    public void Interact()
    {
        TriggerDialog();
        DialogCanvas.SetActive(true);
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
