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
        public bool playerRESoapHands;
        public bool playerREWetHands;
        public bool playerRinseHands;

        [Header("Checklist UI")]
        public int currentStep;
        public TextMeshProUGUI[] checklistStepsText;
        Color selectedColor;
        Color unselectedColor;
        public GameObject cabinetUI;
        public GameObject tableUI;
        public GameObject sinkTableUI;

        [Header("Scrubbing Animation")]
        public GameObject floorSpot;
        public GameObject animationUIHelp;
        public GameObject animationHolder;
        public GameObject[] stepAnimation;
        public int[] numberTimesPerStep;
        public Animator successFeedbackUI;
        public AudioSource successSound;
        public GameObject nextButtonHolder;
        public GameObject[] nextButtonUI;

        public NewInputs myInputScript;
        public TrashCollector trashScript;
        public SterileTable sterileTableScript;


        //Make sure none of the steps are accidentally checked off before starting
        void Start() {
            currentStep = 0;
            putOnMask = false;
            putOnGlasses = false;
            getGlovesOpen = false;
            getGownOpen = false;
            nailPackageOpen = false;
            playerWashedHands = false;
            playerSoapHands = false;
            playerIsAtSink = false;
            playerRESoapHands = false;
            playerREWetHands = false;
            playerRinseHands = false;

            ColorUtility.TryParseHtmlString("#FFFFFF", out selectedColor);
            ColorUtility.TryParseHtmlString("#698782", out unselectedColor);
        }

        void Update() {

        }

        //Checks if requirements for each step are complete
        public IEnumerator CheckCurrentStep() {

            //Prescrub steps with objects > changes color of text on UI Checklist and step count int
            yield return new WaitUntil(MaskOn);
            checklistStepsText[0].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = selectedColor;
            successSound.Play();
            currentStep = 1;
            Debug.Log("Checklist 1 done");
            yield return new WaitUntil(GlassesOn);
            checklistStepsText[1].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = selectedColor;
            cabinetUI.SetActive(false);
            successSound.Play();
            currentStep = 2;
            Debug.Log("Checklist 2 done");
            yield return new WaitUntil(GlovesAndGown);
            checklistStepsText[2].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = selectedColor;
            successSound.Play();
            tableUI.SetActive(false);
            currentStep = 3;
            Debug.Log("Checklist 3 done");
            yield return new WaitUntil(NailPackageOpened);
            checklistStepsText[3].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = selectedColor;
            successSound.Play();
            sinkTableUI.SetActive(false);
            currentStep = 4;
            floorSpot.SetActive(true);
            Debug.Log("Checklist 4 done");
            yield return new WaitUntil(WashedHands);
            checklistStepsText[4].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[5].GetComponent<TextMeshProUGUI>().color = selectedColor;
            successSound.Play();
            currentStep = 5;
            animationHolder.SetActive(true);
            animationUIHelp.SetActive(true);
            Debug.Log("Checklist 5 done");


            //Scrub Animation Steps > turn on next UI buttons so code doesn't automatically jump to next step before animation finished playing        
            //Step 5: Nail Pick Animation 1 
            yield return new WaitUntil(NailPickAnim1Done);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonHolder.SetActive(true);
            Debug.Log("Nail Pick Anim 1 done");

            //Step 6: Nail Pick Animation 2 
            yield return new WaitUntil(NailPickAnim2Done);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[1].SetActive(true);
            Debug.Log("Checklist 6 done");

            //Step 7: Nail Sponge Animation 1
            yield return new WaitUntil(NailSpongeAnim1Done);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonUI[2].SetActive(true);
            Debug.Log("Nail Sponge Anim 1 done");

            //Step 8: Nail Sponge Animation 2
            yield return new WaitUntil(NailSpongeAnim2Done);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[3].SetActive(true);
            Debug.Log("Checklist 7 done");

            //Step 9: Nail Brush Animation 1
            yield return new WaitUntil(NailBrushAnim1Done);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonUI[4].SetActive(true);
            Debug.Log("Nail Brush Anim 1 done");

            //Step 10: Nail Brush Animation 2
            yield return new WaitUntil(NailBrushAnim2Done);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[5].SetActive(true);
            Debug.Log("Checklst 8 done");

            //Step 11: Throw away nail pick and brush
            yield return new WaitUntil(ThrownAway);
            successSound.Play();
            checklistStepsText[8].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[9].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep = 12;
            Debug.Log("Checklist 9 done");

            //Step 12: Open Palm Animation
            yield return new WaitUntil(SoapPalmAnimDone);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[6].SetActive(true);
            Debug.Log("Checklst 10 done");

            //Step 13: L over R Animation
            yield return new WaitUntil(LoverRDone);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonUI[7].SetActive(true);

            //Step 14: R over L Animation
            yield return new WaitUntil(RoverLDone);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[8].SetActive(true);
            Debug.Log("Checklst 11 done");

            //Step 15: Palm Interlace Fingers Animation
            yield return new WaitUntil(PalmInterlaceDone);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[9].SetActive(true);
            Debug.Log("Checklst 12 done");

            //Step 16: Palm Interlock Scrub Animation
            yield return new WaitUntil(InterlockDone);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[10].SetActive(true);
            Debug.Log("Checklst 13 done");

            //Step 17: Rotate Thumb 1 Animation
            yield return new WaitUntil(RotateThumb1Done);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonUI[11].SetActive(true);
            Debug.Log("Rotate Thumb 1 done");

            //Step 18: Rotate Thumb 2 Animation
            yield return new WaitUntil(RotateThumb2Done);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[12].SetActive(true);
            Debug.Log("Checklist 14 done");

            //Step 19: Clasp Fingers 1 Animation
            yield return new WaitUntil(ClaspFingers1Done);
            successFeedbackUI.Play("ShowSuccess");
            //successSound.Play();
            nextButtonUI[13].SetActive(true);
            Debug.Log("Clasp Fingers 1 done");

            //Step 20: Clasp Fingers 2 Animation
            yield return new WaitUntil(ClaspFingers2Done);
            successFeedbackUI.Play("ShowSuccess");
            successSound.Play();
            nextButtonUI[14].SetActive(true);
            Debug.Log("Checklist 15 done");




        }


        //Bools checking if each step is done so that the coroutine CheckCurrentStep can progress
        bool MaskOn() {
            if (putOnMask == true) {
                return true; }
            else {
                return false;
            } }
        bool GlassesOn() {
            if (putOnGlasses == true) {
                return true; }
            else {
                return false;
            } }
        bool GlovesAndGown() {
            if (getGlovesOpen == true && sterileTableScript.gownONTable == true) {
                return true; }
            else {
                return false;
            } }
        bool NailPackageOpened() {
            if (nailPackageOpen == true) {
                return true;
            }
            else {
                return false;
            } }
        bool WashedHands() {
            if (playerSoapHands == true && playerWashedHands == true) {
                return true;
            }
            else {
                return false;
            } }
        bool NailPickAnim1Done() {
            if (currentStep == 5 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[0]) {
                return true;
            }
            else {
                return false;
            } }
        bool NailPickAnim2Done() {
            if (currentStep == 6 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[1]) {
                return true;
            }
            else {
                return false;
            } }
        bool NailSpongeAnim1Done() {
            if (currentStep == 7 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[2]) {
                return true;
            }
            else {
                return false;
            } }
        bool NailSpongeAnim2Done() {
            if (currentStep == 8 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[3]) {
                return true;
            }
            else {
                return false;
            } }
        bool NailBrushAnim1Done() {
            if (currentStep == 9 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[4]) {
                return true;
            }
            else {
                return false;
            } }
        bool NailBrushAnim2Done(){
            if (currentStep == 10 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[5]){
                return true;
            }
            else{
                return false;
            }}
        bool ThrownAway(){
            if (currentStep == 11 && trashScript.nailBrushInTrash == true && trashScript.nailPickInTrash == true){
                return true;
            }
            else{
                return false;
            }}
        bool SoapPalmAnimDone(){
            if (currentStep == 12 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[6]){
                return true;
            }
            else{
                return false;
            }}
        bool LoverRDone(){
            if (currentStep == 13 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[7]){
                return true;
            }
            else{
                return false;
            }}
        bool RoverLDone(){
            if (currentStep == 14 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[8]){
                return true;
            }
            else{
                return false;
            }}
        bool PalmInterlaceDone(){
            if (currentStep == 15 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[9]){
                return true;
            }
            else{
                return false;
            }}
        bool InterlockDone(){
            if (currentStep == 16 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[10]){ 
                return true; }
            else { 
                return false; 
            }}
        bool RotateThumb1Done(){
            if (currentStep == 17 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[11]){
                return true;
            }
            else{
                return false;
            }}
        bool RotateThumb2Done(){
            if (currentStep == 18 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[12]){
                return true;
            }
            else{
                return false;
            }}
        bool ClaspFingers1Done(){
            if (currentStep == 19 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[13]){
                return true;
            }
            else{
                return false;
            }}
        bool ClaspFingers2Done(){
            if (currentStep == 20 && myInputScript.timesPressedAPerStep >= numberTimesPerStep[14]){
                return true;
            }
            else{
                return false;
            }}




        //Functions run by Next UI button > turns off current animation, turns on next animation gameobject, resets pressedA int and advances step# int
        
        //After Step 5: Nail Pick Animation 1 
        public void Animation0NextButton(){
            stepAnimation[0].SetActive(false);
            stepAnimation[1].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }
        //After Step 6: Nail Pick Animation 2 
        public void Animation1NextButton(){
            stepAnimation[1].SetActive(false);
            stepAnimation[2].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[5].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[6].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }
        //After Step 7: Nail Sponge Animation 1
        public void Animation2NextButton(){
            stepAnimation[2].SetActive(false);
            stepAnimation[3].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }
        //After Step 8: Nail Sponge Animation 2
        public void Animation3NextButton(){
            stepAnimation[3].SetActive(false);
            stepAnimation[4].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[6].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[7].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }
        //After Step 9: Nail Brush Animation 1
        public void Animation4NextButton(){
            stepAnimation[4].SetActive(false);
            stepAnimation[5].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }
        //After Step 10: Nail Brush Animation 2
        public void Animation5NextButton(){
            stepAnimation[5].SetActive(false);
            stepAnimation[6].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[7].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[8].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 12: Soap Palm Animation
        public void Animation6NextButton(){
            stepAnimation[6].SetActive(false);
            stepAnimation[7].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[9].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[10].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 13: L over R Animation
        public void Animation7NextButton(){
            stepAnimation[7].SetActive(false);
            stepAnimation[8].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }

        //After Step 14: R over L Animation
        public void Animation8NextButton()
        {
            stepAnimation[8].SetActive(false);
            stepAnimation[9].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[10].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[11].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 15: Palms Interlaced Fingers Animation
        public void Animation9NextButton()
        {
            stepAnimation[9].SetActive(false);
            stepAnimation[10].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[11].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[12].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 16: Interlocked Palms Scrub Animation
        public void Animation10NextButton()
        {
            stepAnimation[10].SetActive(false);
            stepAnimation[11].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[12].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[13].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 17: Rotate Thumb 1 Animation
        public void Animation11NextButton()
        {
            stepAnimation[11].SetActive(false);
            stepAnimation[12].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }

        //After Step 18: Rotate Thumb 2 Animation
        public void Animation12NextButton()
        {
            stepAnimation[12].SetActive(false);
            stepAnimation[13].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[13].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[14].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }

        //After Step 19: Clasp Fingers 1 Animation
        public void Animation13NextButton()
        {
            stepAnimation[13].SetActive(false);
            stepAnimation[14].SetActive(true);
            myInputScript.timesPressedAPerStep = 0;
            currentStep++;
        }

        //After Step 20: Clasp Fingers 2 Animation
        public void LastAnimation()
        {
            stepAnimation[14].SetActive(false);
            myInputScript.timesPressedAPerStep = 0;
            checklistStepsText[14].GetComponent<TextMeshProUGUI>().color = unselectedColor;
            checklistStepsText[15].GetComponent<TextMeshProUGUI>().color = selectedColor;
            currentStep++;
        }



    }
    
}
