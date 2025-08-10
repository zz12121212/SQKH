using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setMBE : MonoBehaviour
{

    public Image M;
    public Image E;
    public Image heart;

    public Animator anim;

    // Update is called once per frame
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();    
    }




    public void SetValue() {
       heart.fillAmount = recordPlayer.PlayerBlood / 100f;
        M.fillAmount = recordPlayer.PlayerMagic / 100f;
        E.fillAmount = recordPlayer.PlayerEnergy / 100f;
    }

    public void AddB(int B) {
        recordPlayer.PlayerBlood += B;
        if (recordPlayer.PlayerBlood <= 0) {
            anim.SetBool("Die",true);
        }
        if (recordPlayer.PlayerBlood >= 100) {
            recordPlayer.PlayerBlood = 100;
        }
    }
    public void AddM(int M) {
        recordPlayer.PlayerMagic += M;
        if (recordPlayer.PlayerMagic <= 0) {
            recordPlayer.PlayerMagic = 0;
        }
        if (recordPlayer.PlayerMagic >= 100) {
            recordPlayer.PlayerMagic = 100;
        }
    }
    public void AddE(int E)
    {
        recordPlayer.PlayerEnergy += E;
        if (recordPlayer.PlayerEnergy <= 0)
        {
            recordPlayer.PlayerEnergy = 0;
        }
        if (recordPlayer.PlayerEnergy >= 100)
        {
            recordPlayer.PlayerEnergy = 100;
        }
    }
}
