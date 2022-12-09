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
        public bool getGlovesOpen;
        public bool getGownOpen;
        public bool nailPackageOpen;
        public bool playerWashingHands;
        public bool playerSoapHands;
        public bool playerIsAtSink;

        [Header("Checklist UI")]
        public int currentStep;
        public TextMeshProUGUI[] checklistStepsText;
        Color selectedColor;
        Color unselectedColor;

        [Header("Scrubbing Animation")]
        public GameObject animationHolder;
        public GameObject[] stepAnimation;
        public bool[] animationStepPlayed;


        //Make sure none of the steps are accidentally checked off before starting
        void Start(){
            currentStep = 0;
            putOnMask = false;
            putOnGlasses = false;
            getGlovesOpen = false;
            getGownOpen = false;
            nailPackageOpen = false;
            playerWashingHands = false;
            playerSoapHands = false;
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
            yield return new WaitUntil(StepFourDone);
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 4;
            Debug.Log("Step 4 done");
            yield return new WaitUntil(StepFiveDone);
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[5].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 5;
            animationHolder.SetActive(true);
            Debug.Log("Step 5 done");
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
            if (getGlovesOpen == true && getGownOpen == true){
                return true;}
            else{
                return false;
            }}
        bool StepFourDone(){
            if (nailPackageOpen == true){
                return true;
            }
            else{
                return false;
            }}
        bool StepFiveDone(){
            if (playerSoapHands == true && playerWashingHands == true){
                return true;
            }
            else{
                return false;
            }}





        public void ScrubStepCounter(){     //not currently in use
            Debug.Log("I am on step " + currentStep);
        }

    }
}
