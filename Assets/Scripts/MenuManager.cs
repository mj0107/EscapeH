using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; // 다른 class에서 호출 가능해진다.

    [SerializeField] Menu[] menus;


    private void Awake()
    {
        Instance = this;
    }

    
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName) // string에 해당하는 메뉴를 연다.
            {
                menus[i].Open();
            }
            else if (menus[i].open) // 현재 열려있는 메뉴를 닫는다.
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(Menu menu) // Menu에 해당하는 메뉴를 연다.
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
