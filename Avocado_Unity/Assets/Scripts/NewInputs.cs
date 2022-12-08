using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BNG
{
    public class NewInputs : MonoBehaviour
    {
        public ScrubStepDetector scrubStepScript;

        public Grabber rightHandGrabber;
        public Grabber leftHandGrabber;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputBridge.Instance.AButtonDown)
            {
                Debug.Log("A Button has been pressed");

                if (rightHandGrabber.HeldGrabbable != null)
                {
                    if(scrubStepScript.currentStep == 0 && rightHandGrabber.HeldGrabbable.gameObject.name == "Grabbable_Mask")
                    {
                        Debug.Log("Pressed A while holding mask (step1)");
                        scrubStepScript.putOnMask = true;

                        StartCoroutine(scrubStepScript.CheckCurrentStep());
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
