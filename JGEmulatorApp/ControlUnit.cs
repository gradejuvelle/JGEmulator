using Microsoft.VisualBasic.Devices;
using System;

namespace JGEmulator
{
    public class ControlUnit
    {
        private Computer _thiscomputer;
        public InstructionCounter _instructionCounter;
        private ControlSignalRom _controlSignalRom;
        private MicroInstruction _currentMicroInstruction;

        public ControlUnit(Computer computer)
        {
            _thiscomputer = computer;
            _instructionCounter = new InstructionCounter(_thiscomputer);
            _controlSignalRom = new ControlSignalRom();
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Control Unit initialized.", "CTR"));
        }

        public void ProcessControlSignalsTick()
        {
            // Execute actions based on the current control signals

            // Handle STT Tick Signal
            // Handle Flags
            if (_currentMicroInstruction.FI)
            {
                // If subtract is enabled
                if (_currentMicroInstruction.SU)
                {
                    // Set Carry
                    if (_thiscomputer.BRegister.GetValue() <= this._thiscomputer.ARegister.GetValue())
                    {
                        _thiscomputer.StatusRegister.SetCarryFlag();
                    }
                    else
                    {
                        _thiscomputer.StatusRegister.ClearCarryFlag();
                    }
                    //Set Zero
                    if (_thiscomputer.BRegister.GetValue() == this._thiscomputer.ARegister.GetValue())
                    {
                        _thiscomputer.StatusRegister.SetZeroFlag();
                    }
                    else
                    {
                        _thiscomputer.StatusRegister.ClearZeroFlag();
                    }
                }
                // if addition
                else
                {
                    // Set Carry
                    if (_thiscomputer.ARegister.GetValue() + _thiscomputer.BRegister.GetValue() > 255)
                    {
                        _thiscomputer.StatusRegister.SetCarryFlag();
                    }
                    else
                    {
                        _thiscomputer.StatusRegister.ClearCarryFlag();
                    }
                    //Set Zero
                    if (_thiscomputer.BRegister.GetValue() + this._thiscomputer.ARegister.GetValue() == 255)
                    {
                        _thiscomputer.StatusRegister.SetZeroFlag();
                    }
                    else
                    {
                        _thiscomputer.StatusRegister.ClearZeroFlag();
                    }
                    //this._thiscomputer.StatusRegister.SetCarryFlag();
                    //this._thiscomputer.StatusRegister.SetZeroFlag();
                }
            }

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

            // JZ sets the PC to the address in the bus on the tick if the zero flag is set
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
            byte controlWord = (byte)(((_thiscomputer.IR.GetValue() >> 4) & 0x0F) << 3 | (_instructionCounter.Value & 0x07));
            // Display the control word in binary format
            string controlWordBinary = Convert.ToString(controlWord, 2).PadLeft(7, '0');
            _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Control Word: {controlWordBinary}", "CTR"));

            // Get the corresponding microinstruction from the ROM
            _currentMicroInstruction = _controlSignalRom.GetMicroInstruction(controlWord);

            // Set control signals based on the micro-instruction for the tock phase

            // Handle STT Tock Signal
            if (_currentMicroInstruction.FI == true)
            {
                _thiscomputer.StatusRegister.SetBusState(BusState.Reading);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "STT input status: ", "STT"));
            }

            // Handle MAR Tock Signal
            if (_currentMicroInstruction.MI == true)
            {
                _thiscomputer.MAR.SetBusState( BusState.Reading);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"MAR bus status: {_thiscomputer.MAR.GetBusState()}", "CTR"));
            }
            else
            {
                _thiscomputer.MAR.SetBusState(BusState.None);
            }

            // Handle A Register Tock Signal
            if ((_currentMicroInstruction.AI == true) || (_currentMicroInstruction.AO == true))
            {
                if (_currentMicroInstruction.AI == true)
                {
                    _thiscomputer.ARegister.SetBusState ( BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"A Register bus status: {_thiscomputer.ARegister.GetBusState()}", "CTR"));
                }
                else
                {
                    _thiscomputer.ARegister.SetBusState(BusState.Writing);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"A Register bus status: {_thiscomputer.ARegister.GetBusState()}", "CTR"));
                    _thiscomputer.ARegister.WriteToBus(_thiscomputer.BusInstance);
                }
            }
            else
            {
                _thiscomputer.ARegister.SetBusState(BusState.None);
            }

            // Handle Memory Tock Signal
            if ((_currentMicroInstruction.RI == true) || (_currentMicroInstruction.RO == true))
            {
                if (_currentMicroInstruction.RI == true)
                {
                    _thiscomputer.MemoryInstance.SetBusState( BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Memory bus status: {BusState.Reading}", "CTR"));
                }
                else
                {
                    _thiscomputer.MemoryInstance.SetBusState( BusState.Writing);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"Memory bus status: {BusState.Writing}", "CTR"));
                    _thiscomputer.MemoryInstance.WriteToBus(_thiscomputer.BusInstance);
                }
            }
            else
            {
                _thiscomputer.MemoryInstance.SetBusState(BusState.None);
            }

            // Handle IR Tock Signal
            if ((_currentMicroInstruction.II == true) || (_currentMicroInstruction.IO == true))
            {
                if (_currentMicroInstruction.II == true)
                {
                    _thiscomputer.IR.SetBusState( BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"IR bus status: {_thiscomputer.IR.GetBusState()}", "CTR"));
                }
                else
                {
                    _thiscomputer.IR.SetBusState(BusState.Writing);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"IR bus status: {_thiscomputer.IR.GetBusState()}", "CTR"));
                    _thiscomputer.IR.WriteToBus(_thiscomputer.BusInstance);
                }
            }
            else
            {
                _thiscomputer.IR.SetBusState(BusState.None);
            }

            // Handle PC Tock Signal
            if (_currentMicroInstruction.J == true | _currentMicroInstruction.CO == true | _currentMicroInstruction.JC == true | _currentMicroInstruction.JZ == true)
            {
                if (_currentMicroInstruction.J == true)
                {
                    _thiscomputer.PC.SetBusState(BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"PC bus status: {_thiscomputer.PC.GetBusState()}", "CTR"));
                }
                else if (_currentMicroInstruction.JC == true & _thiscomputer.StatusRegister.IsCarryFlagSet() == true)
                {
                    _thiscomputer.PC.SetBusState(BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"PC bus status: {_thiscomputer.PC.GetBusState()}", "CTR"));
                }
                else if (_currentMicroInstruction.JZ == true & _thiscomputer.StatusRegister.IsZeroFlagSet() == true)
                {
                    _thiscomputer.PC.SetBusState(BusState.Reading);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"PC bus status: {_thiscomputer.PC.GetBusState()}", "CTR"));
                }
                else
                {
                    _thiscomputer.PC.SetBusState(BusState.Writing);
                    _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"PC bus status: {_thiscomputer.PC.GetBusState()}", "CTR"));
                    _thiscomputer.PC.WriteToBus(_thiscomputer.BusInstance);
                }
            }
            else
            {
                _thiscomputer.PC.SetBusState(BusState.None);
            }

            // Handle CE Tock Signal
            if (_currentMicroInstruction.CE == true)
            {
                _thiscomputer.PC.SetCounterEnable(true);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "PC Counter Enabled", "CTR"));
            }
            else
            {
                _thiscomputer.PC.SetCounterEnable( false);
            }

            // Handle OR Tock Signal
            if (_currentMicroInstruction.OI == true)
            {
                _thiscomputer.OR.SetBusState( BusState.Reading);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"OR bus status: {_thiscomputer.OR.GetBusState()}", "CTR"));
            }
            else
            {
                _thiscomputer.OR.SetBusState( BusState.None);
            }

            // Handle HLT Tock Signal
            if (_currentMicroInstruction.HLT == true)
            {
                _thiscomputer.ClockInstance.Stop();
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "Clock stopped due to HLT signal.", "CTR"));
            }

            // Handle Subtract Tock Signal
            if (_currentMicroInstruction.SU == true)
            {
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, "ALU Subtract Enabled", "CTR"));
                _thiscomputer.ALUInstance.EnableSubtract(true);
            }
            else
            {
                _thiscomputer.ALUInstance.EnableSubtract(false);
            }

            // Handle B Register Tock Signal
            if (_currentMicroInstruction.BI == true)
            {
                _thiscomputer.BRegister.SetBusState(BusState.Reading);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"B Register bus status: {_thiscomputer.BRegister.GetValue()}", "CTR"));
            }
            else
            {
                _thiscomputer.BRegister.SetBusState(BusState.None);
            }

            // Handle EO Tock Signal
            if (_currentMicroInstruction.EO == true)
            {
                _thiscomputer.ALUInstance.SetBusState( BusState.Writing);
                _thiscomputer.HandleUIMessages(new UIMessage(UIMessageType.Log, $"ALU bus status: {_thiscomputer.ALUInstance.GetBusState()}", "CTR"));
                _thiscomputer.ALUInstance.WriteToBus();
            }
            else
            {
                _thiscomputer.ALUInstance.SetBusState(BusState.None);
            }
        }
    }
}







