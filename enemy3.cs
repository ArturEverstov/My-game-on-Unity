using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy3 : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent agent;
    public TextMeshProUGUI Mission;
    public TextMeshProUGUI HP_text;
    public TextMeshProUGUI ARM_text;
    public GameObject player;
    public float HealthPoints = 100;
    public float ArmorPoints = 100;
    float distanceToPlayer;
    float distance = 100f;
    Vector3 startPosition;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startPosition = agent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * -10f, Color.green);
        Debug.DrawRay(transform.position, transform.forward * 10f, Color.green);
        Debug.DrawRay(transform.position, transform.right * -10f, Color.green);
        Debug.DrawRay(transform.position, transform.right * 10f, Color.green);

        distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
        if(distanceToPlayer <= distance){
            agent.SetDestination(player.transform.position);
        }else{
            agent.SetDestination(startPosition);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "FPSController"){
            ArmorPoints = ArmorPoints - 10;
            ARM_text.text = ArmorPoints + " ARM";
            if(ArmorPoints <= 0)
            {
                HealthPoints = HealthPoints - 25;
                HP_text.text = HealthPoints + " HP";
                if(HealthPoints <= 0)
                {
                    Mission.text = "You LOSE!";
                }
            }

        }
    }
}