using System;

namespace JGEmulator
{
    [Flags]
    public enum StatusFlags
    {
        None = 0,
        Zero = 1,
        Carry = 2
    }

    public class StatusRegister
    {
        public StatusFlags Flags { get; set; }

        public StatusRegister()
        {
            Flags = StatusFlags.None;
            Console.WriteLine("Status Register initialized.");
        }

        public void SetFlag(StatusFlags flag)
        {
            Flags |= flag;
            Console.WriteLine($"            Flag set: {flag}");
        }

        public void ClearFlag(StatusFlags flag)
        {
            Flags &= ~flag;
            Console.WriteLine($"            Flag cleared: {flag}");
        }

        public bool IsFlagSet(StatusFlags flag)
        {
            return (Flags & flag) != 0;
        }

        public void UpdateZeroFlag(byte value)
        {
            if (value == 0)
                SetFlag(StatusFlags.Zero);
            else
                ClearFlag(StatusFlags.Zero);
        }

        public void UpdateCarryFlag(bool carry)
        {
            if (carry)
                SetFlag(StatusFlags.Carry);
            else
                ClearFlag(StatusFlags.Carry);
        }
    }
}
