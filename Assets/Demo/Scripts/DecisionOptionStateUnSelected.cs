using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog;

namespace Bird
{
    public class DecisionOptionStateUnSelected : MonoBehaviour, IFsmState<DecisionOption>
    {
        public DecisionOption Owner { get; set; }

        public void Handle(DecisionOption owner)
        {
            Owner = owner;

            owner.SetDisplayNameByFormat(this, "{0}");
        }
    }
}
