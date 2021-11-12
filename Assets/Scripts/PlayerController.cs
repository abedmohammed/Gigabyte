using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedIncrease;
    public float normalSpeed;
    public float maxSpeed;
    public float speed;
    private float moveInput;

    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float slideSpeed;
    public float slideTimer;
    public bool inSlide;
    public float SlideCD;
    public float maxSlideCD;
    public bool sliding;

    private Animator anim;

    private int index;
    public GameObject[] shot;
    private GameObject chosenShot;
    public Transform shotPosition;
    public float shotDelayCD;
    private float ShotDelay;
    public float shotRate;
    private float nextShot;

    private bool shooting;
    private bool shootingIdle;
    private bool shootingJump;
    private bool shootingRun;
    private bool shootingSlide;

    public KeyCode jump;
    public KeyCode dash;
    public KeyCode shoot;

    public GameObject shootParticle;
    public GameObject smokeParticle;

    public float smokeDelayCD;
    public float smokeDelay;

    public Transform smokeSpot;
    public Transform shootSpot;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool knocked;

    public Coroutine PlayerColor;
    public Coroutine PlayerChargeOne;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    public bool flashReset;

    private float timeBeforeCharge;
    public float timeBeforeChargeCD;

    public GameObject chargeStartNoise;
    public GameObject chargeNoise;

    private bool noisePlaying;

    //private GameObject noise;
    private GameObject chargingEffect;

    private HealthManager healthManager;

    public GameObject chargeEffect;

    public Transform chargeSpot;

    public GameObject level2Shot;
    public GameObject level3Shot;

    public string shotName;

    private GameObject chargedShot;
    public GameObject chargingNoises;
    public GameObject chargingStartNoises;

    public bool stoppedCharging;

    private bool normalColor;


    void Start()
    {

        ShotDelay = shotDelayCD;
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        healthManager = FindObjectOfType<HealthManager>();

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default");

        timeBeforeCharge = timeBeforeChargeCD;
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
        {
            moveInput = 1;
        }
        if (moveInput < 0)
        {
            moveInput = -1;
        }


        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && Input.GetAxisRaw("Jump") == 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;


        //==================================================================================================
        //Sliding Left
        if (moveInput == -1 && Input.GetButton("Dash") && isGrounded && transform.localScale.x < 0 && slideTimer > 0f)
        {
            SlideCD = maxSlideCD;
            inSlide = true;
            rb.velocity = new Vector2(-slideSpeed, rb.velocity.y);
            slideTimer -= Time.deltaTime;
        }

        //Sliding Right
        if (moveInput == 1 && Input.GetButton("Dash") && isGrounded && transform.localScale.x > 0 && slideTimer > 0f)
        {
            SlideCD = maxSlideCD;
            inSlide = true;
            rb.velocity = new Vector2(slideSpeed, rb.velocity.y);
            slideTimer -= Time.deltaTime;

        }

        if (moveInput != 0 && Input.GetButton("Dash"))
        {
            sliding = true;
        }
        else
        {
            sliding = false;
        }

        if (slideTimer <= 0 || !sliding || !isGrounded || rb.velocity.x == 0) //finish slide
        {
            inSlide = false; //no longer in slide
        }

        if (!inSlide && slideTimer < 0.6f)
        {

            slideTimer = 0f;

        }

        if (!inSlide && SlideCD > 0)
        {
            SlideCD -= Time.deltaTime; //Start cooldown timer from 2 seconds if not in slide and cooldown not 0 already
        }

        if (!inSlide && SlideCD <= 0) //if not in slide and slide cooldown is at 0, slide timer is reset
        {
            slideTimer = 0.6f;
        }
        //==================================================================================================

        if (knockbackCount <= 0)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            flashReset = false;
        }
        else
        {
            if (knockFromRight)
            {
                knocked = true;
                rb.velocity = new Vector2(-knockback, knockback);
                //PlayerColor = StartCoroutine(ChangePlayerColour());

            }
            if (!knockFromRight)
            {
                knocked = true;
                rb.velocity = new Vector2(knockback, knockback);
                //PlayerColor = StartCoroutine(ChangePlayerColour());
            }
            knockbackCount -= Time.deltaTime;

        }

        if(knockbackCount > 0 && !flashReset)
        {
            PlayerColor = StartCoroutine(ChangePlayerColour());
            flashReset = true;
        }

        if (knocked)
        {
            if (isGrounded)
            {
                knocked = false;
            }
        }

        if (!knocked)
        {
            if (rb.velocity.x > 0 && knockbackCount <= 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (rb.velocity.x < 0 && knockbackCount <= 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (normalColor && myRenderer.color == Color.cyan)
        {
            myRenderer.color = Color.white;
        }
    }

    void Update()
    {

        print(PlayerPrefs.GetInt("enemiesKilled"));

        if (Input.GetAxisRaw("Jump") == 1 && isGrounded)
        {
            if (!inSlide)
            {
                speed = normalSpeed;
                rb.velocity = Vector2.up * jumpForce;
            } else if(inSlide)
            {
                speed += speedIncrease;
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        if (normalColor && myRenderer.color == Color.cyan)
        {
            myRenderer.color = Color.white;
        }


        //if (!isGrounded && Input.GetKeyDown(dash) && speed == normalSpeed)
        //{
        //speed += speedIncrease;
        //}

        if (!isGrounded)
        {
            SlideCD = maxSlideCD;
            slideTimer = 0f;
        }

        if (speed > normalSpeed && !inSlide && isGrounded)
        {
            speed = normalSpeed;
        }
        else if (isGrounded && inSlide)
        {
            speed = slideSpeed;
        }
        else if (!isGrounded && inSlide)
        {
            speed = normalSpeed;
        }

        if (rb.velocity.x >= 10 || rb.velocity.x <= -10)
        {

            smokeDelay -= Time.deltaTime;

            if (smokeDelay <= 0)
            {
                smokeDelay = smokeDelayCD;
                Instantiate(smokeParticle, smokeSpot.position, smokeSpot.rotation);

            }
        }


        //---------------------------------------------------------------------
        if (Input.GetButtonDown("Fire1") && Time.time > nextShot)
        {
            nextShot = Time.time + shotRate;
            index = Random.Range(0, shot.Length);
            chosenShot = shot[index];
            Instantiate(chosenShot, shotPosition.position, shotPosition.rotation);
            var shotParticle = Instantiate(shootParticle, shootSpot.position, shootSpot.rotation);
            shotParticle.transform.parent = gameObject.transform;
            ShotDelay = shotDelayCD;
            shooting = true;
        }

        if (Input.GetButton("Fire1") && stoppedCharging)
        {

            timeBeforeCharge -= Time.deltaTime;
            if (timeBeforeCharge <= 0)
            {
                if (!noisePlaying)
                {
                    chargingEffect = Instantiate(chargeEffect, chargeSpot.position, chargeSpot.rotation);
                    chargingEffect.transform.parent = chargeSpot.transform;
                    chargingNoises = Instantiate(chargeNoise, transform.position, transform.rotation);
                    noisePlaying = true;
                }
                PlayerChargeOne = StartCoroutine(playerChargeOne());
            }

        }

        if (Input.GetButtonUp("Fire1") && timeBeforeCharge <= 0 && timeBeforeCharge >= -1)
        {

            Instantiate(level2Shot, shotPosition.position, shotPosition.rotation);
            var shotParticle = Instantiate(shootParticle, shootSpot.position, shootSpot.rotation);
            shotParticle.transform.parent = gameObject.transform;
            timeBeforeCharge = timeBeforeChargeCD;
            DestroyObject(chargingNoises);
            DestroyObject(chargingEffect);
            noisePlaying = false;
            stoppedCharging = true;

        }

        if (Input.GetButtonUp("Fire1") && timeBeforeCharge < -1 && timeBeforeCharge >= -10)
        {

            Instantiate(level3Shot, shotPosition.position, shotPosition.rotation);
            var shotParticle = Instantiate(shootParticle, shootSpot.position, shootSpot.rotation);
            shotParticle.transform.parent = gameObject.transform;
            timeBeforeCharge = timeBeforeChargeCD;
            chargedShot = GameObject.FindGameObjectWithTag("ChargingEffect");
            DestroyObject(chargedShot);
            DestroyObject(chargingNoises);
            DestroyObject(chargingEffect);
            noisePlaying = false;
            stoppedCharging = true;

        }

        if (!Input.GetButton("Fire1"))
        {

            timeBeforeCharge = timeBeforeChargeCD;
            DestroyObject(chargingNoises);
            chargedShot = GameObject.FindGameObjectWithTag("ChargingEffect");
            DestroyObject(chargedShot);
            DestroyObject(chargingEffect);
            noisePlaying = false;
            stoppedCharging = true;
        }

        if (timeBeforeCharge <= -10)
        {

            timeBeforeCharge = timeBeforeChargeCD;
            DestroyObject(chargingNoises);
            chargedShot = GameObject.FindGameObjectWithTag("ChargingEffect");
            DestroyObject(chargedShot);
            DestroyObject(chargingEffect);
            noisePlaying = false;
            stoppedCharging = false;
        }

        if (HealthManager.playerHealth <= 0)
        {

            timeBeforeCharge = timeBeforeChargeCD;
            DestroyObject(chargingNoises);
            DestroyObject(chargeSpot.gameObject);
            noisePlaying = false;

        }
        //---------------------------------------------------------------------
        if (!stoppedCharging)
        {
            shooting = false;
        }
        if (Input.GetButtonUp("Fire1") || timeBeforeCharge <= -10)
        {
            shooting = false;
        }

        if (shooting && rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            shootingIdle = true;
        }
        else
        {
            shootingIdle = false;
        }

        if (shooting && rb.velocity.x != 0 && rb.velocity.y == 0 && !inSlide)
        {
            shootingRun = true;
        }
        else
        {
            shootingRun = false;
        }

        if (shooting && rb.velocity.y != 0)
        {
            shootingJump = true;
        }
        else
        {
            shootingJump = false;
        }

        if (shooting && inSlide)
        {
            shootingSlide = true;
        }
        else
        {
            shootingSlide = false;
        }


        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("grounded", isGrounded);
        anim.SetBool("sliding", inSlide);
        anim.SetBool("shootingIdle", shootingIdle);
        anim.SetBool("shootingRun", shootingRun);
        anim.SetBool("shootingJump", shootingJump);
        anim.SetBool("shootingSlide", shootingSlide);
    }

    public IEnumerator ChangePlayerColour()
    {
        gameObject.layer = LayerMask.NameToLayer("Invulnerable");
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        yield return new WaitForSeconds(0.1f);
        whiteSprite();
        yield return new WaitForSeconds(0.1f);
        normalSprite();
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    public IEnumerator playerChargeOne()
    {
        if (Input.GetKey(shoot) && timeBeforeCharge >= -10 && stoppedCharging)
        {
            //Instantiate(chargeNoise, transform.position, transform.rotation);
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            if (normalColor && myRenderer.color == Color.cyan)
            {
                myRenderer.color = Color.white;
            }
            yield return new WaitForSeconds(.1f);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
        normalColor = true;
    }

    void normalSprite()
    {
        myRenderer.material.shader = shaderSpritesDefault;
        myRenderer.color = Color.white;
        normalColor = false;
    }

}
