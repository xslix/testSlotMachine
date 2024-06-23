using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace TASK.States
{
    [State("SlotMachineInit")]
    public class SlotMachineInitState : FSMState
    {
        private const string START_BUTTON_NAME = "ButtonStart";
        private const string NEXT_STATE_NAME = "SlotMachineStartRunning";
        private const string INIT_ROLL_EVENT_NAME = "InitRollEvent";

        [Enter]
        private void EnterThis()
        {
            Settings.Invoke(INIT_ROLL_EVENT_NAME);
        }

        [Exit]
        private void ExitThis()
        {
        }
        
        [Bind("OnBtn")]
        private void OnClick(string name)
        {
            if (name != START_BUTTON_NAME)
            {
                return;
            }
            Parent.Change(NEXT_STATE_NAME);
        } 
    }
}