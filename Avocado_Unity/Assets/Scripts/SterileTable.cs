using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterileTable : MonoBehaviour
{
    public bool glovesONTable;
    public bool gownONTable;

    // Start is called before the first frame update
    void Start(){
        glovesONTable = false;
        gownONTable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Seeing if glove packet is on the prep table
    public void OnCollisionStay(Collision collision){
        if (collision.gameObject.name == "Grabbable_GlovePack"){
            glovesONTable = true;
            //have glove UI pop up
            Debug.Log("gloves are on the table");
        }
        if (collision.gameObject.name == "Grabbable_GownPack"){
            gownONTable = true;
            Debug.Log("gown is on the table");
        }
    }
}
