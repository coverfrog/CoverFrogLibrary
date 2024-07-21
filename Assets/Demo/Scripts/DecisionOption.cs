using System;
using System.Collections;
using System.Collections.Generic;
using CoverFrog;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
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
            _setupState, _unSelectedState, _selectedState;
        
        private FsmContext<DecisionOption> _context;

        private FsmContext<DecisionOption> Context
            => _context ??= InitContext();

        private FsmContext<DecisionOption> InitContext()
        {
            _context = new FsmContext<DecisionOption>(this);

            _setupState = gameObject.AddComponent<DecisionOptionStateSetup>();
            _unSelectedState = gameObject.AddComponent<DecisionOptionStateUnSelected>();
            _selectedState = gameObject.AddComponent<DecisionOptionStateSelected>();
            
            _context.Transition(_setupState);

            return _context;
        }
        
        public void ToUnSelected() => Context.Transition(_unSelectedState);
        
        public void ToSelectedState() => Context.Transition(_selectedState);
        
        //

        public void SetDisplayName(Object sender, string displayName)
        {
            _displayName = displayName;
        }

        public void SetDisplayNameByFormat(Object sender, string displayNameFormat)
        {
            textDisplayName.text = string.Format(displayNameFormat, _displayName);
        }

        public void SetButtonAction(Object sender, UnityAction<DecisionOption> onMoveIndex)
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                onMoveIndex.Invoke(this);
            });
        }
        
        //

        private void Awake()
        {
            _ = Context;
        }
    }
}
