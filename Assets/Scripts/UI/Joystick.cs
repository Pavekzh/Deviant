using BasicTools;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using BaseTools;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]

    public class Joystick : MonoBehaviour    
    {
        private RectTransform rectTransform;
        [SerializeField]
        private RectTransform stick;
        [SerializeField]
        private float spaceRadius;
        [SerializeField]
        private bool isEnabled;
        [SerializeField]
        private bool returnStickToOrigin;

        public bool ReturnStickToOrigin { get => returnStickToOrigin; set => returnStickToOrigin = value; }
        public bool IsTouched { get; protected set; }
        public float SpaceRadius { get => spaceRadius * rectTransform.lossyScale.x; }
        public Vector2 Origin { get => rectTransform.position; }
        public Binding<Vector3> InputBinding { get; protected set; } = new Binding<Vector3>();
        public Vector3 JoystickDirection { get; protected set; }

        public event Action InputReadingStarted;
        public event Action InputReadingStoped;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            InputBinding.ValueChanged += InputBindingChanged;
        }

        private void InputBindingChanged(Vector3 value, object source)
        {
            JoystickDirection = value;
            if (source != (object)this && IsTouched == false)
            {
                Vector2 pointerPosition;
                if (value.GetVectorXZ().magnitude < spaceRadius * rectTransform.lossyScale.x)
                {
                    pointerPosition = Origin - value.GetVectorXZ();
                }
                else
                {
                    pointerPosition = Origin - value.GetVectorXZ().normalized * spaceRadius * rectTransform.lossyScale.x; ;
                }
                stick.position = pointerPosition;
            }
        }

        public void Disable()
        {
            InputBindingChanged(Vector3.zero, null);
            InputReadingStoped?.Invoke();
            isEnabled = false;
        }

        public void Enable(Binding<Vector2> originBinding)
        {
            if (isEnabled)
                Disable();

            isEnabled = true;
        }

        public virtual void JoystickTouch(BaseEventData eventData)
        {
            if (isEnabled && IsTouched)
            {
                Vector2 pointerPosition = (eventData as PointerEventData).position;
                Vector2 direction = Origin - pointerPosition;
                if (direction.magnitude > spaceRadius * rectTransform.lossyScale.x)
                {
                    direction = direction.normalized * spaceRadius * rectTransform.lossyScale.x;
                    pointerPosition = Origin - (direction);
                }
                stick.position = pointerPosition;

                InputBinding.ChangeValue(direction.GetVector3(), this);
            }
        }

        public virtual void JoystickTouchDown()
        {
            if (isEnabled)
                InputReadingStarted?.Invoke();
            IsTouched = true;
        }

        public virtual void JoystickTouchUp()
        {
            if (returnStickToOrigin)
            {
                stick.position = rectTransform.position;
                InputBinding.ChangeValue(Vector3.zero, this);
            }

            if (isEnabled)
                InputReadingStoped?.Invoke();

            IsTouched = false;
        }
    }
}
