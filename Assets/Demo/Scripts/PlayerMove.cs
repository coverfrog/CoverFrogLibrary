using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public abstract class PlayerMove : ScriptableObject
    {
        public abstract Vector3? InputUpdate();
        public abstract void To(Player player, Vector3 target);
    }
}
