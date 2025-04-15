using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Animator fistAnim;
    public Animator KeyboardAnim;
    public GameObject Merrrrrmi;
    public TextMeshProUGUI AmmoCount;
    public bool isSmashingKeys;
    public int mermi = 25;
    public bool isReloading;
    private bool isShooting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isShooting) // Sadece isShooting false ise
        {
            StartCoroutine(Shoot());
        }
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            isSmashingKeys = false;
        }
        fistAnim.SetBool("isSmashTheKeys", isSmashingKeys);
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        MermiHarcama();
        isSmashingKeys = true;

        // Animasyon süresini bekle
        yield return new WaitForSeconds(fistAnim.GetCurrentAnimatorStateInfo(0).length);

        isShooting = false; // Animasyon tamamlandýðýnda isShooting'i false yap
    }

    void MermiHarcama()
    {
        if (mermi > 0)
        {
            mermi--;
            AmmoCount.text = mermi.ToString();
            if (mermi == 5 || mermi == 10 || mermi == 15 || mermi == 20)
            {
                KeyboardAnim.SetInteger("AmmoCount", mermi);
            }
        }
        else
        {
            isReloading = true;
        }
    }
}
