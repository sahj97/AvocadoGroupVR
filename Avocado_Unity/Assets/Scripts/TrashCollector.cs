using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    public AudioSource trashSound;
    public bool nailPickInTrash;
    public bool nailBrushInTrash;
    public bool somethingElseInTrash;

    // Start is called before the first frame update
    void Start(){
        nailPickInTrash = false;
        nailBrushInTrash = false;
        somethingElseInTrash = false;
    }

    public void OnTriggerStay(Collider other){
        if (other.gameObject.name == "Grabbable_NailPick(Clone)"){
            nailPickInTrash = true;
            Debug.Log("nail pick in trash");
        }
        else if (other.gameObject.name == "Grabbable_NailSponge(Clone)"){
            nailBrushInTrash = true;
            Debug.Log("nail brush in trash");
        }
        else{
            somethingElseInTrash = true;
            Debug.Log("what else did you put in the trash??");
        }
    }

}
