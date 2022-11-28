using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace BNG
{
    public class NewInputs : MonoBehaviour
    {
        GhostCounter ghostCounterScript;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InputBridge.Instance.AButtonDown && ghostCounterScript.allGooGones == true)
            {
                Debug.Log("A Button pressed in scrub room");
            }
        }


    }
}
