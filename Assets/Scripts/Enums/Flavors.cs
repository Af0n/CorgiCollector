public static class Flavors
{
    public static string GetName(Flavor flav){
        return flav switch{
            Flavor.Sweet => "Sweet",
            Flavor.Spicy => "Sweet",
            Flavor.Salty => "Sweet",
            Flavor.Savory => "Sweet",
            Flavor.Sour => "Sweet",
            _ => "Unknown Flavor"
        };
    }
}
