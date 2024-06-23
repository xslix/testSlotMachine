using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TASK.States
{
    [State("SlotMachineStopping")]
    public class SlotMachineStoppingState : FSMState
    {
        private const string NEXT_STATE_NAME = "SlotMachineInit";
        private const string STOP_ROLL_EVENT_NAME = "StopRollEvent";
        
        [Enter]
        private void EnterThis()
        {
            Settings.Invoke(STOP_ROLL_EVENT_NAME);
        }

        [Exit]
        private void ExitThis()
        {
        }

        [Bind("RollStopped")]
        private void OnRollStopped()
        {
            Parent.Change(NEXT_STATE_NAME);
        }
    }
}