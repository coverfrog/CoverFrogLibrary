using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/ReWard/HelloReward", fileName = "HelloReward")]
    public class HelloReward : QuestReward
    {
        public override void Give(Quest quest)
        {
            Debug.Log("Good!");
        }
    }
}
