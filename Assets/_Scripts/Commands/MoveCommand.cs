using UnityEngine;

public class MoveCommand : ICommand // command which make circle to move 
{
    private CircleMover _circleMover;
    private Vector2 _targetPosition;

    public MoveCommand(CircleMover circleMover, Vector2 targetPosition) // constructor
    {
        this._circleMover = circleMover;
        this._targetPosition = targetPosition;
    }

    public void Execute() // method calls another method of mover component of circle  
    {
        _circleMover.Move(_targetPosition);
    }
}
