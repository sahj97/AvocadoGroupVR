using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class DetectPlayerSink : MonoBehaviour
    {
        public ScrubStepDetector scrubStepScript;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Trigger detecting if player is standing at the sink or not. We don't want animations to play if not at sink
        public void OnTriggerEnter(Collider floorSpot)
        {
            if (floorSpot.gameObject.tag == "Player")
            {
                scrubStepScript.playerIsAtSink = true;
                Debug.Log("Player is at the sink");
            }
        }
        public void OnTriggerExit(Collider floorSpot)
        {
            if (floorSpot.gameObject.tag == "Player")
            {
                scrubStepScript.playerIsAtSink = false;
                Debug.Log("Player left the sink");
            }
        }

    }
}
