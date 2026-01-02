namespace PIEA;

internal sealed class CampingItem : Item
{
    public CampingItem(string Title, decimal Price, string Maker,
        DateTime DateListed
    ) : base()
    {
        this.Title = Title;
        this.Price = Price;
        this.Maker = Maker;
        this.DateListed = DateListed;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Camping - {Id} - {Title} - {Maker}");
    }

    public override void ShowInfo(bool showPrice, bool showAll)
    {
        if(showAll)
        {
            Console.WriteLine($"Camping - {Id} - {Title} - {Maker} - {Price} - {DateListed} - {ItemNumber}");
            return;
        }
        if(showPrice)
        {
            Console.WriteLine($"Camping - {Id} - {Title} - {Maker} - {Price}");
            return;
        }
        if(!showPrice & !showAll)
            ShowInfo();
    }
};