using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{
    public class AvoHelperScript : MonoBehaviour
    {
        public GhostCounter ghostCounterScript;
        public ScrubStepDetector scrubStepScript;

        public Animator doorOR;
        public Animator avoHelper;
        public Animator avoMover;


        //Script for GhostBoss to run on destroy to start animation coroutine
        public void StartAvoCoroutine()
        {
            Debug.Log("Boss destroyed, starting avo coroutine");
            StartCoroutine(BringInTheAvo());
        }   

        //plays Avocado Helper Animations once you defeat the ghost boss and clean ghost goos
        public IEnumerator BringInTheAvo()
        {
            //Plays door opening, avocado walking animations
            Debug.Log("BringInAvo triggered, waiting for goo to be cleaned");
            yield return new WaitUntil(AllGooGone);
            doorOR.Play("ScrubDoorOpen");
            avoHelper.Play("WalkCycle");
            avoMover.Play("MoveAvo");

            //Stops avocado walking, starts coroutine checking scrub-in steps on ScrubStepDetector script
            yield return new WaitForSeconds(5f);
            avoHelper.StopPlayback();
            avoHelper.Play("Wave");
            StartCoroutine(scrubStepScript.CheckCurrentStep());
             
        }

        bool AllGooGone()
        {
            if(ghostCounterScript.numberGoosCleaned == 24){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
