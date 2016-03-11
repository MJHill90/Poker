using System;
using System.Reflection;

namespace PokerServer.Engine
{
    public interface INumberGenerator
    {
        byte GenerateRandomByte(byte min, byte max);
        double GenerateRandomDouble(double min, double max);
    }
}