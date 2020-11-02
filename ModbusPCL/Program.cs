using System;
using System.Device.Gpio;
using System.Threading;

namespace ModbusPCL
{
    class Program
    {
        static void Main(string[] args)
        {
            var GPIO = new GpioController(PinNumberingScheme.Board);

            //inputs
            var inpin = 2;
            //outputs
            var outpin = 3;

            GPIO.OpenPin(inpin, PinMode.Input);
            GPIO.OpenPin(outpin, PinMode.Output);

            for(int i=0; i < 12; i++)
            {
                GPIO.Write(outpin, PinValue.High);
                Console.WriteLine(GPIO.Read(inpin).ToString());
                Thread.Sleep(500);
                GPIO.Write(outpin, PinValue.Low);
                Console.WriteLine(GPIO.Read(inpin).ToString());
                Thread.Sleep(500);
            }

        }
    }
}
