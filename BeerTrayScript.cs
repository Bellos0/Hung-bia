using UnityEngine;

public class BeerTrayScript : BeerBottle
{
    // Start is called before the first frame update
    float xInput;
    float moveSpeed = 5f;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponentInChildren<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
       
        if (serviceBottle.CountValue() > 5)
        {
            Motion(false);
        }
        else
            Motion(true);
    }
    private void Motion(bool enable)
    {
        if (enable)
        {
            xInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xInput * moveSpeed, 0);

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

}
