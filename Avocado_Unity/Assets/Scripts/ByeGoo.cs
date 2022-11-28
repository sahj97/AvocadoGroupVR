using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class ByeGoo : MonoBehaviour
    {
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
            if (collision.gameObject.tag == "sponge")
            {
                Debug.Log("Goo touched the sponge");
                Destroy(this.gameObject);
            }
        }
    }
}
