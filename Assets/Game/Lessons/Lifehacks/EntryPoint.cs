using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private FooMonoBehaviour _fooMonoBehaviour;
    [SerializeField] private MyPlayer _myPlayer;

    public void Awake()
    {
        _fooMonoBehaviour.Init();
        _myPlayer.Init();
        
        //TODO: инит других систем. Выставления дефолтных параметров. Старт загрузки
    }
}