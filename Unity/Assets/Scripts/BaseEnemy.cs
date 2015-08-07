using UnityEngine;
using System.Collections;
using Weapon;

public class BaseEnemy : MonoBehaviour {


    /// <summary>
    /// How much a enemy can take
    /// </summary>
    private int _healtPoints = 1;
    public int HealthPoints {
        get; set;
    }

    private int _strength = 1;
    public int Strength { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GoAway() {
        // animar e depois da animação usar
        Destroy(gameObject);
        //Destroy(gameObject, 3f); opcional, três segundos de delay para destruir o gameObject

        /*
         ver também esta possibilidade:
         * anim = GetComponent<Animation>();
	
    	anim.Play();
	
	    // Wait for the animation to finish.
	    yield WaitForSeconds(anim.clip.length);
         */
    }

    bool GotToDie()
    {
        return HealthPoints <= 0;
    }

    void Die() {
        GoAway();
    }

    void OnDisappear()
    {
        // TODO: i have to set a life drainer here, and this will be a event publisher when i get that working
        // eu estava lendo sobre delegate. Vai no chrome que a aba está aberta
    }

    public void GetHit(int force)
    {

    }

    void OnGetHit(BaseWeapon weapon)
    {
        HealthPoints -= weapon.Strength;
        if (GotToDie())
        {
            Die();
        }
    }
}
