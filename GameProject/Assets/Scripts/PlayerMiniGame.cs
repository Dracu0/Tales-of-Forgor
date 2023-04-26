using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiniGame : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    private float MaxWidth;
    private bool viradoDireita;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        rb = GetComponent<Rigidbody2D>();
        Vector3 UpperC = new Vector3(Screen.width, Screen.height);
        Vector3 dim = cam.ScreenToWorldPoint(UpperC);
        MaxWidth = dim.x - GetComponent<Renderer>().bounds.extents.x;
        viradoDireita = true;

    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Mouse X");

        if ((dirX < 0 && viradoDireita) || (dirX > 0 && !viradoDireita)) Flip();
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 scale = transform.localScale;
        scale.x *= -1;       //scale.x= scale.x * (-1);
        transform.localScale = scale;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 rawpos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(Mathf.Clamp(rawpos.x, -MaxWidth, MaxWidth), -7.0f);
        rb.MovePosition(targetPos);
    }
}
