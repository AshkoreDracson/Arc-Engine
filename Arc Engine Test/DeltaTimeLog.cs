using System;
using ArcEngine;

namespace ArcEngineTest
{
    public class DeltaTimeLog : GlobalScript
    {
        public override void Update()
        {
            Console.WriteLine(Time.time);
        }
    }
}