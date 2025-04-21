using UnityEngine;

[CreateAssetMenu(fileName = "FlavorColors", menuName = "Scriptable Objects/FlavorColors")]
public class FlavorColors : ScriptableObject
{
    [Header("Base")]
    public Color Sweet;
    public Color Spicy;
    public Color Salty;
    public Color Savory;
    public Color Sour;
    public Color Unknown;
    [Header("Accent")]
    public Color SweetAccent;
    public Color SpicyAccent;
    public Color SaltyAccent;
    public Color SavoryAccent;
    public Color SourAccent;
    public Color UnknownAccent;
    [Header("Icons")]
    public Sprite SweetIcon;
    public Sprite SpicyIcon;
    public Sprite SaltyIcon;
    public Sprite SavoryIcon;
    public Sprite SourIcon;
    public Sprite UnknownIcon;

    public Color GetFlavorColor(Flavor flavor){
        return flavor switch{
            Flavor.Sweet => Sweet,
            Flavor.Spicy => Spicy,
            Flavor.Salty => Salty,
            Flavor.Savory => Savory,
            Flavor.Sour => Sour,
            _ => Unknown,
        };
    }

    public Color GetFlavorAccentColor(Flavor flavor){
        return flavor switch{
            Flavor.Sweet => SweetAccent,
            Flavor.Spicy => SpicyAccent,
            Flavor.Salty => SaltyAccent,
            Flavor.Savory => SavoryAccent,
            Flavor.Sour => SourAccent,
            _ => UnknownAccent,
        };
    }

    public Sprite GetFlavorSprite(Flavor flavor){
        return flavor switch{
            Flavor.Sweet => SweetIcon,
            Flavor.Spicy => SpicyIcon,
            Flavor.Salty => SaltyIcon,
            Flavor.Savory => SavoryIcon,
            Flavor.Sour => SourIcon,
            _ => UnknownIcon,
        };
    }
}
