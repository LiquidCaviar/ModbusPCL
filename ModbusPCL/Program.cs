using System;
using System.Collections;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading;

namespace ModbusPCL
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing....
            var GPIO = new GpioController(PinNumberingScheme.Board);

            //inputs
            var inpin = 5;
            //outputs
            var outpin = 3;
            //stepper
            int[] I = { 37, 35, 33, 31 }; 
            //
            GPIO.OpenPin(I[0], PinMode.Output);
            GPIO.OpenPin(I[1], PinMode.Output);
            GPIO.OpenPin(I[2], PinMode.Output);
            GPIO.OpenPin(I[3], PinMode.Output);
            //
            PinValue[] step1 = { PinValue.Low, PinValue.High, PinValue.High, PinValue.High };
            PinValue[] step2 = { PinValue.Low, PinValue.Low, PinValue.High, PinValue.High };
            PinValue[] step3 = { PinValue.High, PinValue.Low, PinValue.High, PinValue.High };
            PinValue[] step4 = { PinValue.High, PinValue.Low, PinValue.Low, PinValue.High };
            PinValue[] step5 = { PinValue.High, PinValue.High, PinValue.Low, PinValue.High };
            PinValue[] step6 = { PinValue.High, PinValue.High, PinValue.Low, PinValue.Low };
            PinValue[] step7 = { PinValue.High, PinValue.High, PinValue.High, PinValue.Low };
            PinValue[] step8 = { PinValue.Low, PinValue.High, PinValue.High, PinValue.Low };
            //
            var steps = new List<PinValue[]>() {step1, step2, step3, step4, step5, step6, step7, step8};

            while (inpin<200)
            {
                foreach (var item in steps)
                {
                    GPIO.Write(I[0], item[3]);
                    GPIO.Write(I[1], item[2]);
                    GPIO.Write(I[2], item[1]);
                    GPIO.Write(I[3], item[0]);
                    Thread.Sleep(TimeSpan.FromMilliseconds(0.5));
                }
                inpin++;
            }

                
         
            

            GPIO.ClosePin(I[0]);
            GPIO.ClosePin(I[1]);
            GPIO.ClosePin(I[2]);
            GPIO.ClosePin(I[3]); 
        }
    }
}
