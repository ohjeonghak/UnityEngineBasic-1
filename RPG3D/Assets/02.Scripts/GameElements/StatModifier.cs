using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.GameElements
{
    public enum StatModType
    {
        None,
        AddFlat,
        AddPercent,
        MulPercent,
    }

    [Serializable]

    public class StatModifier
    {
        public StatID id;
        public StatModType type;
        public float value;
    }
}
