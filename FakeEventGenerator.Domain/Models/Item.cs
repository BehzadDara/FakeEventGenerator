using FakeEventGenerator.Domain.Enums;

namespace FakeEventGenerator.Domain.Models
{
    public class Item : Entity
    {
        public ItemEnum Type { get; set; }

        public ItemState State { get; private set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }


        public ItemState ChangeState()
        {
            State = Type switch
            {
                ItemEnum.Openable => ChangeState(ItemState.Open, ItemState.Close),
                ItemEnum.Pickable => ChangeState(ItemState.OnAir, ItemState.OnSurface),
                ItemEnum.Usable => ChangeState(ItemState.BeUsing, ItemState.NotBeUsing),
                ItemEnum.UseWithCapacity => ChangeState(ItemState.Full, ItemState.Empty),
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
