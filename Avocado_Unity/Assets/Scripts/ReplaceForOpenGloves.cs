using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceForOpenGloves : MonoBehaviour
{
    public GameObject openGloves;
    public GameObject instantiateOpenGloves;

    public void ReplacePackageForOpen()
    {
        instantiateOpenGloves = Instantiate(openGloves, this.transform.position, openGloves.transform.rotation);
        Destroy(this.gameObject);
    }

}
