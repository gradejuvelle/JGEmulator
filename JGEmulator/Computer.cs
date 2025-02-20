using System;

namespace JGEmulator
{
    public class Computer
    {
        public Clock ClockInstance { get; set; }
        public Bus BusInstance { get; set; }
        public ARegister ARegister { get; set; }
        public BRegister BRegister { get; set; }
        public ProgramCounter PC { get; set; }
        public InstructionRegister IR { get; set; }
        public OutputRegister OR { get; set; }
        public MemoryAddressRegister MAR { get; set; }
        public Memory MemoryInstance { get; set; }
        public StatusRegister StatusRegister { get; set; }
        public ALU ALUInstance { get; set; }
        public ControlUnit ControlUnitInstance { get; set; }

        public Computer(int clockSpeed)
        {
            ClockInstance = new Clock(clockSpeed);
            ClockInstance.OnTick += HandleTick;
            ClockInstance.OnTock += HandleTock;
            BusInstance = new Bus();
            StatusRegister = new StatusRegister();
            BRegister = new BRegister(this); // Initialize BRegister first
            ARegister = new ARegister { Value = 0 };
            ALUInstance = new ALU(this); // Pass Computer to ALU
            PC = new ProgramCounter { Value = 0 };
            IR = new InstructionRegister { Value = 0 };
            OR = new OutputRegister(this) { Value = 0 };
            MAR = new MemoryAddressRegister { Value = 0 };
            MemoryInstance = new Memory();
            ControlUnitInstance = new ControlUnit(this);
            Console.WriteLine("CO - Computer created and instances assigned.");
        }

        public void Reset()
        {
            ARegister.Value = 0;
            BRegister.Value = 0;
            PC.Value = 0;
            IR.Value = 0;
            OR.Value = 0;
            MAR.Value = 0;
            Console.WriteLine($"[{Utils.GetTimestamp()}] Origin: CO, Message: Registers set to zero.");

            ControlUnitInstance.ProcessControlSignalsTick();
            Console.WriteLine($"[{Utils.GetTimestamp()}] Origin: CO, Message: Reset executed.");
        }

        public void UpdateRegisters()
        {
            ARegister.WriteToBus(BusInstance);
            ARegister.ReadFromBus(BusInstance);
            BRegister.ReadFromBus();
            PC.WriteToBus(BusInstance);
            PC.ReadFromBus(BusInstance);
            IR.WriteToBus(BusInstance);
            IR.ReadFromBus(BusInstance);
            OR.ReadFromBus(); // Ensure OutputRegister reads from the bus
            MAR.WriteToBus(BusInstance);
            MAR.ReadFromBus(BusInstance, MemoryInstance); // Pass MemoryInstance to update SelectedAddress
            MemoryInstance.WriteToBus(BusInstance);
            MemoryInstance.ReadFromBus(BusInstance);
        }

        private void HandleTick()
        {
            ControlUnitInstance.ProcessControlSignalsTick();
        }

        private void HandleTock()
        {
            ControlUnitInstance.ProcessControlSignalsTock();
        }
    }
}



