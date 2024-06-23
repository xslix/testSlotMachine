using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TASK.States
{
    [State("SlotMachineReadyToStop")]
    public class SlotMachineReadyToStopState : FSMState
    {
        private const string NEXT_STATE_NAME = "SlotMachineStopping";
        private const string READY_TO_STOP_EVENT_NAME = "ReadyToStopRollEvent";
        private const string STOP_BUTTON_NAME = "ButtonStop";
        
        [Enter]
        private void EnterThis()
        {
            Settings.Invoke(READY_TO_STOP_EVENT_NAME);
        }

        [Exit]
        private void ExitThis()
        {
        }

        [Bind("OnBtn")]
        private void OnClick(string name)
        {
            if (name != STOP_BUTTON_NAME)
            {
                return;
            }
            Parent.Change(NEXT_STATE_NAME);
        } 
    }
}