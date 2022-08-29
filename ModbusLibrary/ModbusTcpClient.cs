using EasyModbus;
using System;

namespace ModbusLibrary
{
    public class ModbusTcpClient
    {
        ModbusClient _client;
        public ModbusTcpClient(string ipAddress = "192.168.0.24", int port = 502, byte unitId = 255)
        {
            _client = new ModbusClient(ipAddress, port);
            //_client.UnitIdentifier = unitId;
        }

        public void Connect()
        {
            _client.Connect();
        }
        public bool GetCoilData(int startAddress)
        {
            if (_client.Connected)
            {
                bool[] coilValues = _client.ReadCoils(startAddress, 1);
                return coilValues[0];
            }
            else
            {
                throw new ArgumentException("Cannot Connect To The Device.");
            }
        }
        public float GetHoldingRegisterData(int startAddress)
        {
            if (_client.Connected)
            {
                int[] holdingValues = _client.ReadHoldingRegisters(startAddress, 2);

                float value = ModbusClient.ConvertRegistersToFloat(holdingValues, ModbusClient.RegisterOrder.HighLow);
                return value;
              
            }
            else
            {
                throw new ArgumentException("Cannot Connect To The Device.");
            }
        }

        public void Disconnect()
        {
            if (_client.Connected) _client.Disconnect();
        }
    }
}
