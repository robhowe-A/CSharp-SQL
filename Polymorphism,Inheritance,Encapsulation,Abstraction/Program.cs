
namespace PIEA;

internal class ProductStore
{
    static int Main()
    {
        CycleItem grips = new ("Strong grips", 45.00m, "BestBikesStuff", DateTime.Now.Date);
        grips.ShowInfo();
        grips.ShowInfo(true, true);
        grips.ShowInfo(true, false);
        grips.ShowInfo(false, true);
        grips.ShowInfo(false, false);

        
        
        return -1;
    }
}