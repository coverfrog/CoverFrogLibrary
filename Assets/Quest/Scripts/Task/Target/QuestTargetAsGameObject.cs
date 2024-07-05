using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/Target/GameObject", fileName = "GameObjectTarget")]
    public class QuestTargetAsGameObject : QuestTaskTarget
    {
        [SerializeField] private GameObject value;

        public override object Value => value;
        
        public override bool IsEqual(object target)
        {
            var targetAsGameObject = target as GameObject;

            if (targetAsGameObject == null)
            {
                return false;
            }

            return targetAsGameObject.name.Contains(value.name);
        }
    }
}
