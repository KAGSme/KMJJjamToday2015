using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	
    public float Limit = 0.1f;
    public float Speed = 4, Accel = 0.5f, ChargeTime = 0.75f;
    public float WanderMn = 2;
    public GameObject laserPrefab;
    public GameObject chargeFireShape;

	float Vel = 0, DesVel;
    public float Timer;
    Transform Trnsfrm;

    void Awake() {
        Trnsfrm = transform;


    }
    void Start() {
        DesVel = Vel = ( Trnsfrm.position.y > 0)? -Speed: Speed;
        wander();
    }
    void wander() {
        Stt = State.Move;

        var p = Trnsfrm.position; 
        float bounds = Camera.main.ScreenToWorldPoint( new Vector3( 0,Screen.height*Limit,0 ) ).y;


        float dir = Mathf.Sign(DesVel);
        float max = (bounds*dir - p.y)/Speed *dir;

        Timer = max* Mathf.Pow( Random.value, 1.2f ); 
         //       Debug.Log("dir "+dir +"  Speed "+Speed+"  DesVel "+DesVel+"  max "+max +"  Timer "+Timer +"  dis "+ (bounds*dir - p.y));

        if( max > WanderMn  && Timer < WanderMn ) Timer = WanderMn;
    }
    enum State {
        Move, ChargeFire, Accel
    };
    State Stt;

    void Update () {
	    
        var p = Trnsfrm.position; 
        float bounds = Camera.main.ScreenToWorldPoint( new Vector3( 0,Screen.height*Limit,0 ) ).y;

        switch( Stt ) {
            case State.Move: 
                
                if( (Timer -= Time.deltaTime) < 0.0f 
                || ( (p.y < -bounds && Vel < 0) )
                || ( (p.y > bounds && Vel > 0) ) )  {
                    Stt = State.ChargeFire;
                    Timer = ChargeTime;
                   // DesVel = - DesVel;
                }
                break;
            case State.ChargeFire:
                var md = (Timer - (ChargeTime - Accel *0.7f))/(Accel *0.7f);
                if( md < 0.0f ) {
                    md = Vel = 0;
                    chargeFireShape.GetComponent<SpriteRenderer>().color = Color.Lerp( Color.white, Color.clear, Mathf.Pow( Timer /(ChargeTime - Accel), 2.5f )  );
                } else
                    Vel = Mathf.Lerp( 0, DesVel, md );
                if((Timer -= Time.deltaTime) < 0.0f) {
                    if (Camera.main.WorldToScreenPoint(transform.position).x < Screen.width / 2)
                    {
                        var laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 270));
                        laser.GetComponent<Laser>().angle = Vector2.right;
                    }
                    else
                    {
                        var laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.Euler(0, 0, 90));
                        laser.GetComponent<Laser>().angle = Vector2.left;
                    }
                    Stt = State.Accel;
                    Timer = Accel;
                    DesVel = -DesVel;
                }
                break;
            case State.Accel:
                Vel = Mathf.Lerp( DesVel, 0, Timer/Accel );
                chargeFireShape.GetComponent<SpriteRenderer>().color = Color.Lerp( Color.clear, Color.white, Timer/Accel );
    
                if((Timer -= Time.deltaTime) < 0.0f) {
                    
                    wander();
                }
                break;
        }

        
        p.y += Vel*Time.deltaTime; Trnsfrm.position = p;
	}

    void OnDestroy() {

        SpawnScript.spawnthingy.delayedRespawn();
    }




}
