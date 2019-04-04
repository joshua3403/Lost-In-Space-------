using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    private static bool is_dead_gameManager = false;
    public EnemyGenerator enemy_Generator = null;
    public ObjectCreater object_Generator = null;
    public S_Move s_move = null;
    public UI ui = null;
    private static Vector3 tr_player;
    public bool isPaused = false;

    public enum STEP
    {
        NONE = -1,
        TITLE = 0,
        PLAY,
        DIE,
        NUM
    };

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;
    public float step_timer = 0.0f;
    private float clear_time = 0.0f;
    public GUIStyle guistyle;
    public static float time_count = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy_Generator = this.gameObject.GetComponent<EnemyGenerator>();
        object_Generator = this.gameObject.GetComponent<ObjectCreater>();
        ui = this.gameObject.GetComponent<UI>();
        s_move = GameObject.FindGameObjectWithTag("Player").GetComponent<S_Move>();
        is_dead_gameManager = false;
        this.next_step = STEP.TITLE;
        this.guistyle.fontSize = 50;
        stopGame();
    }

    // Update is called once per frame
    void Update()
    {

        this.step_timer += Time.deltaTime;
        time_count -= Time.deltaTime;
        set_Time_DIE();

        // 상태 변화 대기
        if (this.next_step == STEP.NONE)
        {
            switch (this.step)
            {
                case STEP.TITLE:
                    if (Input.GetMouseButton(0))
                    {
                        startGame();
                        this.next_step = STEP.PLAY;
                    }
                    break;
                case STEP.PLAY:
                    if (is_dead_gameManager)
                    {
                        this.next_step = STEP.DIE;
                    }
                    break;
            }
        }

        while(this.next_step != STEP.NONE)
        {
            this.step = this.next_step;
            this.next_step = STEP.NONE;
            switch (this.step)
            {
                case STEP.DIE:
                    //stopGame();
                    this.clear_time = this.step_timer;
                    if(Input.touchCount > 0)
                    SceneManager.LoadScene("GameScene");                    
                    break;
            }
            this.step_timer = 0.0f;
        }
    }


    public void Set_dead(bool dead)
    {
        is_dead_gameManager = dead;
    }

    public bool Get_dead()
    {
        return is_dead_gameManager;
	}

   public void Set_tr(Vector3 tr)
    {
        tr_player = tr;
    }

    public Vector3 Get_tr()
    {
        return tr_player;
    }   
   
    public void set_Time_DIE()
    {
        if(time_count<= 0)
        {
            Set_dead(true);
        }
    }

    private void OnGUI()
    {
        //Font myFont = (Font)Resources.Load("Font/Tripfive", typeof(Font));

        //guistyle.font = myFont;

        switch (this.step)
        {
            case STEP.TITLE:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 , 500.0f, 300.0f), "우주미아", guistyle);
                break;
            case STEP.PLAY:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 100, 10f, 200.0f, 20.0f), Mathf.CeilToInt(time_count).ToString(), guistyle);

                break;

            case STEP.DIE:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 50, 200.0f, 20.0f), Mathf.CeilToInt(this.clear_time).ToString() + " 초 동안 살아남으셨습니다.", guistyle);
                break;
        }
    }

    public void addTimeCount()
    {
        time_count += 15f;
    }

    public float getTimeCount()
    {
        return time_count;
    }

    // 게임을 멈추는 함수(스크립트를 작동 중지시킨다)
    public void stopGame()
    {
        this.enemy_Generator.enabled = false;
        this.object_Generator.enabled = false;
        this.s_move.enabled = false;
        this.ui.enabled = false;
        Debug.Log("stopgame");
    }

    // 게임을 시작하는 함수(스크립트를 작동 시킨다)
    public void startGame()
    {
        this.enemy_Generator.enabled = true;
        this.object_Generator.enabled = true;
        this.s_move.enabled = true;
        this.ui.enabled = true;
    }
}
