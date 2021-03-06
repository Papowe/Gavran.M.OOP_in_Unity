﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace GavranGame
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;
        public Vecto3Serializable Position;
        public bool IsEnable;
        public List<BonusesObject> Bonuses = new List<BonusesObject>();

        public override string ToString()
        {
            return $"Name - {Name}, Position - {Position}, IsVisible - {IsEnable}";
        }
    }

    [Serializable]
    public struct Vecto3Serializable
    {
        public float X;
        public float Y;
        public float Z;

        public Vecto3Serializable(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3(Vecto3Serializable value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator Vecto3Serializable(Vector3 value)
        {
            return new Vecto3Serializable(value.x, value.y, value.z);
        }
    }

    [Serializable]
    public struct BonusesObject
    {
        public string nameBonus;
        public bool meshBonus;
        public bool colliderBonus;

        public BonusesObject(string nameBonus, bool meshBonus, bool colliderBonus)
        {
            this.nameBonus = nameBonus;
            this.meshBonus = meshBonus;
            this.colliderBonus = colliderBonus;
        }
    }
}