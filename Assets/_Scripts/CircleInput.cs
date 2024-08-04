using UnityEngine;

public class CircleInput : MonoBehaviour // class responsible for inputs
{
    private CircleMover _circleMover;
    private UIBlocker _uiBlocker;
    private Vector2 _targetPosition;

    private void Awake()
    {
        _circleMover = GetComponent<CircleMover>();
        _uiBlocker = GetComponent<UIBlocker>();
    }

    private void Update()
    {
        if(_uiBlocker.IsPointerOverUIElement()) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Ended) return;
            Vector2 touchPosition = touch.position;
            _targetPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            RunCircleCommand(_circleMover, _targetPosition);
        }
    }

    private void RunCircleCommand(CircleMover circleMover, Vector2 targetPosition)
    {
        ICommand command = new MoveCommand(circleMover, targetPosition);
        CommandInvoker.AddCommand(command);
    }
}
