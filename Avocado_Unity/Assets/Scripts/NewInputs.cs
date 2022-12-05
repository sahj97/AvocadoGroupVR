using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BNG
{
    public class NewInputs : MonoBehaviour
    {
        GhostCounter ghostCounterScript;
        ScrubStepDetector scrubStepScript;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputBridge.Instance.AButtonDown && scrubStepScript.playerIsAtSink == true)
            {
                Debug.Log("A Button pressed and player is at sink");
            }
        }


    }
}
