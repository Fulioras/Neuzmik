using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    private Nustatymai config;
    public Animator animator;
    private bool Gaudo = false;
    private float priesoGreitis;
    private float priesoPastebejimas;

        private void Start()
    {
        GameObject configObject = GameObject.FindGameObjectWithTag("Nustatymai");
        if (configObject != null)
        {
            config = configObject.GetComponent<Nustatymai>();
        }
        else
        {
            Debug.LogError("Could not find AttackConfig object in scene.");
        }
        priesoGreitis = config.speed;
        priesoPastebejimas = config.detectionRange;
                if(gameObject.CompareTag("FastEnemy")){
                    priesoGreitis = priesoGreitis * 2;
        }
        else if(gameObject.CompareTag("bigEnemy")){
                    priesoGreitis = priesoGreitis / 120 * 100;
        }
        else if(gameObject.CompareTag("Bosas")){
                    priesoGreitis = priesoGreitis * 30;
                    priesoPastebejimas = priesoPastebejimas * 2;

        }

    }

    private void Update()
    {
        // Calculate the distance between this object and the target
        float distance = Vector2.Distance(transform.position, target.position);

        if(gameObject.CompareTag("Final")){
        if (distance <= priesoPastebejimas|| Gaudo == true)
        {
            Gaudo = true;
            EnergyBar.decreaseEnabled = false;
            // Calculate the direction from this object to the target
            Vector2 direction = (target.position - transform.position).normalized;
            
            animator.SetBool("arJuda", true);
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            

            // Move this object towards the target at the specified speed
            transform.Translate(direction * config.speed * Time.deltaTime);
        }else animator.SetBool("arJuda", false);
        if(distance > 150){
            Gaudo = false;
            EnergyBar.decreaseEnabled = true;
        }
        }
        else{
                    if (distance <= priesoPastebejimas || Gaudo == true)
        {
            Gaudo = true;
            EnergyBar.decreaseEnabled = false;
            // Calculate the direction from this object to the target
            Vector2 direction = (target.position - transform.position).normalized;
            
            animator.SetBool("arJuda", true);
            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
            

            // Move this object towards the target at the specified speed
            transform.Translate(direction * priesoGreitis * Time.deltaTime);
        }else animator.SetBool("arJuda", false);
        if(distance > 150){
            Gaudo = false;
            EnergyBar.decreaseEnabled = true;
        }
        }

    }
}