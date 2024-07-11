using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CfInputs
{
    public class CfInputManager : MonoBehaviour
    {
        [SerializeField] private List<CfInput> inputs;

        private void Update()
        {
            foreach (var input in inputs)
            {
                input.InputUpdate(this);
            }
        }
    }
}
