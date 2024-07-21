using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog;

namespace Bird
{
    public class DecisionOptionStateSetup : MonoBehaviour, IFsmState<DecisionOption>
    {
        public DecisionOption Owner { get; set; }

        public void Handle(DecisionOption owner)
        {
            Owner = owner;
            
            // owner.Init(this, "Demon Shot");
            owner.SetDisplayNameByFormat(this, "{0}");
        }
    }
}
