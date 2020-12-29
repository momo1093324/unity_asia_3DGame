using UnityEngine;
using UnityEngine.AI;   //引用人工智慧API

public class Enemy : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    private Animator ani;
    private float timer;        //計時器

    [Header("移動速度"), Range(0, 50)]
    public float speed = 3;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 2.5f;
    [Header("攻擊冷卻時間"), Range(0, 50)]
    public float cd = 2f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();     //取得身上的元件(代理器-狗狗)
        ani=GetComponent<Animator>();

        player = GameObject.Find("小明").transform;       //尋找其他遊戲物件.變形物件

        //代理器的速度與停止距離
        nav.speed = speed;
        nav.stoppingDistance = stopDistance;
    }
    private void Update()
    {
        Track();
        Attack();
    }
    //攻擊
    private void Attack()
    {
        if (nav.remainingDistance < stopDistance)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = transform.position.y;

            transform.LookAt(pos);

            if (timer>=cd)
            {
            ani.SetTrigger("攻擊開關");
                timer = 0;
            }
          
        }
    }
    //追蹤
    private void Track()
    {
        nav.SetDestination(player.position);        //代理器.設定目的地(玩家的座標)

        ani.SetBool("跑步開關", nav.remainingDistance > stopDistance);
    }
}
