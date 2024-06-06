using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Video;

public class CanvasQuiz : MonoBehaviour
{
    Color32 indigo = new Color32(38, 36, 100, 255);
    
    Color32 rightGreen = new Color32(36, 100, 85, 255);
    Color32 wrongRed = new Color32(100, 36, 67, 255);
    Color32 neutralGray = new Color32(204, 204, 204, 255);


    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    private int currentVideoClipIndex = 0;
    public Button[] answerButtons;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI FinalText;
    public Button leftButton;
    public Button rightButton;
    public Button playAgainButton;
    private string[] questions = new string[6];
    private string[][] answers = new string[6][];
    public int[] answerPosition = {0, 1, 1, 0, 0, 0};
    private int currentQuestionIndex = 0;
    public int correctAnswers = 0;

    private void Start()
    {
        //hide final text
        FinalText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);


        questions[0] = "Qual o ano de nascimento de D. Pedro?";
        answers[0] = new string[] { "1798", "1807"};

        questions[1] = "O que levou a família real a fugir para o Brasil em 1807?";
        answers[1] = new string[] { "Revolução Francesa", "Invasões Napoleónicas"};

        questions[2] = "Em que ano D. Pedro I declarou a independência do Brasil?";
        answers[2] = new string[] { "1831", "1822"};

        questions[3] = "Após abdicar do trono brasileiro, que papel assumiu D.Pedro em Portugal?";
        answers[3] = new string[] { "Líder das Forças Liberais na Guerra Civil", "Primeiro Ministro"};

        questions[4] = "Porque criou D.Pedro o Museu de Pinturas e Estampas e outros objetos de Belas Artes em 1833?";
        answers[4] = new string[] { "Promover instrução pública e salvaguarda do património artístico", "Expor a sua produção artística"};

        questions[5] = "Onde se encontra o coração de D. Pedro IV, conforme o seu desejo?";
        answers[5] = new string[] { "Igreja da Lapa (Porto)", "Mosteiro dos Jerónimos (Lisboa)"};

        questionText.text = questions[0];
        leftButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[0][0];
        rightButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[0][1];
        
        leftButton.GetComponent<Image>().color = indigo;
        rightButton.GetComponent<Image>().color = indigo;
        leftButton.onClick.AddListener(() => OnAnswerClicked(0));
        rightButton.onClick.AddListener(() => OnAnswerClicked(1));
    }


        void OnAnswerClicked(int selectedButtonIndex)
        {
            Debug.Log("Button " + selectedButtonIndex + " clicked!");
            Debug.Log("Correct answer is " + answerPosition[currentQuestionIndex]);

            if (selectedButtonIndex == answerPosition[currentQuestionIndex])
            {
                Debug.Log("Correct!");
                StartCoroutine(colorAndWait(1, selectedButtonIndex));
                correctAnswers++;
            }
            else
            {
                Debug.Log("Incorrect!");
                StartCoroutine(colorAndWait(0, selectedButtonIndex));
            }
        }

        IEnumerator colorAndWait(int correct, int selectedButtonIndex)
        {
            if (correct == 1)
            {
            if (selectedButtonIndex == 0)
            {
                leftButton.GetComponent<Image>().color = rightGreen;
                rightButton.GetComponent<Image>().color = neutralGray;
            }
            else if (selectedButtonIndex == 1)
            {
                rightButton.GetComponent<Image>().color = rightGreen;
                leftButton.GetComponent<Image>().color = neutralGray;
            }
            }
            else
            {
            if (selectedButtonIndex == 0)
            {
                leftButton.GetComponent<Image>().color = wrongRed;
                rightButton.GetComponent<Image>().color = rightGreen;
            }
            else if (selectedButtonIndex == 1)
            {
                leftButton.GetComponent<Image>().color = rightGreen;
                rightButton.GetComponent<Image>().color = wrongRed;
            }
            }

            yield return new WaitForSeconds(1);

            leftButton.GetComponent<Image>().color = indigo;
            rightButton.GetComponent<Image>().color = indigo;

            UpdateQuestionAndAnswers();
        }

        void UpdateQuestionAndAnswers()
{
    currentQuestionIndex++;

    if (currentQuestionIndex < questions.Length)
    {
        questionText.text = questions[currentQuestionIndex];
        leftButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][0];
        rightButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][1];
        videoPlayer.clip = videoClips[currentVideoClipIndex];
        videoPlayer.Play();
        currentVideoClipIndex = (currentVideoClipIndex + 1) % videoClips.Length;
    }
    else
    {
        Debug.Log("Quiz finished");
        questionText.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        FinalText.text = "Fim do Quiz! Acertou " + correctAnswers + " de " + questions.Length + " perguntas!";
        FinalText.gameObject.SetActive(true);
        playAgainButton.GetComponent<Image>().color = indigo;
        playAgainButton.gameObject.SetActive(true);

        playAgainButton.onClick.AddListener(() => RestartQuiz());
    }
}

void RestartQuiz()
{
    currentQuestionIndex = 0;
    correctAnswers = 0;

    currentVideoClipIndex = 0;
    videoPlayer.clip = videoClips[currentVideoClipIndex];
    videoPlayer.Play();

    questionText.text = questions[currentQuestionIndex];
    leftButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][0];
    rightButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][1];

    questionText.gameObject.SetActive(true);
    leftButton.gameObject.SetActive(true);
    rightButton.gameObject.SetActive(true);

    FinalText.gameObject.SetActive(false);
    playAgainButton.gameObject.SetActive(false);
}

    }



    
