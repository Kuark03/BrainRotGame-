using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public GameObject DialogCanvas;
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogText;
    private MouseLook mouseLook;

    void Start()
    {
        sentences = new Queue<string>();
        mouseLook = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>();
    }

    public void StartDialog(Dialog dialog)
    {
        npcNameText.text = dialog.npcName;
        sentences.Clear();

        foreach (string sentence in dialog.sentences) 
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(.1f);
        }
    }

    void EndDialog() 
    {
        Debug.Log("End of Anan");
        DialogCanvas.SetActive(false);
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
