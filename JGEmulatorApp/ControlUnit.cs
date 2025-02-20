using System;

namespace JGEmulator
{
    public class ControlUnit
    {
        private readonly Computer _computer;
        private InstructionCounter _instructionCounter;
        private ControlSignalRom _controlSignalRom;
        private MicroInstruction _currentMicroInstruction;

        public ControlUnit(Computer computer)
        {
            _computer = computer;
            _instructionCounter = new InstructionCounter(_computer);
            _controlSignalRom = new ControlSignalRom();
            _computer.DisplayMessage("CU - Control Unit initialized.");
        }

        public void ProcessControlSignalsTick()
        {
            // Execute actions based on the current control signals
            if (_currentMicroInstruction.CE)
            {
                _computer.PC.Increment(); // Increment PC if CE is true
            }

            // J sets the PC to the address in the bus on the tick
            if (_currentMicroInstruction.J)
            {
                _computer.PC.ReadFromBus(_computer.BusInstance);
            }
            // JC sets the PC to the address in the bus on the tick if the carry flag is set
            if (_currentMicroInstruction.JC & _computer.StatusRegister.IsCarryFlagSet())
            {
                _computer.PC.ReadFromBus(_computer.BusInstance);
            }

            //JZ sets the PC to the address in the bus on the tick if the zero flag is set
            if (_currentMicroInstruction.JZ & _computer.StatusRegister.IsZeroFlagSet())
            {
                _computer.PC.ReadFromBus(_computer.BusInstance);
            }

            // MAR reads from the bus on the tick if MI (Memory Address Input) is true
            if (_currentMicroInstruction.MI)
            {
                _computer.MAR.ReadFromBus(_computer.BusInstance, _computer.MemoryInstance);
            }

            // AI reads from the bus on the tick if AI (A Register Input) is true
            if (_currentMicroInstruction.AI)
            {
                _computer.ARegister.ReadFromBus(_computer.BusInstance);
            }

            // BI reads from the bus on the tick if BI (B Register Input) is true
            if (_currentMicroInstruction.BI)
            {
                _computer.BRegister.ReadFromBus();
            }

            // RI reads from the bus on the tick if RI (Memory In) is true
            if (_currentMicroInstruction.RI)
            {
                _computer.MemoryInstance.ReadFromBus(_computer.BusInstance);
            }

            // II reads from the bus on the tick if II (Instruction Register Input) is true
            if (_currentMicroInstruction.II)
            {
                _computer.IR.ReadFromBus(_computer.BusInstance);
            }

            // PC reads from the bus on the tick if PC (Program Counter) is true
            if (_currentMicroInstruction.PC)
            {
                _computer.PC.ReadFromBus(_computer.BusInstance);
            }

            // OI reads from the bus on the tick if OI (Output Register Input) is true
            if (_currentMicroInstruction.OI)
            {
                _computer.OR.ReadFromBus();
            }

            // Increment the instruction counter at the end of the method
            _instructionCounter.Increment();
        }

        public void ProcessControlSignalsTock()
        {
            // Generate the 7-bit control word: 4 bits from IR and 3 bits from instruction counter
            byte controlWord = (byte)(((_computer.IR.Value >> 4) & 0x0F) << 3 | (_instructionCounter.Value & 0x07));
            // Display the control word in binary format
            string controlWordBinary = Convert.ToString(controlWord, 2).PadLeft(7, '0');
            _computer.DisplayMessage($"    CU - Control Word: {controlWordBinary}");

            // Get the corresponding microinstruction from the ROM
            _currentMicroInstruction = _controlSignalRom.GetMicroInstruction(controlWord);

            // Set control signals based on the micro-instruction for the tock phase

            // Handle MAR Tock Signal
            if (_currentMicroInstruction.MI == true)
            {
                _computer.MAR.State = BusState.Reading;
                _computer.DisplayMessage($"    CU - MAR bus status: {_computer.MAR.State}");
            }
            else
            {
                _computer.MAR.State = BusState.None;
            }

            // Handle A Register Tock Signal
            if ((_currentMicroInstruction.AI == true) || (_currentMicroInstruction.AO == true))
            {
                if (_currentMicroInstruction.AI == true)
                {
                    _computer.ARegister.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - A Register bus status: {_computer.ARegister.State}");
                }
                else
                {
                    _computer.ARegister.State = BusState.Writing;
                    _computer.DisplayMessage($"    CU - A Register bus status: {_computer.ARegister.State}");
                    _computer.ARegister.WriteToBus(_computer.BusInstance);
                }
            }
            else
            {
                _computer.ARegister.State = BusState.None;
            }

            // Handle Memory Tock Signal
            if ((_currentMicroInstruction.RI == true) || (_currentMicroInstruction.RO == true))
            {
                if (_currentMicroInstruction.RI == true)
                {
                    _computer.MemoryInstance.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - Memory bus status: {_computer.MemoryInstance.State}");
                }
                else
                {
                    _computer.MemoryInstance.State = BusState.Writing;
                    _computer.DisplayMessage($"    CU - Memory bus status: {_computer.MemoryInstance.State}");
                    _computer.MemoryInstance.WriteToBus(_computer.BusInstance);
                }
            }
            else
            {
                _computer.MemoryInstance.State = BusState.None;
            }

            // Handle IR Tock Signal
            if ((_currentMicroInstruction.II == true) || (_currentMicroInstruction.IO == true))
            {
                if (_currentMicroInstruction.II == true)
                {
                    _computer.IR.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - IR bus status: {_computer.IR.State}");
                }
                else
                {
                    _computer.IR.State = BusState.Writing;
                    _computer.DisplayMessage($"    CU - IR bus status: {_computer.IR.State}");
                    _computer.IR.WriteToBus(_computer.BusInstance);
                }
            }
            else
            {
                _computer.IR.State = BusState.None;
            }

            // Handle PC Tock Signal
            if (_currentMicroInstruction.J == true | _currentMicroInstruction.CO == true | _currentMicroInstruction.JC == true | _currentMicroInstruction.JZ == true)
            {
                if (_currentMicroInstruction.J == true)
                {
                    _computer.PC.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - PC bus status: {_computer.PC.State}");
                }
                else if (_currentMicroInstruction.JC == true & _computer.StatusRegister.CarryFlag == true)
                {
                    _computer.PC.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - PC bus status: {_computer.PC.State}");
                }
                else if (_currentMicroInstruction.JZ == true & _computer.StatusRegister.ZeroFlag == true)
                {
                    _computer.PC.State = BusState.Reading;
                    _computer.DisplayMessage($"    CU - PC bus status: {_computer.PC.State}");
                }
                else
                {
                    _computer.PC.State = BusState.Writing;
                    _computer.DisplayMessage($"    CU - PC bus status: {_computer.PC.State}");
                    _computer.PC.WriteToBus(_computer.BusInstance);
                }
            }
            else
            {
                _computer.PC.State = BusState.None;
            }

            // Handle CE Tock Signal
            if (_currentMicroInstruction.CE == true)
            {
                _computer.PC.CounterEnable = true;
                _computer.DisplayMessage($"    CU - PC Counter Enabled");
            }
            else
            {
                _computer.PC.CounterEnable = false;
            }

            // Handle OR Tock Signal
            if (_currentMicroInstruction.OI == true)
            {
                _computer.OR.State = BusState.Reading;
                _computer.DisplayMessage($"    CU - OR bus status: {_computer.OR.State}");
            }
            else
            {
                _computer.OR.State = BusState.None;
            }

            // Handle HLT Tock Signal
            if (_currentMicroInstruction.HLT == true)
            {
                _computer.ClockInstance.Stop();
                _computer.DisplayMessage("CU - Clock stopped due to HLT signal.");
            }

            // Handle Subtract Tock Signal
            if (_currentMicroInstruction.SU == true)
            {
                _computer.DisplayMessage($"    CU - ALU Subtract Enabled");
                _computer.ALUInstance.EnableSubtract(true);
            }
            else
            {
                _computer.ALUInstance.EnableSubtract(false);
            }

            // Handle B Register Tock Signal
            if (_currentMicroInstruction.BI == true)
            {
                _computer.BRegister.State = BusState.Reading;
                _computer.DisplayMessage($"    CU - B Register bus status: {_computer.BRegister.State}");
            }
            else
            {
                _computer.BRegister.State = BusState.None;
            }

            // Handle EO Tock Signal
            if (_currentMicroInstruction.EO == true)
            {
                _computer.ALUInstance.State = BusState.Writing;
                _computer.DisplayMessage($"    CU - ALU bus status: {_computer.ALUInstance.State}");
                _computer.ALUInstance.WriteToBus();
            }
            else
            {
                _computer.ALUInstance.State = BusState.None;
            }
        }
    }
}




