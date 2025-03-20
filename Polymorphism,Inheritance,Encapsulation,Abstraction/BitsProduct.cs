
namespace PIEA;

// Abstract class to represent a Product
internal abstract class BitsProduct
{
    // public enum CategoryEnum { Cycle, Sports, Footwear, Camping, Miscellaneous }
    protected abstract string Title { get; init; }
    protected abstract decimal Price { get; init; }
    protected abstract string Maker { get; init; }
    protected abstract DateTime DateListed { get; set; }
    protected abstract Guid Id { get; init; }
    protected abstract ulong ItemNumber { get; init; }

    public abstract void ShowInfo();
    public abstract void ShowInfo(bool showPrice, bool showAll);
};