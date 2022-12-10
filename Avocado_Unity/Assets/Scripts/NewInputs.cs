using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BNG
{
    public class NewInputs : MonoBehaviour
    {
        [Header("Referencing Other Scipts")]
        public ScrubStepDetector scrubStepScript;
        public SterileTable sterileTableScript;
        public ReplaceForOpenGloves replaceOpenGlovesScript;
        public SinkTable sinkTableScript;
        public OpenNailPackage openNailPackageScript;

        [Header("AudioSources")]
        public AudioSource objectOnNoise;
        public AudioSource correctNoise;
        public AudioSource walkingNoise;
        public AudioSource scrubSound;

        [Header("Scrub Steps")]
        public Grabber rightHandGrabber;
        public Grabber leftHandGrabber;
        public Animator[] stepAnimsAnimators;
        public int timesPressedAPerStep;

        public void Start(){
            timesPressedAPerStep = 0;
        }

        // Update is called once per frame
        void Update(){

            //Plays walking sound when L Thumbstick held down
            if (InputBridge.Instance.LeftThumbstick){
                walkingNoise.Play();
            }


            if (InputBridge.Instance.AButtonDown)                                                                                       
            {
                //Checking if player is holding anything in R hand while pressing A
                if (rightHandGrabber.HeldGrabbable != null)
                {
                    //Step 0: Checks if holding mask in hand to "put on"
                    if (scrubStepScript.currentStep == 0 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Mask"){
                        Debug.Log("Pressed A while holding mask (step1)");
                        scrubStepScript.putOnMask = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                        Destroy(rightHandGrabber.HeldGrabbable.gameObject);
                    }
                    //Step 1: Checks if holding glasses in hand to "put on"
                    if (scrubStepScript.currentStep == 1 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Glasses"){
                        Debug.Log("Pressed A while holding glasses (step2)");
                        scrubStepScript.putOnGlasses = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                        Destroy(rightHandGrabber.HeldGrabbable.gameObject);
                    }
                    //Step 5: Nail Pick Animation 1 while holding nail pick at sink
                    if (scrubStepScript.currentStep == 5 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailPick(Clone)"){
                        stepAnimsAnimators[0].Play("1NailPickAnim");
                        timesPressedAPerStep++;
                        //progress bubble color? array of color and assign [timesPressedA]? Or slider progress might be easier and more intuitive to player
                    }
                    //Step 6: Nail Pick Animation 2 while holding nail pick at sink
                    if (scrubStepScript.currentStep == 6 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailPick(Clone)"){
                        stepAnimsAnimators[1].Play("1NailPickFlipAnim");
                        timesPressedAPerStep++;
                        //progress bubble color? array of color and assign [timesPressedA]
                    }
                    //Step 7: Nail Sponge Animation 1 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 7 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)") {
                        stepAnimsAnimators[2].Play("2.5AroundFingersAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 8: Nail Sponge Animation 2 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 8 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)"){
                        stepAnimsAnimators[3].Play("2.5.2AroundFingerFlipAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 9: Nail Brush Animation 1 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 9 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[4].Play("4NailBrushAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 10: Nail Brush Animation 2 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 9 && scrubStepScript.playerIsAtSink == true && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[5].Play("5NailBrushFlipAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }

                }


                //Checking if player is holding anything in L hand while pressing A
                if (leftHandGrabber.HeldGrabbable != null)
                {
                    //Step 0: Checks if holding mask in hand to "put on"
                    if (scrubStepScript.currentStep == 0 && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Mask")
                    {
                        Debug.Log("Pressed A while holding mask (step1)");
                        scrubStepScript.putOnMask = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                        Destroy(leftHandGrabber.HeldGrabbable.gameObject);
                    }
                    //Step 1: Checks if holding glasses in hand to "put on"
                    if (scrubStepScript.currentStep == 1 && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Glasses")
                    {
                        Debug.Log("Pressed A while holding glasses (step2)");
                        scrubStepScript.putOnGlasses = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                        Destroy(leftHandGrabber.HeldGrabbable.gameObject);
                    }
                    //Step 5: Nail Pick Animation 1 while holding nail pick at sink
                    if (scrubStepScript.currentStep == 5 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailPick(Clone)")
                    {
                        stepAnimsAnimators[0].Play("1NailPickAnim");
                        timesPressedAPerStep++;
                    }
                    //Step 6: Nail Pick Animation 2 while holding nail pick at sink
                    if (scrubStepScript.currentStep == 6 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailPick(Clone)")
                    {
                        stepAnimsAnimators[1].Play("1NailPickFlipAnim");
                        timesPressedAPerStep++;
                    }
                    //Step 7: Nail Sponge Animation 1 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 7 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[2].Play("2.5AroundFingersAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 8: Nail Sponge Animation 2 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 8 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[3].Play("2.5.2AroundFingerFlipAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 9: Nail Brush Animation 1 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 9 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[4].Play("4NailBrushAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }
                    //Step 10: Nail Brush Animation 2 while holding nail brush at sink
                    if (scrubStepScript.currentStep == 9 && scrubStepScript.playerIsAtSink == true && leftHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_NailSponge(Clone)")
                    {
                        stepAnimsAnimators[5].Play("5NailBrushFlipAnim");
                        scrubSound.Play();
                        timesPressedAPerStep++;
                    }


                }




                //Steps that don't involve Player having something in their hands while pressing A

                //Step 2: Checks if gown packet is on prep table to "open"
                //if (scrubStepScript.currentStep == 2 && sterileTableScript.gownONTable == true)
                //{
                //    scrubStepScript.getGownOpen = true;
                //    // replace item with open model??       //dont have open model so just using detection on table as perameter
                //}
                //Step 2: Checks if glove packet is on prep table to "open" and model swap
                if (scrubStepScript.currentStep == 2 && sterileTableScript.glovesONTable == true && scrubStepScript.getGlovesOpen == false){
                    scrubStepScript.getGlovesOpen = true;
                    replaceOpenGlovesScript.ReplacePackageForOpen();
                    Debug.Log("Pressed A to swap glove pack for open gloves");
                }
                //Step 3: Checks if nail pick and brush package is on sink counter to "open"
                if (scrubStepScript.currentStep == 3 && sinkTableScript.nailPackageOnTable == true){
                    scrubStepScript.nailPackageOpen = true;
                    openNailPackageScript.OpenNailPackageReplace();
                }
                //Step 12: Palm Open Animation
                if(scrubStepScript.currentStep == 12 && scrubStepScript.playerRESoapHands == true && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[6].Play("6SoapPalmsAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 13: L over R Animation
                if (scrubStepScript.currentStep == 13 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[7].Play("7LHandOverRAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 14: R over L Animation
                if (scrubStepScript.currentStep == 14 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[8].Play("8RHandOverLAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 15: Palm Fingers Interlaced Animation
                if (scrubStepScript.currentStep == 15 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[9].Play("9PalmsInterlaceAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 16: Interlock Palms Animation
                if (scrubStepScript.currentStep == 16 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[10].Play("10InterlockAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 17: Rotate Thumb Animation
                if (scrubStepScript.currentStep == 17 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[11].Play("11RotateThumbAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 18: Flip Rotate Other Thumb Animation
                if (scrubStepScript.currentStep == 18 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[12].Play("12RotatThumbFlip");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 19: Clasp Fingers 1 Animation
                if (scrubStepScript.currentStep == 19 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[13].Play("13ClaspFingersAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }
                //Step 20: Flip Clasp Fingers 2 Animation
                if (scrubStepScript.currentStep == 20 && scrubStepScript.playerIsAtSink == true){
                    stepAnimsAnimators[14].Play("14ClaspFingersFlipAnim");
                    scrubSound.Play();
                    timesPressedAPerStep++;
                }



            }


        }

    }
}
