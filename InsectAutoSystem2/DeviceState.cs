using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsectAutoSystem2
{
    public static class DeviceState
    {
        public enum MeasureState
        {
            None,
            NewBox,
            Measuring,
            Finish,
            End
        }

        private static MeasureState measureState = MeasureState.None;
        private static bool sensorState = false;
        public static double targetMeasureWeight = 2.9;

        public static void setMeasureState(MeasureState state)
        {
            measureState = state;
        }

        public static MeasureState getMeasureState()
        {
            return measureState;
        }


    }
}
