using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skillplayer : MonoBehaviour
{
    Animator ani2;
    public bool chet1;
    public addiing add;
    public bool swap = false;
    public bool dich;
   
    // Start is called before the first frame update
    
    void Start()
    {
        ani2 = GetComponent<Animator>();
        add = GameObject.FindWithTag("point1").GetComponent<addiing>();
        
    }
    void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "boom")
        {
            soundmanager.PlaySound("die");
            chet1 = true;

        }
        if(colli.gameObject.tag == "dich")
        {
            dich = true;
        }
    }
    // Update is called once per frame
    IEnumerator Wait1second()
    {
      if(swap == true)
        {
            yield return new WaitForSeconds(1);

            
        }
           
       
        
    }
    void Update()
    {
        if (chet1 == true)
        {
            
            ani2.SetBool("chet", true);

            ani2.Play("die");
            Destroy(GameObject.Find("player_01"),1f);
            SceneManager.LoadScene("die");
            swap = true;
        }
        if(dich == true)
        {
            SceneManager.LoadScene("boss1");
            swap = true;
        }
    }
}
