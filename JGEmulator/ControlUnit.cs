using System;

namespace JGEmulator
{
    public class ControlUnit
    {
        private  Computer _thiscomputer;
        private InstructionCounter _instructionCounter;
        private ControlSignalRom _controlSignalRom;
        private MicroInstruction _currentMicroInstruction;

        public ControlUnit(Computer computer)
        {
            _thiscomputer = computer;
            _instructionCounter = new InstructionCounter(_thiscomputer);
            _controlSignalRom = new ControlSignalRom();
            _thiscomputer.DisplayMessage("CU - Control Unit initialized.");
        }

        public void ProcessControlSignalsTick()
        {
            // Execute actions based on the current control signals
            if (_currentMicroInstruction.CE)
            {
                _thiscomputer.PC.Increment(); // Increment PC if CE is true
            }

            // J sets the PC to the address in the bus on the tick
            if (_currentMicroInstruction.J)
            {
                _thiscomputer.PC.ReadFromBus(_thiscomputer.BusInstance);
            }
            // JC sets the PC to the address in the bus on the tick if the carry flag is set
            if (_currentMicroInstruction.JC & _thiscomputer.StatusRegister.IsCarryFlagSet())
            {
                _thiscomputer.PC.ReadFromBus(_thiscomputer.BusInstance);
            }

            //JZ sets the PC to the address in the bus on the tick if the zero flag is set
            if (_currentMicroInstruction.JZ & _thiscomputer.StatusRegister.IsZeroFlagSet())
            {
                _thiscomputer.PC.ReadFromBus(_thiscomputer.BusInstance);
            }

            // MAR reads from the bus on the tick if MI (Memory Address Input) is true
            if (_currentMicroInstruction.MI)
            {
                _thiscomputer.MAR.ReadFromBus(_thiscomputer.BusInstance, _thiscomputer.MemoryInstance);
            }

            // AI reads from the bus on the tick if AI (A Register Input) is true
            if (_currentMicroInstruction.AI)
            {
                _thiscomputer.ARegister.ReadFromBus(_thiscomputer.BusInstance);
            }

            // BI reads from the bus on the tick if BI (B Register Input) is true
            if (_currentMicroInstruction.BI)
            {
                _thiscomputer.BRegister.ReadFromBus();
            }

            // RI reads from the bus on the tick if RI (Memory In) is true
            if (_currentMicroInstruction.RI)
            {
                _thiscomputer.MemoryInstance.ReadFromBus(_thiscomputer.BusInstance);
            }



            // II reads from the bus on the tick if II (Instruction Register Input) is true
            if (_currentMicroInstruction.II)
            {
                _thiscomputer.IR.ReadFromBus(_thiscomputer.BusInstance);
            }

            // PC reads from the bus on the tick if PC (Program Counter) is true
            if (_currentMicroInstruction.PC)
            {
                _thiscomputer.PC.ReadFromBus(_thiscomputer.BusInstance);
            }

            // OI reads from the bus on the tick if OI (Output Register Input) is true
            if (_currentMicroInstruction.OI)
            {
                _thiscomputer.OR.ReadFromBus();
            }

            // Increment the instruction counter at the end of the method
            _instructionCounter.Increment();
        }

        public void ProcessControlSignalsTock()
        {
            // Generate the 7-bit control word: 4 bits from IR and 3 bits from instruction counter
            byte controlWord = (byte)(((_thiscomputer.IR.Value >> 4) & 0x0F) << 3 | (_instructionCounter.Value & 0x07));
            // Display the control word in binary format
            string controlWordBinary = Convert.ToString(controlWord, 2).PadLeft(7, '0');
            _thiscomputer.DisplayMessage($"        CU - Control Word: {controlWordBinary}");

            // Get the corresponding microinstruction from the ROM
            _currentMicroInstruction = _controlSignalRom.GetMicroInstruction(controlWord);

            // Set control signals based on the micro-instruction for the tock phase

            // Handle MAR Tock Signal
            if (_currentMicroInstruction.MI == true)
            {
                _thiscomputer.MAR.State = BusState.Reading;
                _thiscomputer.DisplayMessage($"        CU - MAR bus status: {_thiscomputer.MAR.State}");
            }
            else
            {
                _thiscomputer.MAR.State = BusState.None;
            }

            // Handle A Register Tock Signal
            if ((_currentMicroInstruction.AI == true) || (_currentMicroInstruction.AO == true))
            {
                if (_currentMicroInstruction.AI == true)
                {
                    _thiscomputer.ARegister.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"        CU - A Register bus status: {_thiscomputer.ARegister.State}");
                }
                else
                {
                    _thiscomputer.ARegister.State = BusState.Writing;
                    _thiscomputer.DisplayMessage($"        CU - A Register bus status: {_thiscomputer.ARegister.State}");
                    _thiscomputer.ARegister.WriteToBus(_thiscomputer.BusInstance);
                }

            }
            else
            {
                _thiscomputer.ARegister.State = BusState.None;
            }

            // Handle Memory Tock Signal
            if ((_currentMicroInstruction.RI == true) || (_currentMicroInstruction.RO == true))
            {
                if (_currentMicroInstruction.RI == true)
                {

                    _thiscomputer.MemoryInstance.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"        CU - Memory bus status: {_thiscomputer.MemoryInstance.State}");
                }
                else
                {

                    _thiscomputer.MemoryInstance.State = BusState.Writing;
                    _thiscomputer.DisplayMessage($"        CU - Memory bus status: {_thiscomputer.MemoryInstance.State}");
                    _thiscomputer.MemoryInstance.WriteToBus(_thiscomputer.BusInstance);
                }

            }
            else
            {
                _thiscomputer.MemoryInstance.State = BusState.None;
            }

            // Handle IR Tock Signal
            if ((_currentMicroInstruction.II == true) || (_currentMicroInstruction.IO == true))
            {
                if (_currentMicroInstruction.II == true)
                {
                    _thiscomputer.IR.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"        CU - IR bus status: {_thiscomputer.IR.State}");
                }
                else
                {
                    _thiscomputer.IR.State = BusState.Writing;
                    _thiscomputer.DisplayMessage($"        CU - IR bus status: {_thiscomputer.IR.State}");
                    _thiscomputer.IR.WriteToBus(_thiscomputer.BusInstance);

                }
            }
            else
            {
                _thiscomputer.IR.State = BusState.None;
            }

            // Handle PC Tock Signal
            if (_currentMicroInstruction.J == true | _currentMicroInstruction.CO == true | _currentMicroInstruction.JC==true | _currentMicroInstruction.JZ==true)
            {
                
                if (_currentMicroInstruction.J == true)
                {
                    _thiscomputer.PC.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"        CU - PC bus status: {_thiscomputer.PC.State}");
                }
                else if (_currentMicroInstruction.JC == true & _thiscomputer.StatusRegister.CarryFlag==true)
                {
                    _thiscomputer.PC.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"        CU - PC bus status: {_thiscomputer.PC.State}");
                }
                else if (_currentMicroInstruction.JZ == true & _thiscomputer.StatusRegister.ZeroFlag==true)
                {
                    _thiscomputer.PC.State = BusState.Reading;
                    _thiscomputer.DisplayMessage($"    CU - PC bus status: {_thiscomputer.PC.State}");
                }

                else
                {
                    _thiscomputer.PC.State = BusState.Writing;
                    _thiscomputer.DisplayMessage($"        CU - PC bus status: {_thiscomputer.PC.State}");
                    _thiscomputer.PC.WriteToBus(_thiscomputer.BusInstance);
                }

            }
            else
            {
                _thiscomputer.PC.State = BusState.None;
            }

            // Handle CE Tock Signal
            if (_currentMicroInstruction.CE == true)
            {
                _thiscomputer.PC.CounterEnable = true;
                _thiscomputer.DisplayMessage($"        CU - PC Counter Enabled");
            }
            else
            {
                _thiscomputer.PC.CounterEnable = false;
            }

            // Handle OR Tock Signal
            if (_currentMicroInstruction.OI == true)
            {
                _thiscomputer.OR.State = BusState.Reading;
                _thiscomputer.DisplayMessage($"        CU - OR bus status: {_thiscomputer.OR.State}");
            }
            else
            {
                _thiscomputer.OR.State = BusState.None;
            }

            // Handle HLT Tock Signal
            if (_currentMicroInstruction.HLT == true)
            {
                _thiscomputer.ClockInstance.Stop();
                _thiscomputer.DisplayMessage("CU - Clock stopped due to HLT signal.");
            }

            // Handle Subtract Tock Signal
            if (_currentMicroInstruction.SU == true)
            {
                _thiscomputer.DisplayMessage($"        CU - ALU Subtract Enabled");
                _thiscomputer.ALUInstance.EnableSubtract(true);

            }
            else
            {
                _thiscomputer.ALUInstance.EnableSubtract(false);
            }

            // Handle B Register Tock Signal
            if (_currentMicroInstruction.BI == true)
            {
                _thiscomputer.BRegister.State = BusState.Reading;
                _thiscomputer.DisplayMessage($"        CU - B Register bus status: {_thiscomputer.BRegister.State}");

            }
            else
            {
                _thiscomputer.BRegister.State = BusState.None;
            }


            // Handle EO Tock Signal
            if (_currentMicroInstruction.EO == true)
            {
                _thiscomputer.ALUInstance.State = BusState.Writing;
                _thiscomputer.DisplayMessage($"        CU - ALU bus status: {_thiscomputer.ALUInstance.State}");
                _thiscomputer.ALUInstance.WriteToBus();
            }
            else
            {
                _thiscomputer.ALUInstance.State = BusState.None;
            }
        }
    }
}













