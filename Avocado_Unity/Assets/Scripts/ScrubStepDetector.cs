using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BNG
{
    public class ScrubStepDetector : MonoBehaviour
    {
        public GameObject[] checkListItemsUI;

        [Header("PreScrub Steps")]
        public bool putOnMask;
        public bool putOnGlasses;
        public bool getGloves;
        public bool getGown;

        [Header ("Scrubbing Animation")]
        public bool playerIsAtSink;
        public int currentStep;
        public GameObject[] stepAnimation;
        public int[] numberTimesPerStep;

        void Start(){
            putOnMask = false;
            putOnGlasses = false;
            getGloves = false;
            getGown = false;
            playerIsAtSink = false;
        }

        void Update(){

        }

        //Trigger detecting if player is standing at the sink or not. We don't want animations to play if not at sink
        public void OnTriggerEnter(Collider floorSpot){
            if (floorSpot.gameObject.name == "FloorSpot"){
                playerIsAtSink = true;
                Debug.Log("Player is at the sink");
            }
        }
        public void OnTriggerExit(Collider floorSpot){
            if (floorSpot.gameObject.name == "FloorSpot"){
                playerIsAtSink = false;
                Debug.Log("Player left the sink");
            }
        }

    }
}
