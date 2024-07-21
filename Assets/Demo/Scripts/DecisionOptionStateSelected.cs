using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog;

namespace Bird
{
    public class DecisionOptionStateSelected : MonoBehaviour, IFsmState<DecisionOption>
    {
        public DecisionOption Owner { get; set; }

        public void Handle(DecisionOption owner)
        {
            Owner = owner;

            owner.SetDisplayNameByFormat(this, "> {0}");
        }
    }
}
