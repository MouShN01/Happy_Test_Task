using System.Collections;
using UnityEngine;

public class CircleMover : MonoBehaviour // class which responsible foe circle movement
{
    private MainCircle _mainCircle;

    private void Awake()
    {
        _mainCircle = GetComponent<MainCircle>();
    }

    public void Move(Vector2 targetPosition)
    {
        StartCoroutine(MoveCoroutine(targetPosition));
    }

    private IEnumerator MoveCoroutine(Vector2 targetPosition) // in order not to call method somewhere in Update() the coroutine perform the whole movement to target
    {
        Vector2 startPosition = transform.position;
        Vector2 endPosition = targetPosition;
        float remainingDistance = Vector2.Distance(startPosition, targetPosition);
        while (remainingDistance > 0.01f) 
        {
            CommandInvoker.isExecuting = true;
            
            float currentSpeed = _mainCircle.Speed;
            float step = currentSpeed * Time.deltaTime;
            remainingDistance = Vector2.Distance(transform.position, endPosition);

            if (remainingDistance > step)
            {
                transform.position = Vector2.MoveTowards(transform.position, endPosition, step);
            }
            else
            {
                transform.position = endPosition;
                remainingDistance = 0;
            }

            yield return null;
        }
        CommandInvoker.isExecuting = false;
    }
}
