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
        public bool playerWashedHands;
        public bool playerSoapHands;
        public bool playerIsAtSink;

        [Header("Checklist UI")]
        public int currentStep;
        public TextMeshProUGUI[] checklistStepsText;
        Color selectedColor;
        Color unselectedColor;

        [Header("Scrubbing Animation")]
        public GameObject floorSpot;
        public GameObject animationHolder;
        public GameObject[] stepAnimation;
        public int[] numberTimesPerStep;
        public GameObject successFeedbackUI;
        public AudioSource successSound;
        public GameObject nextButtonUI;
        //public bool[] animationStepPlayed;
        
        public NewInputs myInputScript;


        //Make sure none of the steps are accidentally checked off before starting
        void Start(){
            currentStep = 0;
            putOnMask = false;
            putOnGlasses = false;
            getGlovesOpen = false;
            getGownOpen = false;
            nailPackageOpen = false;
            playerWashedHands = false;
            playerSoapHands = false;
            playerIsAtSink = false;

            ColorUtility.TryParseHtmlString("#FFFFFF", out selectedColor);
            ColorUtility.TryParseHtmlString("#698782", out unselectedColor);
        }

        void Update(){

        }

        //Checks if requirements for each step are complete and changes color of text on UI Checklist and step count int
        public IEnumerator CheckCurrentStep(){
            //Prescrub steps with objects
            yield return new WaitUntil(StepOneDone);
            checklistStepsText[0].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 1;
            Debug.Log("Step 0 done");
            yield return new WaitUntil(StepTwoDone);
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 2;
            Debug.Log("Step 1 done");
            yield return new WaitUntil(StepThreeDone);
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 3;
            Debug.Log("Step 2 done");
            yield return new WaitUntil(StepFourDone);
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 4;
            floorSpot.SetActive(true);
            Debug.Log("Step 3 done");
            yield return new WaitUntil(StepFiveDone);
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[5].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 5;
            animationHolder.SetActive(true);
            Debug.Log("Step 4 done");

            //Scrub Animation Steps                                             //instead these yeild returns need to turn on UI success and next button, which will run functions that they curretnly say

            //Step 5: Nail Pick Animation 1 
            yield return new WaitUntil(NailPickAnim1Done);
            stepAnimation[0].SetActive(false);
            stepAnimation[1].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep = 6;
            //Step 6: Nail Pick Animation 2 
            Debug.Log("Nail Pick Anim 1 done");
            yield return new WaitUntil(NailPickAnim2Done);
            stepAnimation[1].SetActive(false);
            stepAnimation[2].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[5].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[6].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 7;
            //Step 7: Nail Sponge Animation 1
            Debug.Log("Nail Pick Anim 2 done");
            yield return new WaitUntil(NailSpongeAnim1Done);
            stepAnimation[2].SetActive(false);
            stepAnimation[3].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep = 8;
            Debug.Log("Nail Sponge Anim 1 done");
            //Step 8: Nail Sponge Animation 2
            yield return new WaitUntil(NailSpongeAnim2Done);
            stepAnimation[3].SetActive(false);
            stepAnimation[4].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[6].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[7].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 9;
            Debug.Log("Nail Sponge Anim 2 done");
            //Step 9: Nail Brush Animation 1
            yield return new WaitUntil(NailBrushAnim1Done);






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
            if (playerSoapHands == true && playerWashedHands == true){
                return true;
            }
            else{
                return false;
            }}
        bool NailPickAnim1Done(){
            if (currentStep == 5 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[0]){
                return true;
            }
            else{
                return false;
            }}
        bool NailPickAnim2Done(){
            if (currentStep == 6 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[1]){
                return true;
            }
            else{
                return false;
            }}
        bool NailSpongeAnim1Done(){
            if (currentStep == 7 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[2]){ 
                return true; 
            }
            else{
                return false;
            }}
        bool NailSpongeAnim2Done(){
            if (currentStep == 8 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[3]){
                return true;
            }
            else{
                return false;
            }}
        bool NailBrushAnim1Done(){
            if (currentStep == 9 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[4]){
                return true;
            }
            else{
                return false;
            }}







    }





    
}
