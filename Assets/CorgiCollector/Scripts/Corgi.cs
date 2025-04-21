using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Corgi : MonoBehaviour
{
    public int level;
    public int tagLevel;
    public Flavor flavor;
    public int bones;

    public CorgiStats stats;

    public string Title
    {
        get { return stats.title; }
    }

    public float InnateFluff
    {
        get { return stats.FluffFinal(tagLevel, level); }
    }

    public float InnateBite
    {
        get { return stats.BiteFinal(tagLevel, level); }
    }

    public float InnateChonk
    {
        get { return stats.ChonkFinal(tagLevel, level); }
    }

    public float WhatIfFluff
    {
        get { return stats.FluffFinal(tagLevel+1, level); }
    }

    public float WhatIfBite
    {
        get { return stats.BiteFinal(tagLevel+1, level); }
    }

    public float WhatIfChonk
    {
        get { return stats.ChonkFinal(tagLevel+1, level); }
    }

    public bool IsMaxLevel{
        get { return level == 100; }
    }

    // returns the bones needed for a level
    public int LevelBones(int lvl)
    {
        return lvl * (lvl + 1) / 2;
    }

    public float BonesPercent
    {
        get
        {
            float current = bones - LevelBones(level);
            float needed = LevelBones(level + 1) - LevelBones(level);
            return current / needed;
        }
    }

    public float WhatIfBonesPercent(int add){
            float current = bones + add - LevelBones(level);
            float needed = LevelBones(level + 1) - LevelBones(level);
            return current / needed;
    }

    public float BonesLeft
    {
        get
        {
            float needed = LevelBones(level + 1) - bones;
            return needed;
        }
    }

    void Awake()
    {
        EvaluateLevel();
    }

    public void AddBones(int delta)
    {
        bones += delta;

        bones = Mathf.Clamp(bones, 0, 5050);

        EvaluateLevel();
    }

    public void AddTag(){
        tagLevel++;

        tagLevel = Math.Clamp(tagLevel, 0, 10);
    }

    public void EvaluateLevel()
    {
        // while having more bones than levelup
        while (LevelBones(level+1) <= bones)
        {
            if(IsMaxLevel){
                return;
            }

            level++;
        }
    }

    public override string ToString()
    {
        string result = $"Name: {stats.title}\n";
        result += $"Flavor: {Flavors.GetName(flavor)}\n";
        result += $"Level: {level}\n";
        result += $"Tags: {tagLevel}\n";
        result += $"Innate Fluff: {InnateFluff}\n";
        result += $"Innate Bite: {InnateBite}\n";
        result += $"Innate Chonk: {InnateChonk}\n";

        return result;
    }
}
