using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float hass = 1.5f;
    public float yumusaklik = 1.5f;

    private float xFarePoz;
    private float yumusakFarePoz;

    private float suankiBakmaPoz;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GirisAl();
        GirisiDegistir();
        OyuncuyuHaraketEttir();
    }

    void GirisAl()
    {
        xFarePoz = Input.GetAxisRaw("Mouse X");
    }

    void GirisiDegistir()
    {
        xFarePoz *= hass * yumusaklik;
        yumusakFarePoz = Mathf.Lerp(yumusakFarePoz, xFarePoz, 1f / yumusaklik);
    }

    void OyuncuyuHaraketEttir()
    {
        suankiBakmaPoz += yumusakFarePoz;
        transform.localRotation = Quaternion.AngleAxis(suankiBakmaPoz, transform.up);
    }
}
