using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace BNG
{
    public class AvoHelperScript : MonoBehaviour
    {
        [Header("Scripts")]
        public GhostCounter ghostCounterScript;
        public ScrubStepDetector scrubStepScript;

        [Header("Animations")]
        public Animator doorOR;
        public Animator avoHelper;
        public Animator avoMover;

        [Header("UI")]
        public GameObject avoSpeakUI;
        public TextMeshProUGUI stepOne;
        public Color selectColor;

        private void Start(){
            ColorUtility.TryParseHtmlString("#FFFFFF", out selectColor);
        }

        //Script for GhostBoss to run on destroy to start animation coroutine
        public void StartAvoCoroutine(){
            Debug.Log("Boss destroyed, starting avo coroutine");
            StartCoroutine(BringInTheAvo());
        }   

        //plays Avocado Helper Animations once you defeat the ghost boss and clean ghost goos
        public IEnumerator BringInTheAvo(){
            //Plays door opening, avocado walking animations
            Debug.Log("BringInAvo triggered, waiting for goo to be cleaned");
            yield return new WaitUntil(AllGooGone);
            doorOR.Play("ScrubDoorOpen");
            avoHelper.Play("WalkCycle");
            avoMover.Play("MoveAvo");

            //Stops avocado walking, starts coroutine checking scrub-in steps on ScrubStepDetector script, & highlights first step
            yield return new WaitForSeconds(5f);
            avoHelper.StopPlayback();
            avoHelper.Play("Wave");
            StartCoroutine(scrubStepScript.CheckCurrentStep());
            stepOne.GetComponent<TextMeshProUGUI>().color = selectColor;
        }

        bool AllGooGone(){
            if(ghostCounterScript.numberGoosCleaned == 24){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
