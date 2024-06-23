using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using ExampleFSM;
using TASK.States;
using UnityEngine;

namespace TASK
{
    public class SlotMachineBootstrap : MonoBehaviourExtBind
    {
        [OnStart]
        private void StartThis()
        {
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(new SlotMachineInitState());
            Settings.Fsm.Add(new SlotMachineStartRunningState());
            Settings.Fsm.Add(new SlotMachineReadyToStopState());
            Settings.Fsm.Add(new SlotMachineStoppingState());
            
            Settings.Fsm.Start("SlotMachineInit");
        }

        [OnUpdate]
        private void UpdateThis()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }
    }
}