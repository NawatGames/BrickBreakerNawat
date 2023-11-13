using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    public GameObject level3; // Referência ao objeto "Level 1"

    private bool level3Complete = false;

    public void LoadData(GameData data){
        this.level3Complete = data.Level3Complete;
    }

    public void SaveData(ref GameData data){
        data.Level3Complete = this.level3Complete;
    } 

    void Start()
    {
        // Inicialize a referência ao objeto "Level 1"
        level3 = GameObject.Find("Level 3");

        // Verifique se o objeto "Level 1" foi encontrado
        if (level3 != null)
        {
            // Verifique se o nível foi completado
            level3Complete = CheckLevel3Complete();
        }
        else
        {
            Debug.LogError("Objeto 'Level 3' não encontrado. Verifique se o nome está correto.");
        }
    }

    void Update()
    {
        // Se o nível foi completado, faça o que for necessário aqui
        if (level3Complete)
        {
            Debug.Log("Nível completo!");
        }
    }

    bool CheckLevel3Complete()
    {
        // Itera sobre cada fileira
        for (int i = 1; i <= 100; i++)
        {
            // Construa o nome da fileira
            string rowName = "Lv3Row " + i.ToString();

            // Obtém a fileira pelo nome
            Transform rowTransform = level3.transform.Find(rowName);

            // Verifique se a fileira foi encontrada
            if (rowTransform != null)
            {
                // Obtém todos os tijolos da fileira
                GameObject[] bricks = rowTransform.GetComponentsInChildren<GameObject>();

                // Itera sobre cada tijolo na fileira
                foreach (GameObject brick in bricks)
                {
                    // Verifica se o tijolo é um dos tipos específicos
                    if (brick.CompareTag("Tile"))
                    {
                        // Se qualquer tijolo não foi destruído, o nível não está completo
                        if (brick != null)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Fileira não encontrada: " + rowName);
            }
        }

        // Se todos os tijolos foram destruídos, o nível está completo
        return true;
    }
}
