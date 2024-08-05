using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public interface IAuctionItem
    {
        public string CodeName { get;}
        
        public int CurrentPrice { get; }
        
        public void InitPrice();

        public bool OnBid(IAuctionPlayer player, int price, int cashBalance);
    }

    public interface IAuctionPlayer
    {
        public int Balance { get; }
        
        public void Bid(IAuctionPlayer player, int price, int cashBalance);
    }

    public class AuctionSystem : MonoBehaviour
    {
        public static IAuctionItem Current { get; private set; }

        public static bool Bid(IAuctionPlayer player, int price, int cashBalance)
        {
            return Current != null && Current.OnBid(player, price, cashBalance);
        }

        private void OnEnable()
        {
            if (Current != null)
                Current = null;
        }
    }
}
