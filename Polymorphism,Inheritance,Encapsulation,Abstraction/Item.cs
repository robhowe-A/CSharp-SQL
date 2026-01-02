using PIEA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIEA
{
    internal class Item : BitsProduct
    {
        protected override string Title { get; init; } = string.Empty;
        protected override decimal Price { get => _price; init => _price = value; }
        protected override string Maker { get => _maker; init => _maker = value; }

        protected override DateTime DateListed { get => _dateListed; set => _dateListed = value; }
        protected override Guid Id { get; init; }
        protected override ulong ItemNumber { get => _itemNumber; init => _itemNumber++; }

        private decimal _price;
        private string _maker = string.Empty;
        private DateTime _dateListed;
        private static ulong _itemNumber = 0;

        public Item()
        {
            Id = Guid.NewGuid();
            _itemNumber++;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{Id} - {Title} - {Maker}");
        }

        public override void ShowInfo(bool showPrice, bool showAll)
        {
            if (showAll)
            {
                Console.WriteLine($"{Id} - {Title} - {Maker} - {Price} - {DateListed} - {ItemNumber}");
                return;
            }
            if (showPrice)
            {
                Console.WriteLine($"{Id} - {Title} - {Maker} - {Price}");
                return;
            }
            if (!showPrice & !showAll)
                ShowInfo();
        }
    }
}
