using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BNG
{
    public class NewInputs : MonoBehaviour
    {
        public ScrubStepDetector scrubStepScript;
        public SterileTable sterileTableScript;

        public Grabber rightHandGrabber;
        public Grabber leftHandGrabber;


        // Update is called once per frame
        void Update(){
            if (InputBridge.Instance.AButtonDown)
{
                Debug.Log("A Button has been pressed");

                //Checking if player is holding anything in R hand while pressing A
                if (rightHandGrabber.HeldGrabbable != null)
{
                    if (scrubStepScript.currentStep == 0 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Mask"){
                        Debug.Log("Pressed A while holding mask (step1)");
                        scrubStepScript.putOnMask = true;
                    }
                    if (scrubStepScript.currentStep == 1 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Glasses"){
                        Debug.Log("Pressed A while holding glasses (step2)");
                        scrubStepScript.putOnGlasses = true;
                    }
                    if (scrubStepScript.currentStep == 2 && sterileTableScript.glovesONTable == true)
                    {
                        scrubStepScript.getGloves = true;
                        // replace item with open model
                    }


                }




                if (scrubStepScript.playerIsAtSink == true)
                {
                    Debug.Log("A Button pressed and player is at sink");
                    scrubStepScript.ScrubStepCounter();
                }


            }
            
        }


    }
}
