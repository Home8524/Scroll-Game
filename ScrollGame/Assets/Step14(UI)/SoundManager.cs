using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    private static GameObject Container = null;
    static private SoundManager Instance;
    static public SoundManager GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Container = new GameObject("Tester");
                Container.AddComponent<AudioPlayer>();
                Instance = new SoundManager();
            }
            return Instance;
        }
    }

    private List<AudioClip> SoundList = new List<AudioClip>();
   // private AudioSource AudioPlayer = null;

    public void Initialize()
    {
        //��� ������Ʈ - object[]
        object[] Obj = Resources.LoadAll("Sound");

        for(int i = 0; i<Obj.Length; ++i)
        {
            SoundList.Add(Obj[i] as AudioClip);
        }
    }
    
    public AudioClip GetAudioClip(int _Index)
    {
        if (_Index >= SoundList.Count)
        {
            Debug.Log("��� ������ ���尡 �����ϴ�.   Index : "
                + _Index + "Max Index  : " + (SoundList.Count - 1) +
                "   0 <= _Index < Max Index");


            return null;
        }

        return SoundList[_Index];

    }

}
