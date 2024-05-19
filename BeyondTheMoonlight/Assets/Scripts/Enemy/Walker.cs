using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;

    public SpriteRenderer _spriteRender;

    public float StopTime;

    public Direction CurrentDirection;

    private bool _isStoped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    public Transform RayStart;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }
    void Update()
    {
        if (_isStoped == true)
        {
            return;
        }

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x < LeftTarget.position.x)
            {
                _spriteRender.flipX = true;
                CurrentDirection = Direction.Right;
                _isStoped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > RightTarget.position.x)
            {
                _spriteRender.flipX = false;
                CurrentDirection = Direction.Left;
                _isStoped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }

      
    }
    
    void ContinueWalk()
    {
        _isStoped = false;
    }
}