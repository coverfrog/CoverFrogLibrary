using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public class AuctionItem : ScriptableObject, IAuctionItem
    {
        [SerializeField] private string codeName;
        [SerializeField] private int currentPrice;
        
        public string CodeName => codeName;
        
        public int CurrentPrice => currentPrice;

        public void InitPrice() => currentPrice = 1;
        
        public bool OnBid(IAuctionPlayer player, int price, int cashBalance)
        {
            if(cashBalance < currentPrice)
                return false;

            currentPrice += price;

            return true;
        }

        private void OnEnable()
        {
            InitPrice();
        }
    }
}
