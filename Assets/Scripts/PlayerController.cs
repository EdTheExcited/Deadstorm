using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;

    [SerializeField]
    Transform weaponMountPoint;

    int currentWeapon = 0;

    public event EventHandler<OnShootEventArg> OnShoot;
    public class OnShootEventArg : EventArgs
    {
        public Vector3 gunEndPointPos = new Vector3(0, 0, 0);
        public Vector3 shootPos = new Vector3(0, 0, 0);
    }

    public void ChangeWeapon(int n)
    {
        currentWeapon = n;
        if (weaponMountPoint.childCount > 0)
        {
            Destroy(weaponMountPoint.GetChild(0));
        }
        GameObject newGun = Instantiate(weapons[n], weaponMountPoint);
    }

    public float speed;
    private Rigidbody2D body;
    private Vector2 moveVelocity;
    private Vector2 mousePos;
    private float angle;
    public Transform revolverGun;
    private Transform GunEndPointTrans;

    void Start()
    {
        ChangeWeapon(0);
        body = GetComponent<Rigidbody2D>();
        GunEndPointTrans = GameObject.FindGameObjectWithTag("PlayerGun").transform;
    }


    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        HandleAim();
        HandleShoot();
    }

    private void FixedUpdate()
    {
        revolverGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        body.MovePosition(body.position + moveVelocity * Time.fixedDeltaTime);
        // transform.Translate(moveVelocity * Time.deltaTime);
    }

    private void HandleAim()
    {
        mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
    }

    private void HandleShoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // OnShoot?.Invoke(this, new OnShootEventArg
            // {
            //     gunEndPointPos = GunEndPointTrans.position,
            //     shootPos = mousePos,
            // });

            OnShoot?.Invoke(this, new OnShootEventArg
            {
                gunEndPointPos = GunEndPointTrans.position,
                shootPos = mousePos
            });
        }
    }
}
