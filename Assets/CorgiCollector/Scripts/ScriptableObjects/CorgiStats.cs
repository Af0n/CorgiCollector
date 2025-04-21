using UnityEngine;

[CreateAssetMenu(fileName = "CorgiStats", menuName = "Scriptable Objects/CorgiStats")]
public class CorgiStats : ScriptableObject
{
    public string title;
    public Sprite splash, portrait;
    public Flavor flavor;
    [Header("Fluff (Health)")]
    public float baseFluff;
    // baseFluff bonus per level. Percentage of StarFluff
    public float fluffGrowth;
    // baseFluff bonus per level. Percentage of baseFluff
    public float fluffStarGrowth;

    public float StarFluff(int star){
        return baseFluff + (baseFluff * star * fluffStarGrowth);
    }

    public float FluffFinal(int star, int level){
        float starFluff = StarFluff(star);

        return starFluff + (starFluff * level * fluffGrowth);
    }

    [Header("Bite (Attack)")]
    public float baseBite;
    // baseBite bonus per level
    public float biteGrowth;
    // baseBite multiplier per star
    public float biteStarGrowth;

    public float StarBite(int star){
        return baseBite + (baseBite * star * biteStarGrowth);
    }

    public float BiteFinal(int star, int level){
        float starBite = StarBite(star);

        return starBite + (starBite * level * biteGrowth);
    }

    [Header("Chonk (Defense)")]
    public float baseChonk;
    // baseChonk bonus per level
    public float chonkGrowth;
    // baseChonk multiplier per level
    public float chonkStarGrowth;

    public float StarChonk(int star){
        return baseChonk + (baseChonk * star * chonkStarGrowth);
    }

    public float ChonkFinal(int star, int level){
        float starChonk = StarChonk(star);

        return starChonk + (starChonk * level * chonkGrowth);
    }

    public override string ToString(){
        string result = $"Name: {title}\n";
        result += $"baseFluff: {baseFluff}\n";
        result += $"Name: {fluffGrowth}\n";
        result += $"Name: {fluffStarGrowth}\n";
        result += $"Name: {baseBite}\n";
        result += $"Name: {biteGrowth}\n";
        result += $"Name: {biteStarGrowth}\n";
        result += $"Name: {baseChonk}\n";
        result += $"Name: {chonkGrowth}\n";
        result += $"Name: {chonkStarGrowth}\n";
        
        return result;
    }
}
