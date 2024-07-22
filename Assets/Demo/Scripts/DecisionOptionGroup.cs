using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog;

namespace Bird
{
    [RequireComponent(typeof(VerticalScrollToMove))]
    public class DecisionOptionGroup : MonoBehaviour
    {
        private enum Direction
        {
            Up = -1,
            Down = +1,
        }

        //

        [SerializeField] private List<DecisionOption> decisionOptionList;

        private VerticalScrollToMove _verticalScrollToMove;
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

        private void MoveIndex(DecisionOption decisionOption)
        {
            var prevIndex = _selectedIndex;
            var nextIndex = decisionOption.transform.GetSiblingIndex();

            SetIndex(prevIndex, nextIndex);
        }

        private void SetIndex(int prevIndex, int nextIndex)
        {
            decisionOptionList[prevIndex].ToUnSelected();
            decisionOptionList[nextIndex].ToSelectedState();

            _selectedIndex = nextIndex;
            _verticalScrollToMove.ToIndex(_selectedIndex, 100);
        }

        //

        private void Awake()
        {
            _selectedIndex = 0;
            _verticalScrollToMove = GetComponent<VerticalScrollToMove>();
            
            decisionOptionList.ForEach(x =>
            {
                x.SetButtonAction(this, MoveIndex);
            });
        }

        private void OnEnable()
        {
            MoveIndex(_selectedIndex);
        }

        private void Start()
        {
        
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
