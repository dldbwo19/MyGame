using UnityEngine;
using System.Collections;

public class BaseCharacterController : MonoBehaviour {

	
	public Vector2			velocityMin				 = new Vector2(-10.0f,-10.0f);
	public Vector2			velocityMax				 = new Vector2(+10.0f,+10.0f);

	[System.NonSerialized] public float		hpMax			= 1.0f;
	[System.NonSerialized] public float		hp	 			= 1.0f;
	[System.NonSerialized] public float		dir	 			= 1.0f;
	[System.NonSerialized] public float		speed			= 4.0f;
	[System.NonSerialized] public float 	basScaleX		= 1.0f;
	[System.NonSerialized] public bool		activeSts	 	= false;
	[System.NonSerialized] public bool 		jumped 			= false;
	[System.NonSerialized] public bool 		grounded 		= false;
	[System.NonSerialized] public bool 		groundedPrev 	= false;
	[System.NonSerialized] public Animator	animator;
	protected Transform		groundCheck_L;
	protected Transform 	groundCheck_R;

	
	protected float 	 	speedVx 			= 0.0f;
	protected float 		speedVxAddPower		= 0.0f;
	protected float 		gravityScale 		= 1.0f;
	protected float 		jumpStartTime		= 0.0f;

	protected GameObject	groundCheck_OnRoadObject;
	protected GameObject	groundCheck_OnMoveObject;
	protected GameObject	groundCheck_OnEnemyObject;

	protected virtual void Awake () {

        animator 			= GetComponentInChildren <Animator>();
		groundCheck_L 		= transform.Find("GroundCheck_L");
		groundCheck_R 		= transform.Find("GroundCheck_R");

		dir 				= (transform.localScale.x > 0.0f) ? 1 : -1;
		basScaleX 			= transform.localScale.x * dir;
		transform.localScale = new Vector3 (basScaleX, transform.localScale.y, transform.localScale.z);

		activeSts 			= true;
		gravityScale 		= GetComponent<Rigidbody2D>().gravityScale;
	}

	protected virtual void Start () {
	}
	
	protected virtual void Update () {	
	}

	protected virtual void FixedUpdate () {	
        
        //낙하 사망
		if (transform.position.y < -20.0f) {
			Dead(false);
		}

		groundedPrev = grounded;
		grounded 	 = false;

		groundCheck_OnRoadObject = null;
		groundCheck_OnMoveObject = null;
		groundCheck_OnEnemyObject = null;

		Collider2D[][] groundCheckCollider = new Collider2D[2][];
		groundCheckCollider [0] = Physics2D.OverlapPointAll (groundCheck_L.position);
		groundCheckCollider [1] = Physics2D.OverlapPointAll (groundCheck_R.position);

		foreach(Collider2D[] groundCheckList in groundCheckCollider) {
			foreach(Collider2D groundCheck in groundCheckList) {
				if (groundCheck != null) {
					if (!groundCheck.isTrigger) {
						grounded = true;
						if (groundCheck.tag == "Road") {
							groundCheck_OnRoadObject = groundCheck.gameObject;
						} else 
						if (groundCheck.tag == "MoveObject") {
							groundCheck_OnMoveObject = groundCheck.gameObject;
						} else 
						if (groundCheck.tag == "Enemy") {
							groundCheck_OnEnemyObject = groundCheck.gameObject;
						}
					}
				}
			}
		}

		FixedUpdateCharacter (); 

		GetComponent<Rigidbody2D>().velocity = new Vector2 (speedVx, GetComponent<Rigidbody2D>().velocity.y);


		float vx = Mathf.Clamp (GetComponent<Rigidbody2D>().velocity.x, velocityMin.x, velocityMax.x);
		float vy = Mathf.Clamp (GetComponent<Rigidbody2D>().velocity.y, velocityMin.y, velocityMax.y);
		GetComponent<Rigidbody2D>().velocity = new Vector2(vx,vy);
	}

	protected virtual void FixedUpdateCharacter () {	
	}

	public virtual void ActionMove(float n) {
		if (n != 0.0f) {
			dir 	= Mathf.Sign(n);
			speedVx = speed * n;
			animator.SetTrigger("Run");
		} else {
			speedVx = 0;
			animator.SetTrigger("Idle");
		}
	}
	
	public virtual void Dead (bool gameOver) {
		if (!activeSts) {
			return;
		}
		activeSts = false;
		animator.SetTrigger("Dead");
        FindObjectOfType<CanvasController>().GameOver();
	}

	public virtual bool SetHP(float _hp,float _hpMax) {
		hp 	  		= _hp;
		hpMax 		= _hpMax;
		return (hp <= 0);
	}
}
