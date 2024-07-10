using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    [CreateAssetMenu(menuName = "CG/Player/Move/To Dir Axis", fileName = "Player Move To Dir Axis")]
    public class PlayerMoveToDirAxis : PlayerMove
    {
        #region > Example Code
        // [ Example ]
        // var dir = move.InputUpdate();
        // if (dir.HasValue)
        // {
        //      move.To(this, dir.Value);
        // }
        #endregion

        public override Vector3? InputUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var dir = new Vector3(horizontal, 0, vertical);

            if (dir.magnitude <= 0) 
                return null;
            
            dir.Normalize();
            return dir;
        }

        public override void To(Player player, Vector3 target)
        {
            var prevPoint = player.transform.position;
            var direction = target.normalized;
            var nextPoint = prevPoint + direction * (2.0f * Time.deltaTime);

            player.transform.position = nextPoint;
        }
    }
}
