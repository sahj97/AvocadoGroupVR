using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class Sponge : MonoBehaviour
    {
        public GhostCounter ghostCounterScript;
        public AudioSource gooSound;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "goo")
            {
                ghostCounterScript.numberGoosCleaned++;
                gooSound.Play();
                //Destroy(collision.gameObject);
                Debug.Log("Eww touch " + ghostCounterScript.numberGoosCleaned + " goos");
                AllGooGone();
            }
        }

        public void AllGooGone()
        {
            if (ghostCounterScript.numberGoosCleaned == 25)
            {
                ghostCounterScript.allGooGones = true;
                ghostCounterScript.BringInTheAvo();
            }
        }    
    }
}
