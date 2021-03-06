using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Langue : MonoBehaviour {

	public Dropdown dpLangue;
    public Text title;
    public Text btnC;
    public Text btnR;
    public Text txtMusic;
    public Text txtDroitier;
    public Text txtGaucher;
    public Text txtSensi;

    void Start(){
		
		if(PlayerPrefs.GetInt("lang") == 1){
			title.text = "Settings";
			btnC.text = "Back";
            btnR.text = "Default setting";
            txtMusic.text = "Musics";
            txtDroitier.text = "right-handed";
            txtGaucher.text = "left-handed";
            txtSensi.text = "Sensitivity";
            dpLangue.value = 1;

		}else{
            title.text = "Parametres";
            btnC.text = "Retour";
            btnR.text = "Parametres par defaut";
            txtMusic.text = "Musiques";
            txtDroitier.text = "droitier";
            txtGaucher.text = "gaucher";
            txtSensi.text = "sensibilite";
            dpLangue.value = 0;
		}
		PlayerPrefs.SetInt ("lang", dpLangue.value);
	}

	public void changeLangue () {
		
		PlayerPrefs.SetInt ("lang", dpLangue.value);
		if(dpLangue.value == 1){
            title.text = "Settings";
            btnC.text = "Back";
            btnR.text = "Default setting";
            txtMusic.text = "Musics";
            txtDroitier.text = "right-handed";
            txtGaucher.text = "left-handed";
            txtSensi.text = "Sensitivity";
        }
        else{
            title.text = "Parametres";
            btnC.text = "Retour";
            btnR.text = "Parametre par defaut";
            txtMusic.text = "Musiques";
            txtDroitier.text = "droitier";
            txtGaucher.text = "gaucher";
            txtSensi.text = "sensibilite";
        }
		Debug.Log (dpLangue.value);
	}
}
