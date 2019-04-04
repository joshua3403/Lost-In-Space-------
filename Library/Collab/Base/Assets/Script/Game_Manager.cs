using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static bool is_dead_gameManager = false;
    public EnemyGenerator enemy_Generator = null;
    //public bool isPaused = false;

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
    public float time_count = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemy_Generator = this.gameObject.GetComponent<EnemyGenerator>();
        is_dead_gameManager = false;
        this.next_step = STEP.PLAY;
        this.guistyle.fontSize = 30;
    }

    // Update is called once per frame
    void Update()
    {
        this.step_timer += Time.deltaTime;
        this.time_count -= Time.deltaTime;

        // 상태 변화 대기
        if(this.next_step == STEP.NONE)
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


    private void OnGUI()
    {
        switch(this.step)
        {
            case STEP.PLAY:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2, 10f, 200.0f, 20.0f), Mathf.CeilToInt(this.time_count).ToString(), guistyle);

                break;

            case STEP.DIE:
                this.guistyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2, 200.0f, 20.0f), Mathf.CeilToInt(this.clear_time).ToString() + " 초 동안 살아남으셨습니다.", guistyle);
                break;
        }
    }
}
