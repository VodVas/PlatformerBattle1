using UnityEngine;

public class Move : MonoBehaviour
{
    private const string _horizontal = "Horizontal";

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DoMove(float speed)
    {
        float moveX = Input.GetAxisRaw(_horizontal);

        Vector2 move = new Vector2(moveX * speed, _rigidbody.velocity.y);

        _rigidbody.velocity = move;

        if (moveX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
        }
    }
}