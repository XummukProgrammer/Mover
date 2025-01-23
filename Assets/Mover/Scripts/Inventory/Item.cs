namespace Mover
{
    public class Item : Inventory.IItem
    {
        public string Id { get; set; }
        public int Value { get; private set; }

        public event System.Action<int, int> ValueChanged;
        public event System.Action Used;

        public void Add(int value)
        {
            int prevValue = Value;
            Value += value;

            ValueChanged?.Invoke(prevValue, value);
        }

        public void Take(int value)
        {
            int prevValue = Value;
            Value -= value;

            if (Value < 0)
            {
                Value = 0;
            }

            ValueChanged?.Invoke(prevValue, value);
        }

        public void Use()
        {
            if (Value <= 0)
            {
                return;
            }

            Take(1);

            OnUse();
        }

        protected virtual void OnUse()
        {
            Used?.Invoke();
        }
    }
}
