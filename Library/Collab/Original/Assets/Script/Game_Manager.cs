using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static bool is_dead_gameManager = false;
    public EnemyGenerator enemy_Generator = null;
    public ObjectCreater object_Generator = null;
    public S_Move s_move = null;
    public bool isPaused = false;

    public enum STEP
    {
        NONE = -1,
        PLAY = 0,
        DIE,
        NUM
    };

    public STEP step = STEP.NONE;
    public STEP next_step = STEP.NONE;
    public float step_timer = 0.0f;
    private float clear_time = 0.0f;
    public GUIStyle guistyle;
    public static float time_count = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy_Generator = this.gameObject.GetComponent<EnemyGenerator>();
        object_Generator = this.gameObject.GetComponent<ObjectCreater>();
        s_move = GameObject.FindGameObjectWithTag("Player").GetComponent<S_Move>();
        is_dead_gameManager = false;
        this.next_step = STEP.PLAY;
        this.guistyle.fontSize = 30;
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
                    this.enemy_Generator.enabled = false;
                    this.object_Generator.enabled = false;
                    this.s_move.enabled = false;
                    this.clear_time = this.step_timer;
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

    public void set_Time_DIE()
    {
        if(time_count<= 0)
        {
            Set_dead(true);
        }
    }

    private void OnGUI()
    {
        switch(this.step)
        {
            case STEP.PLAY:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2, 10f, 200.0f, 20.0f), Mathf.CeilToInt(time_count).ToString(), guistyle);

                break;

            case STEP.DIE:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200.0f, 20.0f), Mathf.CeilToInt(this.clear_time).ToString() + " 초 동안 살아남으셨습니다.", guistyle);
                break;
        }
    }

    public void addTimeCount()
    {
        Debug.Log("Added!");
        time_count += 20f;
    }

    public float getTimeCount()
    {
        return time_count;
    }
}
