using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


[Serializable]
public class CharacterAttribute {
    public float BaseValue = 0f;

    protected bool isDirty = true;
    protected float lastBaseValue;
    private readonly float precision = 0.000001f;

    protected float _value;
    public virtual float Value {
        get {

            if (isDirty || Math.Abs(lastBaseValue - BaseValue) > precision) {
                lastBaseValue = BaseValue;
                _value = Evaluate();
                isDirty = false;
            }
            return _value;
        }
    }

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public CharacterAttribute() {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharacterAttribute(float baseValue) : this() {
        BaseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier mod) {
        isDirty = true;
        statModifiers.Add(mod);
    }

    public virtual bool RemoveModifier(StatModifier mod) {
        if (statModifiers.Remove(mod)) {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source) {
        int numRemovals = statModifiers.RemoveAll(mod => mod.Source == source);

        if (numRemovals > 0) {
            isDirty = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Return final value of this attribute
    /// </summary>
    protected virtual float Evaluate() {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        //Sort to deal with flat type first, then additive percent type...
        statModifiers.Sort((a, b) => a.Order - b.Order);

        for (int i = 0; i < statModifiers.Count; i++) {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat) {
                finalValue += mod.Value;
            } else if (mod.Type == StatModType.PercentAdd) {
                sumPercentAdd += mod.Value;

                if (i >= statModifiers.Count -1 || statModifiers[i + 1].Type != StatModType.PercentAdd) {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            } else if (mod.Type == StatModType.PercentMult) {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }
}
