using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(CommonAttack))]
public class testcontoroler : MonoBehaviour
{
           [SerializeField] private float speed = 5f;

    private Vector2 _moveInputValue;
    [SerializeField] private float jumpPower = 5f;
    public Animator _animator;

    public Rigidbody2D _rigidbody2D;
    private bool isGround;
      private  Vector3 bulletPoint;
  private GameObject BulletObj;
   private Gameinput _gameInputs;
   private float y;

    public void OnMove(InputAction.CallbackContext context)
    {
      _moveInputValue = context.ReadValue<Vector2>();
    }
    private void OnDestroy()
    {
        _gameInputs?.Dispose();
    }
    private void Attack1()
    {
        float Direction = transform.localScale.x;

            GameObject bullet = Instantiate(BulletObj, transform.position + new Vector3(bulletPoint.x * Direction, bulletPoint.y, bulletPoint.z), Quaternion.identity);

            bullet.GetComponent<Bullet>().SetDirection(Direction);

            Destroy(bullet, 1.0f);
            _animator.SetTrigger("attack");
    }






    public void Onfire(InputAction.CallbackContext context)
    {
        Debug.Log("ewtryui;");
     Attack1();
    }
     void Update()
    {
        Debug.Log(isGround);
    
        Move();
    }
        void Start()
    {
        BulletObj = GameObject.Find("player_bullet");
        bulletPoint = transform.Find("BulletPoint").localPosition;
        _animator = GetComponent<Animator>();
    }


      void Move()
    {
        
        float x = _moveInputValue.x; 
        transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
        if (isGround && x != 0)
        {
            transform.localScale = new Vector3(x, 1, 1);
        }
        _animator.SetBool("isRun", isGround && x != 0); 
        y = _moveInputValue.y;
        if (y >=  0.1f && isGround == true )
        {
            Debug.Log("dgfghkjl");
         _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
        _animator.SetBool("isJump", !isGround);

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
