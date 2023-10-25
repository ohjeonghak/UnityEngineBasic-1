using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace RPG.GameElements
{
    [Serializable]
    public class Stat 
    {
        public StatID id;
        public float value
        {
            get => _value;
            set
            {
                if (value == _value) 
                    return;

                _value = value;
                onValueChanged?.Invoke(value);
            }
        }

        [SerializeField] private float _value;
        public event Action<float> onValueChanged;

        public float valueModiried
        {
            get => _valueModiried;
            set
            {
                if (value == _valueModiried)
                    return;

                _valueModiried = value;
                onValueModiriedChanged?.Invoke(value);
            }
        }

        private float _valueModiried;
        public event Action<float> onValueModiriedChanged;

        private List<StatModifier> _modifiers = new List<StatModifier>();

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.Add(modifier);
            valueModiried = CalcValueModified();
        }

        public void RemoveModifier(StatModifier modifier)
        {
            _modifiers.Remove(modifier);
            valueModiried = CalcValueModified();
        }

        public void AddModifiers(List<StatModifier> modifiers)
        {
            foreach (var modifier in modifiers)    
                _modifiers.Add(modifier);
            
            valueModiried = CalcValueModified();
        }

        public void RemoveModifiers(List<StatModifier> modifiers)
        {
            foreach (var modifier in modifiers)
                _modifiers.Remove(modifier);

            valueModiried = CalcValueModified();
        }
        public float CalcValueModified()
        {
            float sumAddFlat = 0.0f;
            float sumAddPercent = 0.0f;
            float sumMulpercent = 0.0f;

            foreach (var modifier in _modifiers)
            {
                switch (modifier.type)
                {
                    case StatModType.AddFlat:
                        {
                            sumAddFlat += modifier.value;
                        }
                        break;
                    case StatModType.AddPercent:
                        {
                            sumAddPercent += modifier.value;
                        }
                        break;
                    case StatModType.MulPercent:
                        {
                            sumMulpercent *= modifier.value;
                        }
                        break;
                    default:
                        throw new Exception($"[Stat] : {modifier.id} modifier's type is wrong.");
                }
            }
            return (_value + sumAddFlat) +
                   (_value * sumAddPercent) +
                   (_value * sumMulpercent);
        }
    }
    
}
