using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class Sponge : MonoBehaviour
    {
        public GhostCounter ghostCounterScript;
        public AudioSource gooSound;

        //Sponge counts number of ghost goo globs that have been cleaned
        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "goo")
            {
                ghostCounterScript.numberGoosCleaned++;
                gooSound.Play();
                Debug.Log("Eww touch " + ghostCounterScript.numberGoosCleaned + " goos");
            }
        }
    
    }
}
