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
            ClockInstance = new Clock(clockSpeed,this);
            ClockInstance.OnTick += HandleTick;
            ClockInstance.OnTock += HandleTock;
            BusInstance = new Bus(this);
            StatusRegister = new StatusRegister(this);
            BRegister = new BRegister(this); // Initialize BRegister first
            ARegister = new ARegister(this) { Value = 0 };
            ALUInstance = new ALU(this); // Pass Computer to ALU
            PC = new ProgramCounter(this) { Value = 0 };
            IR = new InstructionRegister(this) { Value = 0 };
            OR = new OutputRegister(this) { Value = 0 };
            MAR = new MemoryAddressRegister(this) { Value = 0 };
            MemoryInstance = new Memory(this);
            ControlUnitInstance = new ControlUnit(this);
            ControlUnitInstance.ProcessControlSignalsTock();
            DisplayMessage("CO - Computer created and ready.");
        }

        public void Reset()
        {
            ARegister.Reset();
            BRegister.Reset();
            PC.Reset();
            IR.Reset();
            OR.Reset();
            MAR.Reset();
            IR.Reset();


            ControlUnitInstance.ProcessControlSignalsTock();
            DisplayMessage($"CO - Reset executed.");
        }



        private void HandleTick()
        {
            ControlUnitInstance.ProcessControlSignalsTick();
        }

        private void HandleTock()
        {
            ControlUnitInstance.ProcessControlSignalsTock();
        }
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}



