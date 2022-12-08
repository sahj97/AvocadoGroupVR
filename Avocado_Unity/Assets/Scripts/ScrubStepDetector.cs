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

        //Make sure none of the steps are accidentally checked off before starting
        void Start(){
            currentStep = 0;
            putOnMask = false;
            putOnGlasses = false;
            getGloves = false;
            getGown = false;
            playerIsAtSink = false;
        }

        void Update(){

        }


        public IEnumerator CheckCurrentStep()
        {
            yield return new WaitUntil(StepOneDone);
        }

        //Bools checking if each step is done so that the coroutine CheckCurrentStep can progress
        bool StepOneDone(){
            if (putOnMask == true){
                return true;
            }
            else{
                return false;
            }
        }


        public void ScrubStepCounter()
        {
            Debug.Log("I am on step " + currentStep);
        }

    }
}
