using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class GhostScript : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "bullett")
            {
                Debug.Log("Bullet hit ghostie");
            }    
        }

    }
}
