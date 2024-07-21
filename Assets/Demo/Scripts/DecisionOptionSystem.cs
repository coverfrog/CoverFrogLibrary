using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bird
{
    public class DecisionOptionSystem : MonoBehaviour
    {
        private enum Direction
        {
            Up = -1,
            Down = +1,
        }
        
        //
        
        [SerializeField] private List<DecisionOption> decisionOptionList;

        private int _selectedIndex;

        //

        private void MoveIndex(Direction direction)
        {
            var prevIndex = _selectedIndex;
            var nextIndex = Mathf.Clamp(_selectedIndex + (int)direction, 0, decisionOptionList.Count - 1);

            SetIndex(prevIndex, nextIndex);
        }

        private void MoveIndex(int nextIndex)
        {
            if (nextIndex >= decisionOptionList.Count || nextIndex < 0)
            {
                return;
            }

            var prevIndex = _selectedIndex;

            SetIndex(prevIndex, nextIndex);
        }

        private void SetIndex(int prevIndex, int nextIndex)
        {
            decisionOptionList[prevIndex].ToUnSelected();
            decisionOptionList[nextIndex].ToSelectedState();

            _selectedIndex = nextIndex;
        }

        //
        
        private void Awake()
        {
            _selectedIndex = 0;
        }

        private void OnEnable()
        {
            MoveIndex(_selectedIndex);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
                MoveIndex(Direction.Up);
            
            if(Input.GetKeyDown(KeyCode.DownArrow))
                MoveIndex(Direction.Down);
        }
    }
}
