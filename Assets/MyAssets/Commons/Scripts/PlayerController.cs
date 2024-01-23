using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(CommonAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 5f;
    public Animator _animator;
    private CommonAttack _attack;
    private Rigidbody2D _rigidbody2D;
    private bool isGround;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _attack = GetComponent<CommonAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        float x = Gamepad.current.leftStick.ReadValue().x > 0 ? 1 : Gamepad.current.leftStick.ReadValue().x < 0 ? -1 : 0;
        transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        if (isGround && x != 0)
        {
            transform.localScale = new Vector3(x, 1, 1);
        }
        _animator.SetBool("isRun", isGround && x != 0);
    }
    private void Jump()
    {
        if (Gamepad.current.buttonNorth.wasPressedThisFrame && isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
        _animator.SetBool("isJump", !isGround);
    }

    private void Attack()
    {
        if (Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            _attack.Attack1();
        }

    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            _animator.SetTrigger("hurt");
            Destroy(collision.gameObject);
        }
    }

}
