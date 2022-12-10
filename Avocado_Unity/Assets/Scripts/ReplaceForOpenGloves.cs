using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceForOpenGloves : MonoBehaviour
{
    public GameObject openGloves;
    public GameObject instantiateOpenGloves;
    public GameObject tableUI;
    public AudioSource openSound;

    public void ReplacePackageForOpen()
    {
        openSound.Play();
        instantiateOpenGloves = Instantiate(openGloves, this.transform.position, openGloves.transform.rotation);
        Destroy(this.gameObject);
        tableUI.SetActive(false);
    }

}
