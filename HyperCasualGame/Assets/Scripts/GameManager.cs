using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private TMP_Text coin_Text,diamond_Text;
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private GameObject _winnerPanel;
    [SerializeField] private GameObject _gameOwerPanel;
    PlayerManager _playerMangrScript;
    void Start()
    {
        _playerMangrScript = _playerGameObject.GetComponent<PlayerManager>();
    }

    
    void Update()
    {
        if (_playerMangrScript.isFinish)
        {
            _winnerPanel.gameObject.SetActive(true);
            StartCoroutine(GameStop());
        }
        if(_playerMangrScript.health <= 0)
        {
            _gameOwerPanel.gameObject.SetActive(true);
            StartCoroutine(GameStop());
        }
    }

    IEnumerator GameStop()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
    }
}