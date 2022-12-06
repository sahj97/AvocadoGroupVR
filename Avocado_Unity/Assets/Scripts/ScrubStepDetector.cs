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
        public Animator[] stepAnimsAnimators;
        public int[] numberTimesPerStep;

        void Start(){
            putOnMask = false;
            putOnGlasses = false;
            getGloves = false;
            getGown = false;
            playerIsAtSink = false;
            currentStep = 0;
        }

        void Update(){

        }

        public void StepCounter()
        {

        }

    }
}
