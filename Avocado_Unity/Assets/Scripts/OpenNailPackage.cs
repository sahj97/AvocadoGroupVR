using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNailPackage : MonoBehaviour
{
    public GameObject nailPick;
    public GameObject nailBrush;
    public GameObject instantiateNailPick;
    public GameObject instantiateNailBrush;

    public void OpenNailPackageReplace()
    {
        instantiateNailPick = Instantiate(nailPick, nailPick.transform.position, nailPick.transform.rotation);
        instantiateNailBrush = Instantiate(nailBrush, nailBrush.transform.position, nailBrush.transform.rotation);
        Destroy(this.gameObject);
    }

}
