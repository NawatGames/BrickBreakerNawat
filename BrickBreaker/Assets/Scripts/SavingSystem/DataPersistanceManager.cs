using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header ("Salvamento")]
    //[SerializedField] !!!!!!!!!!!!!!
    private string fileName;

    private GameData gameData;

    public static DataPersistanceManager instance {get; private set;}
    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;

    private void Awake(){
        if(instance != null)
        {
            Debug.LogError("Mais de um Data Persistent Manager na cena.");
        }
        instance = this;
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();

    }

    //adicionar uma instancia ao script encarregado de carregar o jogo

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){

        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("Jogo não encontrado. Iniciando novo jogo.");
            NewGame();
        }
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
        // colocar data nos scripts
    }
    public void SaveGame(){
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        //passa a data pros scripts para atualizar
        dataHandler.Save(gameData);

    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
