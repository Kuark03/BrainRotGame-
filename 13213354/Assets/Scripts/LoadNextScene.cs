using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour, IInteractable
{
    public int nextSceneNumber;
    public Animator kapiAnimation;
    private bool isKapiAcilmak;

    public void Interact()
    {
        if (!isKapiAcilmak) // Kap� zaten a��ksa tekrar a�ma
        {
            isKapiAcilmak = true;
            kapiAnimation.SetBool("isAcik", isKapiAcilmak);
            StartCoroutine(kapiAcilma());
        }
    }

    IEnumerator kapiAcilma()
    {
        // Animasyon s�resi kadar bekle
        yield return new WaitForSeconds(kapiAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Sahneyi y�kle
        SceneManager.LoadScene(nextSceneNumber);

        // Kap� a��lma durumunu s�f�rla
        isKapiAcilmak = false;
    }
}
