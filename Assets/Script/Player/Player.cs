using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
	int maxHp=15;
	float maxPowSpd=0.4f;
	float maxMoveSpd=3;
	int maxAtk = 50;
	int atk = 1;
	//int pow=5;
	//int spd=5;
	int hp=15;
	int powLevel= 1;
	int spdLevel= 1;
	protected int hittime = 0;
	float grav = 0.1f;
	float chargePow = 0;
	float beforeChargePow = 0;
	float chargeSpd = 0.04f;
	float moveSpd = 1;
	int direction = 1;
	float bulletSize = 2.5f;
	float bulletSizeMax = 6f;
	int optionNum = 0;
	[System.NonSerialized]public Rigidbody2D rg;
	Camera cam;
	public GameObject bullet;
	public GameObject option;
	bool isCharging = false;
	[System.NonSerialized] public bool isMove = false;
	protected SpriteRenderer sprite;
	//bool isLand = false;

	// Use this for initialization
	void Start () {
		//level = 1;

		atk = 1;
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		rg = GetComponent<Rigidbody2D>();
		EventManager.OnTouchBegin.AddListener (SetTouchPos);
		EventManager.OnTouchMove.AddListener (MoveTouchPos);
		EventManager.OnTouchEnd.AddListener (EndTouch);
		EventManager.OnJump.AddListener (Jump);
		EventManager.OnAtkBegin.AddListener (ChargeStart);
		EventManager.OnAtkEnd.AddListener (Attack);
		//Attack ();
		sprite = GetComponent<SpriteRenderer> ();
	}
	//touch
	Vector3 touchPos;
	Vector3 touchPosOrigin;
	int touchNum;
	void SetTouchPos(int num){
		if (TouchInput.GetTouchWorldPosition (cam, num).x < 0) {
			touchPos = TouchInput.GetTouchWorldPosition (cam, num);
			touchPosOrigin = touchPos;
			touchNum = num;
		}
	}
	void MoveTouchPos(int num){
		if (touchNum == num) {
			if (touchPosOrigin.x < 0) {//left of screen
				float length = TouchInput.GetTouchWorldPosition (cam,num).x - touchPos.x;
				if (length > 0.2f) {
					length = 0.2f;
					touchPos.x = TouchInput.GetTouchWorldPosition (cam, num).x - 0.2f;  
				}
				if (length < -0.2f) {
					length = -0.2f;
					touchPos.x = TouchInput.GetTouchWorldPosition (cam, num).x + 0.2f;  
				}
				if (length > 0.05f){
					direction = 1;
					Move (direction,length);
				}
				else if (length < -0.05f){
					direction = -1;
					Move (direction,length);
				}
				else {
					Move (0,0);
				}
			}
		}
	}
	void EndTouch(int num){
		if (touchNum == num ) {
			Move (0,0);
			touchNum = -1;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (rg.velocity.magnitude <= 0)
			isMove = false;
		else
			isMove = true;
		Grav ();
		MoveLimit ();
		if (isCharging == true && chargePow < 3f)chargePow += chargeSpd;
		if (chargePow >= 3f)chargePow = 3f;
		HitTime ();
		if (hp <= 0)rg.velocity = new Vector2 (0, rg.velocity.y);

	}
	void Move(int d,float len){
		if (d == 0) {
			rg.velocity = new Vector2(0,rg.velocity.y);

		}
		if (d == 1) {
			rg.velocity = new Vector2(moveSpd * len/0.2f,rg.velocity.y);
			if (transform.localScale.x < 0)
				transform.localScale = new Vector2 (2, 2);
		}
		if (d == -1) {
			rg.velocity = new Vector2(moveSpd * len/0.2f,rg.velocity.y);
			if (transform.localScale.x > 0)
				transform.localScale = new Vector2 (-2, 2);
		}
	}
	void Jump(){
		if(hp>0)rg.velocity = new Vector2(rg.velocity.x,2f + moveSpd/5f);
	}
	void Grav(){
		if(rg.velocity.y>-2f)rg.velocity = new Vector2(rg.velocity.x,rg.velocity.y - 0.1f);
	}
	void MoveLimit(){
		if (transform.position.x >= 1.75f) {
			transform.position = new Vector3 (1.75f,transform.position.y,transform.position.z);
		}
		if (transform.position.x <= -1.75f) {
			transform.position = new Vector3 (-1.75f,transform.position.y,transform.position.z);
		}
		if (transform.position.y >= 0.9f) {
			transform.position = new Vector3 (transform.position.x,0.9f,transform.position.z);
			if(rg.velocity.y>0)rg.velocity = new Vector2(rg.velocity.x,0);
		}
	}
	void ChargeStart(){
		if(hp>0)if(isCharging == false)isCharging = true;
	}
	void Attack(){
		if(hp>0)if (isCharging == true) {
			GameObject b = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			if (b.GetComponent<BulletBase> ())
				b.GetComponent<BulletBase> ().SetPower (chargePow,direction);
			beforeChargePow = chargePow;
			chargePow = 0;

			isCharging = false;
			EventManager.Invoke (ref EventManager.OnPlayerAttacked);
		}
	}
	void HitTime(){
		if (hittime > 0) {

			hittime++;
			if(hittime >8)sprite.color = Color.white;
			if (hittime > 25) {
				hittime = 0;

			}
		}
	}
	public void HitBullet(int val,int num){
		if (num >= 0) {
			if (val == -1) {
				EventManager.Invoke (ref EventManager.OnCatch);
			} else {
				EventManager.Invoke (ref EventManager.OnUpAbility);
				//if(level < 99)level += 1;
				//EventManager.Invoke (ref EventManager.OnUpLevel);
			}
			if (val == 0) {
				
				if (maxHp < 999)
					maxHp+=num * 2;
				if (hp < maxHp)
					hp += num * 4;
				if (maxHp > 999)
					maxHp = 999;
				if (hp > maxHp)
					hp = maxHp;
				EventManager.Invoke (ref EventManager.OnUpHp);
			}
			if (val == 1) {
				if (powLevel < 50)
					powLevel+= num;
				
				EventManager.Invoke (ref EventManager.OnUpPower);
				if (chargeSpd < maxPowSpd)
					chargeSpd += num * (maxPowSpd / 50f);
				if (maxPowSpd < chargeSpd)
					chargeSpd = maxPowSpd;
				if (atk < maxAtk)
					atk += num;
				if (atk > maxAtk)
					atk = maxAtk;
			}
			if (val == 2) {
				if (spdLevel < 50)
					spdLevel+=num;
				EventManager.Invoke (ref EventManager.OnUpSpd);
				if (moveSpd < maxMoveSpd)
					moveSpd += num * (maxMoveSpd / 50f);
				if (maxMoveSpd < moveSpd)
					moveSpd = maxMoveSpd;
			}
			if (val == 3) {
				EventManager.Invoke (ref EventManager.OnUpSize);
				if (bulletSize < bulletSizeMax)
					bulletSize += num * (bulletSizeMax / 40f);
				if (bulletSizeMax < bulletSize)
					bulletSize = bulletSizeMax;
			}
			if (val == 4) {
				//EventManager.Invoke (ref EventManager.OnUpSpd);
				if (optionNum <= 1) {
					optionNum ++;
					Instantiate (option,transform.position,Quaternion.identity);

				}
			}
		}
	}
	public float RetPow(){
		return chargePow;
	}
	public int RetHP(){
		return hp;
	}
	public int RetMaxHP(){
		return maxHp;
	}
	public float RetCharge(){
		return beforeChargePow;
	}
	void OnTriggerStay2D(Collider2D c){
		if (c.transform.tag == "Enemy") {
			if (hittime == 0) {
				if (hp > 0) {
					hp-=c.GetComponent<EnemyBase>().atk;
					if (hp <= 0)
						hp = 0;
					hittime = 1;
					EventManager.Invoke (ref EventManager.OnDamaged);
					sprite.color = Color.red;
				}
				rg.velocity = new Vector2 (rg.velocity.x, 1f);
				if (hp <= 0) {
					GetComponent<Collider2D> ().enabled = false;
					transform.localScale = new Vector2 (transform.localScale.x, -2);
					EventManager.Invoke (ref EventManager.OnPlayerMissed);
				}
			}
		}
	}
	public int RetAtk(){
		return atk;
	}
	public float RetSize(){
		return bulletSize;
	}
	public int RetPowLevel(){
		return powLevel;
	}
	public int RetSpdLevel(){
		return spdLevel;
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.transform.tag == "Land") {
			EventManager.Invoke (ref EventManager.OnLand);
			//if (isLand == false) {
			//	isLand = true;

			//}
		}

	}
}
