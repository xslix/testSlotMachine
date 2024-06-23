using AxGrid;
using AxGrid.FSM;
using UnityEngine;

namespace TASK.States
{
    [State("SlotMachineStartRunning")]
    public class SlotMachineStartRunningState : FSMState
    {
        private const string NEXT_STATE_NAME = "SlotMachineReadyToStop";
        private const string START_ROLL_EVENT_NAME = "StartRollEvent";
        
        [Enter]
        private void EnterThis()
        {
            Settings.Invoke(START_ROLL_EVENT_NAME);
        }

        [Exit]
        private void ExitThis()
        {
        }

        [One(3f)]
        private void OnMaxSpeed()
        {
            Parent.Change(NEXT_STATE_NAME);
        }
    }
}