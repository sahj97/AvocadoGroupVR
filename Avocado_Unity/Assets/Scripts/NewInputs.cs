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

        [Header("AudioSources")]
        public AudioSource objectOnNoise;
        public AudioSource correctNoise;

        // Update is called once per frame
        void Update(){
            if (InputBridge.Instance.AButtonDown)
{
                Debug.Log("A Button has been pressed");

                //Checking if player is holding anything in R hand while pressing A
                if (rightHandGrabber.HeldGrabbable != null)
{
                    if (scrubStepScript.currentStep == 0 && rightHandGrabber.HeldGrabbable.gameObject.tag == "Grabbable_Mask"){
                        Debug.Log("Pressed A while holding mask (step1)");
                        scrubStepScript.putOnMask = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                        Destroy()
                    }
                    if (scrubStepScript.currentStep == 1 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Glasses"){
                        Debug.Log("Pressed A while holding glasses (step2)");
                        scrubStepScript.putOnGlasses = true;
                        objectOnNoise.Play();
                        correctNoise.Play();
                    }
                    


                }



                if (scrubStepScript.playerIsAtSink == true)
                {
                    Debug.Log("A Button pressed and player is at sink");
                    scrubStepScript.ScrubStepCounter();
                }


                //Steps that don't involve Player having something in their hands while pressing A
                if (scrubStepScript.currentStep == 2 && sterileTableScript.glovesONTable == true)
                {
                    scrubStepScript.getGloves = true;
                    // replace item with open model
                }
                if (scrubStepScript.currentStep == 2 && sterileTableScript.gownONTable == true)
                {
                    scrubStepScript.getGown = true;
                    // replace item with open model
                }

            }
            
        }

    }
}
