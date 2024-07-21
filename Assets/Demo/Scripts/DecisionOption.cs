using System;
using System.Collections;
using System.Collections.Generic;
using CoverFrog;
using UnityEngine;
using TMPro;
using Object = UnityEngine.Object;

namespace Bird
{
    public class DecisionOption : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textDisplayName;

        [SerializeField]
        private string _displayName;
        
        //

        private IFsmState<DecisionOption> 
            _inActiveState, _unSelectedState, _selectedState;
        
        private FsmContext<DecisionOption> _context;

        private FsmContext<DecisionOption> Context
            => _context ??= InitContext();

        private FsmContext<DecisionOption> InitContext()
        {
            _context = new FsmContext<DecisionOption>(this);

            _inActiveState = gameObject.AddComponent<DecisionOptionStateInActive>();
            _unSelectedState = gameObject.AddComponent<DecisionOptionStateUnSelected>();
            _selectedState = gameObject.AddComponent<DecisionOptionStateSelected>();
            
            _context.Transition(_inActiveState);

            return _context;
        }

        public void ToInactive() => Context.Transition(_inActiveState);
        
        public void ToUnSelected() => Context.Transition(_unSelectedState);
        
        public void ToSelectedState() => Context.Transition(_selectedState);
        
        //

        public void InitDisplayName(Object sender, string displayName)
        {
            _displayName = displayName;
        }

        public void SetDisplayNameByFormat(Object sender, string displayNameFormat)
        {
            textDisplayName.text = string.Format(displayNameFormat, _displayName);
        }
        
        //

        private void Awake()
        {
            _ = Context;
        }
    }
}
