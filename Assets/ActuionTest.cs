using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public class ActuionTest : MonoBehaviour, IAuctionPlayer
    {
        [SerializeField] private int playerCashBalance;

        public int Balance => playerCashBalance;
        
        public void Bid(IAuctionPlayer player, int price, int cashBalance)
        {
            var bidSuccess = AuctionSystem.Bid(player, price, cashBalance);
            if (bidSuccess)
            {
                playerCashBalance = Mathf.Clamp(cashBalance - price, 0, int.MaxValue);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Bid(this, 1, Balance);
            }
        }

    }
}
