using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkTable : MonoBehaviour
{
    public bool nailPackageOnTable;
    public GameObject sinkUI;

    // Start is called before the first frame update
    void Start(){
        nailPackageOnTable = false;
    }

    public void OnCollisionStay(Collision collision){
        if (collision.gameObject.name == "Grabbable_NailPick&Sponge"){
            nailPackageOnTable = true;
            sinkUI.SetActive(true);
        }
    }

}
