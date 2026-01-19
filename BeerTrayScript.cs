using UnityEngine;

public class BeerTrayScript : BeerBottle
{
    protected static BeerTrayScript traySer;
    public static BeerTrayScript Instance => traySer;
    float xInput;
    float moveSpeed = 5f;
    AudioSource adTray;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponentInChildren<Rigidbody2D>();
        adTray = GetComponentInChildren<AudioSource>();
        traySer = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (logical.beerBreak)
            Motion(false);
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

    public void MissingSound()
    {
        if (adTray != null)
        {

            adTray.Play();
            //Debug.Log("turn on missing sound");
        }

    }

}
