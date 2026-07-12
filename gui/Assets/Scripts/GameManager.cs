using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public enum GameState
    {
        MenuPrincipal,
        Gameplay,
        Vitoria
    }


    public GameState estadoAtual;


    // ESCOLHA DAS BOLINHAS
    public string bolinhaJogador1;
    public string bolinhaJogador2;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private void Start()
    {
        estadoAtual = GameState.MenuPrincipal;
    }



    public void LoadScene(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }



    public void IniciarGameplay()
    {
        estadoAtual = GameState.Gameplay;

        SceneManager.LoadScene("SampleScene");
    }



    public void EscolherBolinhaJogador1(string nomeBolinha)
    {
        bolinhaJogador1 = nomeBolinha;

        Debug.Log("Jogador 1 escolheu: " + bolinhaJogador1);
    }



    public void EscolherBolinhaJogador2(string nomeBolinha)
    {
        bolinhaJogador2 = nomeBolinha;

        Debug.Log("Jogador 2 escolheu: " + bolinhaJogador2);
    }



    public void IrParaVitoria()
    {
        estadoAtual = GameState.Vitoria;

        SceneManager.LoadScene("Vitoria");
    }



    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");

        Application.Quit();
    }
}