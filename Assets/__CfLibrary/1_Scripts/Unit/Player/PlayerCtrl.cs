using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    // Ctrl Model, View
    [RequireComponent(typeof(PlayerView))]
    public class PlayerCtrl : UnitCtrl<PlayerView, PlayerModel>
    {
      
    }
}
