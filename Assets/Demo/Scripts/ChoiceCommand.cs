using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bird
{
    [Serializable]
    public class Choice
    {
        [SerializeField] private string codeName;
        [SerializeField] private int index;
    }

    public class ChoiceCommand : MonoBehaviour
    {
        [SerializeField] private List<Choice> choiceList;
    }
}
