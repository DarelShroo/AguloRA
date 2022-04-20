using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxsState : MonoBehaviour
{
    public static CheckboxsState instance;
    
    private static bool  lugares;

    private static bool personajes;

    private static bool arquitectura;

    private static bool tradiciones;

    private static  bool historiaAborigen;

    private static string nameInfo;

    public static string NameInfo
    {
        get => nameInfo;
        set => nameInfo = value;
    }

    private  GameObject iniciarVisita;

    private bool iniciado = false;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public bool Lugares
    {
        get => lugares;
        set => lugares = value;
    }

    public bool Personajes
    {
        get => personajes;
        set => personajes = value;
    }

    public bool Arquitectura
    {
        get => arquitectura;
        set => arquitectura = value;
    }

    public bool Tradiciones
    {
        get => tradiciones;
        set => tradiciones = value;
    }

    public bool HistoriaAborigen
    {
        get => historiaAborigen;
        set => historiaAborigen = value;
    }

    public GameObject IniciarVisita
    {
        get => iniciarVisita;
        set => iniciarVisita = value;
    }

    public static CheckboxsState Instance
    {
        get => instance;
        set => instance = value;
    }

    public bool Iniciado
    {
        get => iniciado;
        set => iniciado = value;
    }
}
