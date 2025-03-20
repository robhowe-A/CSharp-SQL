
namespace PIEA;

internal class ProductStore
{
    static int Main()
    {
        CycleItem grips = new ("Strong grips", 45.00m, "BestBikesStuff", DateTime.Now);
        grips.ShowInfo();

        FootwearItem thermalSocks = new("Thermal socks", 15.00m, "The camping spot", DateTime.Now);
        thermalSocks.ShowInfo(true, false);

        SportsItem throwingDiscSet = new("Disc golf set", 80.00m, "UFO flying gear", DateTime.Now);
        throwingDiscSet.ShowInfo(false, false);

        CampingItem tentStakes = new("Tent stakes", 10.00m, "Generic tent gear", DateTime.Now);
        tentStakes.ShowInfo(true, true);

        MiscItem playingCards = new("Red+Black resort playing cards", 4.00m, "Mountaineer gambler", DateTime.Now);
        playingCards.ShowInfo(false, true);
        
        return -1;
    }
}