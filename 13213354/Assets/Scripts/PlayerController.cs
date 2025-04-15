using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float playerRUNNIGASpeed = 15f;
    private float playerCurrentSpeed;
    private CharacterController pCC;
    public Animator camAnim;
    public Animator fistAnim;
    public Animator keyboardAnim;
    private bool isYarru;

    private Vector3 alVector;
    private Vector3 yarVector;
    private float gravITy = -9.81f;


    private void Start()
    {
        playerCurrentSpeed = playerSpeed;
        pCC = GetComponent<CharacterController>();
    }
    private void Update()
    {
        KosNigaKos();
        Alavere();
        Yarru();
        YouKariAssaKaraDassa();

        camAnim.SetBool("isYarruing", isYarru);
        fistAnim.SetBool("isWalking", isYarru);
        keyboardAnim.SetBool("isWalking", isYarru);
    }

    void Alavere()
    {
        alVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        alVector.Normalize();
        alVector = transform.TransformDirection(alVector);

        yarVector = (alVector * playerCurrentSpeed) + (Vector3.up * gravITy);
    }

    void Yarru()
    {
        pCC.Move(yarVector * Time.deltaTime);
    }

    void KosNigaKos()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
           playerCurrentSpeed = playerRUNNIGASpeed;
        }
        else
        {
            playerCurrentSpeed = playerSpeed;
        }
    }

    void YouKariAssaKaraDassa()
    {
        if (pCC.velocity.magnitude > 0.1)
        {
            isYarru = true;
        }
        else
        {
            isYarru = false;
        }
    }
}
