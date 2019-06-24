using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{

    #region VARIAVEIS

    //DECLARACAO DE VARIAVEIS PUBLICAS
    [Header("CONFIGURACOES DO JOGADOR")]
    public float forcaMovimento = 5;
    public float velocidademaxima = 5;
    public float ganhoVelocidade = 8;
    public float focaPulo = 30;

    [Header("CONFIGURACOES DOS OBJETOS")]
    public Transform baseChao;
    public LayerMask layerChao;
    public GameObject maisVelocidadeUI;
    public GameObject tempoVelocidadeUI;

    [Header("CONFIGURACAO DE AUDIOS")]
    public AudioClip audioPulo;
    public AudioClip audioVelocidade;

    //DECLARACAO DE VARIAVEIS PRIVADAS
    private bool pulando = false;
    private bool estaNoChao = false;
    private bool estaVivo = true;
    private bool coletando = false;
    private float forcaHorizontal = 1;
    private Rigidbody2D jogador;
    private Animator animacao;
    private AudioSource audioSource;
    private Scrollbar sBar;

    #endregion

    // USADO NA INICIALIZACAO DO JOGO
    void Start()
    {
        jogador = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        sBar = tempoVelocidadeUI.GetComponent<Scrollbar>();
    }

    // USADO DURANTE O JOGO
    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(baseChao.position, 0.2f, layerChao);
        animacao.SetBool("OnGround", estaNoChao);

        if (estaNoChao)
        {
            animacao.SetBool("Jump", false);
        }
    }

    // USADO DURANTE O JOGO PARA EDITAR A FISICA DO JOGO
    private void FixedUpdate()
    {
        //verificando se o jogador esta vivo
        if (estaVivo)
        {

            animacao.SetFloat("Speed", jogador.velocity.x);

            //se estiver vivo movimenta o jogador
            jogador.AddForce(Vector2.right * forcaHorizontal * forcaMovimento);

            if (jogador.velocity.x > velocidademaxima)
            {
                // limitar a velocidade para velocidade maxima
                jogador.velocity = new Vector2(Mathf.Sign(jogador.velocity.x) * velocidademaxima, jogador.velocity.y);
            }

            if (pulando)
            {
                pulando = false;
                animacao.SetBool("Jump", true);
                jogador.AddForce(new Vector2(jogador.velocity.x, focaPulo));
            }

            if (coletando)
            {
                //Debug.Log("entrei em espera");
                StartCoroutine(espera());
            }
            else
            {
                animacao.SetBool("Coletando", false);
            }
        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.1f);
        coletando = false;
    }

    public void Pulo()
    {
        if (estaNoChao)
        {
            audioSource.clip = audioPulo;
            audioSource.Play();
            pulando = true;
        }
    }

    public void superVelocidade()
    {
        audioSource.clip = audioVelocidade;
        audioSource.Play();
        velocidademaxima = ganhoVelocidade;
        StartCoroutine(tempoSuperVelocidade(10f));
    }

    IEnumerator tempoSuperVelocidade(float segundos)
    {
        float time = segundos;

        while (segundos > 0)
        {
            segundos -= Time.deltaTime;
            sBar.size = segundos / time;
            yield return null;
        }
        menosVelocidade();
    }

    public void menosVelocidade()
    {
        maisVelocidadeUI.SetActive(false);
        tempoVelocidadeUI.SetActive(false);
        velocidademaxima = forcaMovimento;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlusVelocidade"))
        {
            collision.gameObject.SetActive(false);
            maisVelocidadeUI.SetActive(true);
            tempoVelocidadeUI.SetActive(true);
            superVelocidade();
        }

        if (collision.CompareTag("Lixo"))
        {
            coletando = true;
            animacao.SetBool("Coletando", true);
        }
    }
}
