using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class ByeGoo : MonoBehaviour
    {
        //Destroys goo blobs when they come in contact with the sponge
        public void OnCollisionEnter(Collision collision){
            if (collision.gameObject.tag == "sponge"){
                Debug.Log("Goo touched the sponge");
                Destroy(this.gameObject);
            }
        }
    }
}
