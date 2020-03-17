using UnityEngine;
using System.Collections;

public class PlayerController : BaseCharacterController {

						public float 	initHpMax = 1.0f;
    public float initHp = 1.0f;
	[Range(0.1f,10.0f)] public float 	initSpeed = 4.0f;



    public int jumpCount= 0;
    public bool onGrenade = false;

    bool			breakEnabled		= true;
	float 			groundFriction		= 0.0f;
    bool gameover = false;
    
    static int grenadeCount = 0;

    CameraController cameraController;
    CanvasController canvasController;

    protected override void Awake () {
		base.Awake ();

		speed = initSpeed;
		SetHP(initHpMax,initHpMax);
	}

    protected override void FixedUpdateCharacter()
    {
		if (jumped) {
			if ((grounded && !groundedPrev) || (grounded && Time.fixedTime > jumpStartTime + 1.0f)) {
				animator.SetTrigger ("Idle");
				jumped = false;
				jumpCount = 0;
			}
		} 
		if (!jumped) {
			jumpCount = 0;
		}

		transform.localScale = new Vector3 (basScaleX * dir, transform.localScale.y, transform.localScale.z);

		if (jumped && !grounded) {
			if (breakEnabled) {
				breakEnabled = false;
				speedVx *= 0.9f;
			}
		}

		if (breakEnabled) {
			speedVx *= groundFriction;
		}

	}


	public override void ActionMove(float n) {
		if (!activeSts) {
			return;
		}
		
		float dirOld = dir;
		breakEnabled = false;
		

		float moveSpeed = Mathf.Clamp(Mathf.Abs (n),-1.0f,+1.0f);
        animator.SetFloat("MovSpeed", moveSpeed);


        if (n != 0.0f) {
			dir 	  = Mathf.Sign(n);
			moveSpeed = (moveSpeed < 0.5f) ? (moveSpeed * (1.0f / 0.5f)) : 1.0f;
			speedVx   = initSpeed * moveSpeed * dir;
		}
        else {
			breakEnabled = true;
		}
		
		if (dirOld != dir) {
			breakEnabled = true;
		}
	}

	public void ActionJump() {
        switch (jumpCount) {
            case 0:
                if (grounded) {
                    animator.SetTrigger("Jump");
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * 5.0f;
                    jumpStartTime = Time.fixedTime;
                    jumped = true;
                    jumpCount++;
                }
                if (!grounded)
                {
                    animator.SetTrigger("Jump");
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * 5.0f;
                    jumpStartTime = Time.fixedTime;
                    jumped = true;
                    jumpCount = jumpCount + 2;
                }
                break;
            case 1:
                if (!grounded) {
                    animator.SetTrigger("Jump");
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5.0f);
                    jumped = true;
                    jumpCount++;
                    //moreJump = !moreJump;
                }
                break;
        }
	}

    public void GetGrenade()
    {
        grenadeCount = 10;
        onGrenade = true;
    }
    public bool CheckGrenade()
    {
        if (onGrenade)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void UsedGrenade()
    {
        grenadeCount = grenadeCount - 1;
        if (grenadeCount <= 0)
        {
            onGrenade = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyObject")
        {
            //Debug.Log("데미지 받음");
            initHp--;
            gameover = SetHP(initHp, initHpMax);
            if (gameover == true)
            {
                //Debug.Log("게임 오버");
                Dead(gameover);
            }
        }
        if (other.tag == "Stage1" || other.tag == "Stage2" || other.tag == "Stage3" ||other.tag == "Stage4" || other.tag == "Stage5" || other.tag == "Stage6")
        {
            cameraController = FindObjectOfType<CameraController>();

            if (other.tag == "Stage1")
            {
                Debug.Log("1번 스테이지 이동");
                cameraController.MoveCamera(0);
            }
            if (other.tag == "Stage2")
            {
                Debug.Log("2번 스테이지 이동");
                cameraController.MoveCamera(1);
            }
            if (other.tag == "Stage3")
            {
                Debug.Log("3번 스테이지 이동");
                cameraController.MoveCamera(2);
            }
            if (other.tag == "Stage4")
            {
                Debug.Log("4번 스테이지 이동");
                cameraController.MoveCamera(3);
            }
            if (other.tag == "Stage5")
            {
                Debug.Log("5번 스테이지 이동");
                cameraController.MoveCamera(4);
            }
            if (other.tag == "Stage6")
            {
                Debug.Log("6번 스테이지 이동");
                cameraController.MoveCamera(5);
            }
        }
        
        
    }
}


