using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG {
    public class WashHandsScript : MonoBehaviour
    {
        public ScrubStepDetector scrubStepDetectorScript;


        //Step 5: Checks if player collides with water and gets soap

        public void OnTriggerEnter(Collider other){
            if (other.gameObject.tag == "Player" && scrubStepDetectorScript.currentStep == 4){
                scrubStepDetectorScript.playerWashingHands = true;
            }
        }

        public void SoapyHands(){
            if (scrubStepDetectorScript.currentStep == 4){
                scrubStepDetectorScript.playerSoapHands = true;
            }
        }


    }
}
