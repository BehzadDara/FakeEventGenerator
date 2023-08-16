using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class Item : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ItemEnum Type { get; init; }
        public ItemState State { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public bool IsMovable { get; set; }
        public string MetaData { get; set; } = string.Empty;

        public bool IsInAPartOgHouse(PartOfHouse partOfHouse)
        {
            return Methods.IsAnItemInAPartOfHouse(this.CoordinateX, this.CoordinateY, partOfHouse);
        }

        public ItemState ChangeState()
        {
            State = Type switch
            {
                ItemEnum.Openable => ChangeState(ItemState.Open, ItemState.Close),
                ItemEnum.Pickable => ChangeState(ItemState.OnAir, ItemState.OnSurface),
                ItemEnum.Usable => ChangeState(ItemState.BeUsing, ItemState.NotBeUsing),
                ItemEnum.UseWithCapacity => ChangeState(ItemState.Full, ItemState.NotFull),
                ItemEnum.Electronic => ChangeState(ItemState.On, ItemState.Off),
                _ => throw new InvalidOperationException()
            };

            return State;
        }

        private ItemState ChangeState(ItemState state1, ItemState state2)
        {
            return State.Equals(state1) ? state2 : state1;
        }
    }
}
