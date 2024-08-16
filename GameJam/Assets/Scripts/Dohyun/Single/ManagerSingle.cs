using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagerSingle<ManagerType> : ManagerBase where ManagerType : ManagerBase, IInit
{
    /// <summary> </summary>
    private static ManagerType _instance;


    public static ManagerType Instance
    {
        get
        {
            if (_instance == null) // �ڵ�ȭ - Manager�� �ƹ��� ȣ���ص� ���� ������ �ǵ��� �ڵ�ȭ �ص� ���̴�
            {
                _instance = FindObjectOfType<ManagerType>();
                if (_instance == null)
                {
                    GameObject managers = GameObject.Find("@DataManager");
                    if (managers == null)
                    {
                        GameObject root = GameObject.Find("@Root");
                        if (root == null)
                        {
                            root = new GameObject("@Root");
                            DontDestroyOnLoad(root);
                        }

                        managers = new GameObject("@DataManager");
                        managers.transform.SetParent(root.transform);
                    }
                    _instance = managers.AddComponent<ManagerType>();
                }


            }

            _instance.Init();

            return _instance;
        }
    }
}