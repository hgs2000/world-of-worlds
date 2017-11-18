using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    //Variáveis
    private int _maxHP;
    private int _maxMP;
    private int _damageMultiplier;
    private float _xpToNextLevel;
    private float _xpToNextLevelMultiplier;
    private int _currentLevel;
    private float _playerSpeed;
    private float deltaTime = 0.0f;

    public int currentHP;
    public int currentMP;
    public int currentDamage;
    public int currentXP;

    public ClasseJogador classe;

    public GameObject xpCounter, levelCounter, hpCounter;

    //private Text xpText, levelText, hpText;

    // Use this for initialization
    void Start() {
        classe = ClasseJogador.PLEBEU;
        _xpToNextLevelMultiplier = 1.0f;
        _currentLevel = 1;
        _xpToNextLevel = 20f;
        currentHP = 50;
        levelCounter.GetComponent<Text>().text = "Nível: " + _currentLevel + "";
        xpCounter.GetComponent<Text>().text = "XP: " + currentXP + "";
        hpCounter.GetComponent<Text>().text = "HP: " + currentHP + "";
        deltaTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update() {
        if (currentXP >= _xpToNextLevel) {
            _currentLevel += 1;
            currentXP = 0;
            _xpToNextLevelMultiplier += 0.1f;
            String val = "Nível: " + _currentLevel+ "";
            levelCounter.GetComponent<Text>().text = val;
            val = "XP: " + currentXP + "+";
            xpCounter.GetComponent<Text>().text = val;

            _xpToNextLevel = _xpToNextLevel * _xpToNextLevelMultiplier;
            Debug.Log("XP: " + currentXP);
        }
        if (deltaTime >= 2.0f) {
            deltaTime = 0.0f;
            currentXP += 1;
        }
        deltaTime += Time.deltaTime;

        xpCounter.GetComponent<Text>().text = "XP: " + currentXP + "";
        hpCounter.GetComponent<Text>().text = "HP: " + currentHP + "";
        Debug.Log("Update");
    }

    public void setClasse(ClasseJogador classe) {
        this.classe = classe;
        switch (classe) {
            case ClasseJogador.ASSSASSINO:
                this._maxHP = 75;
                this._maxMP = 5;
                break;

            case ClasseJogador.TANQUE:
                this._maxHP = 150;
                this._maxMP = 0;
                break;
            case ClasseJogador.MAGO:
                this._maxHP = 100;
                this._maxMP = 20;
                break;
        }
    }

    public enum ClasseJogador {
        PLEBEU, TANQUE, MAGO, ASSSASSINO
    }

}
