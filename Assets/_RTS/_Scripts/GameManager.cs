using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public UIManager uiManager;
    public TroopFactory troopFactory;
    OreResource oreResource;
    public int initialOre = 0;


    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<GameManager> ();
                if (_instance != null)
                    DontDestroyOnLoad(_instance.gameObject);				
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned.");
            return;
        }

        oreResource = new OreResource(initialOre);
        uiManager.ShowResources(oreResource.amount);
        
    }

    public void GatherResource(int n)
    {
        oreResource.AddResources(n);
        uiManager.ShowResources(oreResource.amount);
    }

    bool UseResources(int n)
    {
        if (oreResource.UseResources(n))
        {
            uiManager.ShowResources(oreResource.amount);
            return true;
        }

        return false;
    }

    public void BuyTroop(int type){
        if (UseResources(troopFactory.troopCost))
        {
            switch(type){
                case 2: troopFactory.BuyTroopType2(); break;
                default: troopFactory.BuyTroopType1(); break;
            }
        }
        else
            uiManager.ShowMessage("NOT ENOUGH ORE TO BUY NEW TROOP", 5f);
    }

    
}