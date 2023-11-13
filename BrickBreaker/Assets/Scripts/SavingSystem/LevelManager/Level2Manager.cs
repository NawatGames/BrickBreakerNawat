using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject level2; // Referência ao objeto "Level 1"

    private bool level2Complete = false;

    public void LoadData(GameData data){
        this.level2Complete = data.Level2Complete;
    }

    public void SaveData(ref GameData data){
        data.Level2Complete = this.level2Complete;
    } 

    void Start()
    {
        // Inicialize a referência ao objeto "Level 1"
        level2 = GameObject.Find("Level 2");

        // Verifique se o objeto "Level 1" foi encontrado
        if (level2 != null)
        {
            // Verifique se o nível foi completado
            level2Complete = CheckLevel2Complete();
        }
        else
        {
            Debug.LogError("Objeto 'Level 2' não encontrado. Verifique se o nome está correto.");
        }
    }

    void Update()
    {
        // Se o nível foi completado, faça o que for necessário aqui
        if (level2Complete)
        {
            Debug.Log("Nível completo!");
        }
    }

    bool CheckLevel2Complete()
    {
        // Itera sobre cada fileira
        for (int i = 51; i <= 125; i++)
        {
            // Construa o nome da fileira
            string rowName = "Row " + i.ToString();

            // Obtém a fileira pelo nome
            Transform rowTransform = level2.transform.Find(rowName);

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
