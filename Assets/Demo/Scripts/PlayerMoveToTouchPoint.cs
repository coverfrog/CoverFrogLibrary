using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    [CreateAssetMenu(menuName = "CG/Player/Move/To Touch Point", fileName = "Player Move To TouchPoint")]
    public class PlayerMoveToTouchPoint : PlayerMove
    {
        public override Vector3? InputUpdate()
        {
            return null;
        }

        public override void To(Player player, Vector3 target)
        {
            throw new System.NotImplementedException();
        }
    }
}
