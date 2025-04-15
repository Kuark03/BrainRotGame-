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
        if (!isKapiAcilmak) // Kapý zaten açýksa tekrar açma
        {
            isKapiAcilmak = true;
            kapiAnimation.SetBool("isAcik", isKapiAcilmak);
            StartCoroutine(kapiAcilma());
        }
    }

    IEnumerator kapiAcilma()
    {
        // Animasyon süresi kadar bekle
        yield return new WaitForSeconds(kapiAnimation.GetCurrentAnimatorStateInfo(0).length);

        // Sahneyi yükle
        SceneManager.LoadScene(nextSceneNumber);

        // Kapý açýlma durumunu sýfýrla
        isKapiAcilmak = false;
    }
}
