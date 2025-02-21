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

        public JGEmulatorApp.Form1 form;
        public Computer(int clockSpeed,JGEmulatorApp.Form1 _form)
        {
            form = _form;
            ClockInstance = new Clock(clockSpeed, this);
            ClockInstance.OnTick += HandleTick;
            ClockInstance.OnTock += HandleTock;
            BusInstance = new Bus(this);
            StatusRegister = new StatusRegister(this);
            BRegister = new BRegister(this); // Initialize BRegister first
            ARegister = new ARegister(this);
            ALUInstance = new ALU(this); // Pass Computer to ALU
            PC = new ProgramCounter(this) { Value = 0 };
            IR = new InstructionRegister(this) ;
            OR = new OutputRegister(this);
            MAR = new MemoryAddressRegister(this);
            MemoryInstance = new Memory(this);
            ControlUnitInstance = new ControlUnit(this);
            ControlUnitInstance.ProcessControlSignalsTock();
            HandleUIMessages(new UIMessage(UIMessageType.Log, "Computer created and ready.", "COM"));
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
            HandleUIMessages(new UIMessage(UIMessageType.Log, "Computer reset and ready.", "COM"));
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
            // Console.WriteLine($"{message}");
        }

        public void Step()
        {
            ClockInstance.Step();
        }
        public void HandleUIMessages(UIMessage message)
        {
            switch (message.UIMessageType)
            {
                case UIMessageType.Log:
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine($"[{message.Source}] {message.Message}");
                    break;
                case UIMessageType.RegisterValue:
                    form.HandleUIMessages(message);
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine($"[{message.Source}] Register value: {message.Message}");

                    break;
                case UIMessageType.RegisterFlag:
                    //Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine($"[{message.Source}] Register flag: {message.Message}");
                    //break;
                case UIMessageType.BusState:
                    //Console.ForegroundColor = ConsoleColor.Magenta;
                    //Console.WriteLine($"[{message.Source}] Bus State: {message.Message}");
                    break;
            }
        }

        internal void SetSpeed(int newSpeed)
        {
            ClockInstance.SetSpeed(newSpeed);
        }

        internal void Start()
        {
            ClockInstance.Start();
        }

        internal void Stop()
        {
            ClockInstance.Stop();
        }
    }
}







