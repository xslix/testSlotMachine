using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;
using UnityEngine.UI;

namespace TASK
{
    public class SlotMachinePath : MonoBehaviourExt
    {
        [SerializeField] private float speedupDuration = 2f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float elemHeight = 100f;
        [SerializeField] private float elemSpacing = 10f;
        [SerializeField] private int realElemAmount = 9;
        [SerializeField] Transform  items;
        [SerializeField] private ParticleSystem standartParticles;

        [SerializeField] private Button startBtn;
        [SerializeField] private Button stopBtn;
        
        private const string READY_TO_STOP_EVENT_NAME = "ReadyToStopRollEvent";
        private const string START_ROLL_EVENT_NAME = "StartRollEvent";
        private const string STOP_ROLL_EVENT_NAME = "StopRollEvent";
        private const string INIT_ROLL_EVENT_NAME = "InitRollEvent";

        private float _speed = 0f;
        private float _startY;
        
        [OnStart]
        private void StartThis()
        {
            Settings.Model.EventManager.AddAction(START_ROLL_EVENT_NAME, StartRoll);
            Settings.Model.EventManager.AddAction(READY_TO_STOP_EVENT_NAME, ReadyToStop);
            Settings.Model.EventManager.AddAction(STOP_ROLL_EVENT_NAME, StopRoll);
            Settings.Model.EventManager.AddAction(INIT_ROLL_EVENT_NAME, Init);
            _startY = items.position.y;
            Init();
        }

        private void ReadyToStop()
        {
           stopBtn.interactable = true;
        }
        
        
        private void StartRoll()
        {
            Path.EasingLinear(speedupDuration, 0, maxSpeed, x => _speed = x);
            startBtn.interactable = false;
            stopBtn.interactable = false;

        }

        private void Init()
        {
            startBtn.interactable = true;
            stopBtn.interactable = false;
        }

        private void StopRoll()
        {
            _speed = 0;
            var target = _startY + Mathf.Floor((items.position.y - _startY)/(elemHeight+elemSpacing)-2)*(elemHeight+elemSpacing)  ;
            Path.EasingQuadEaseOut(speedupDuration, items.position.y, target, x =>
            {
                if (_startY - realElemAmount * (elemHeight + elemSpacing) > x)
                {
                    x += realElemAmount * (elemHeight + elemSpacing);
                }
                var pos = items.position;
                pos.y = x;
                items.position = pos;
            }).Action(() => Settings.Fsm?.Invoke("RollStopped"))
            .Action(() => standartParticles.Play());
            

        }

        [OnUpdate]
        private void UpdateThis()
        {
            if (_startY - realElemAmount * (elemHeight + elemSpacing) > items.position.y)
            {
                var pos = items.position;
                pos.y = _startY;
                items.position = pos;
            }
            items.Translate(0, -_speed*Time.deltaTime, 0);
        }

    
    }
}