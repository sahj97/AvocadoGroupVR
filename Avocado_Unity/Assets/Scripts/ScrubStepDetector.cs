using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

namespace BNG
{
    public class ScrubStepDetector : MonoBehaviour
    {
        [Header("PreScrub Steps Bools")]
        public bool putOnMask;
        public bool putOnGlasses;
        public bool getGloves;
        public bool getGown;
        public bool nailPackageOpen;

        [Header("Checklist UI")]
        public TextMeshProUGUI[] checklistStepsText;
        Color selectedColor;
        Color unselectedColor;

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

            ColorUtility.TryParseHtmlString("#FFFFFF", out selectedColor);
            ColorUtility.TryParseHtmlString("#698782", out unselectedColor);
        }

        void Update(){

        }

        //Checks if requirements for each step are complete and changes color of text on UI Checklist and step count int
        public IEnumerator CheckCurrentStep(){
            yield return new WaitUntil(StepOneDone);
            checklistStepsText[0].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 1;
            Debug.Log("Step 1 done");
            yield return new WaitUntil(StepTwoDone);
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 2;
            Debug.Log("Step 2 done");
            yield return new WaitUntil(StepThreeDone);
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 3;
            Debug.Log("Step 3 done");
        }

        //Bools checking if each step is done so that the coroutine CheckCurrentStep can progress
        bool StepOneDone(){
            if (putOnMask == true){
                return true;}
            else{
                return false;
            }}
        bool StepTwoDone(){
            if (putOnGlasses == true){
                return true;}
            else{
                return false;
            }}
        bool StepThreeDone(){
            if (getGloves == true && getGown == true){
                return true;}
            else{
                return false;
            }}





        public void ScrubStepCounter(){     //not currently in use
            Debug.Log("I am on step " + currentStep);
        }

    }
}
