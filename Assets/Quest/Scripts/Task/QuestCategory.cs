using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/QuestCategory", fileName = "QuestCategory")]

    public class QuestCategory : ScriptableObject, IEquatable<QuestCategory>
    {
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField] private string displayName;
        
        public string CodeName => codeName;

        public string DisPlayName => displayName;

        public bool Equals(QuestCategory other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other)) 
                return true;
            return codeName == other.codeName;
        }

        public override bool Equals(object obj)
        {
            return Equals((QuestCategory)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CodeName, DisPlayName);
        }

        public static bool operator ==(QuestCategory lhs, string rhs)
        {
            if (lhs is null)
                return ReferenceEquals(lhs, null);

            return lhs.codeName == rhs || lhs.DisPlayName == rhs;
        }
        
        public static bool operator !=(QuestCategory lhs, string rhs)
        {
            return !(lhs == rhs);
        }
    }
}
