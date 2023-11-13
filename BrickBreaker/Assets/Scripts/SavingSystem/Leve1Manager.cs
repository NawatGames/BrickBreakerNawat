using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject level1; // Referência ao objeto "Level 1"

    private bool level1Complete = false;

    void Start()
    {
        // Inicialize a referência ao objeto "Level 1"
        level1 = GameObject.Find("Level 1");

        // Verifique se o objeto "Level 1" foi encontrado
        if (level1 != null)
        {
            // Verifique se o nível foi completado
            level1Complete = CheckLevel1Complete();
        }
        else
        {
            Debug.LogError("Objeto 'Level 1' não encontrado. Verifique se o nome está correto.");
        }
    }

    void Update()
    {
        // Se o nível foi completado, faça o que for necessário aqui
        if (level1Complete)
        {
            Debug.Log("Nível completo!");
        }
    }

    bool CheckLevel1Complete()
    {
        // Itera sobre cada fileira
        for (int i = 1; i <= 50; i++)
        {
            // Construa o nome da fileira
            string rowName = "Row " + i.ToString();

            // Obtém a fileira pelo nome
            Transform rowTransform = level1.transform.Find(rowName);

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
