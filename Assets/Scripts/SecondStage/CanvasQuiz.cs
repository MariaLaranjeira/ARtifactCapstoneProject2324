using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;

public class CanvasQuiz : MonoBehaviour
{
    Color32 indigo = new Color32(38, 36, 100, 255);
    
    Color32 rightGreen = new Color32(36, 100, 85, 255);
    Color32 wrongRed = new Color32(100, 36, 67, 255);
    Color32 neutralGray = new Color32(204, 204, 204, 255);


    public GameObject heartPlane;
    public GameObject fadePlane;
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
    public bool finished = false;
    
    private void Start()
    {
        FinalText.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
        heartPlane.SetActive(true);

        if (LanguageManager.Instance.CurrentLanguage == LanguageManager.Language.English)
        {
            questions[0] = "What is D. Pedro's birth year?";
            answers[0] = new string[] { "1798", "1807" };

            questions[1] = "What made the royal family flee to Brazil in 1807?";
            answers[1] = new string[] { "French Revolution", "Napoleonic Invasions" };

            questions[2] = "In what year did D. Pedro declare the independence of Brazil?";
            answers[2] = new string[] { "1831", "1822" };

            questions[3] = "After abdicating the Brazilian throne, what role did D.Pedro assume in Portugal?";
            answers[3] = new string [] {"Leader of the Liberal Forces in the Civil War", "Prime Minister"};

            questions[4] = "Why did D.Pedro create the Museum of Paintings and Prints and other Fine Arts objects in 1833?";
            answers[4] = new string[] { "Promote instruction and safeguard artistic heritage", "Exhibit his artistic production" };

            questions[5] = "Where is D. Pedro IV's heart, according to his wishes?";
            answers[5] = new string[] { "Igreja da Lapa (Oporto)", "Mosteiro dos Jerónimos (Lisbon)" };
        }
        else
        {
            questions[0] = "Qual o ano de nascimento de D. Pedro?";
            answers[0] = new string[] { "1798", "1807" };

            questions[1] = "O que levou a família real a fugir para o Brasil em 1807?";
            answers[1] = new string[] { "Revolução Francesa", "Invasões Napoleónicas"};

            questions[2] = "Em que ano D. Pedro declarou a independência do Brasil?";
            answers[2] = new string[] { "1831", "1822"};

            questions[3] = "Após abdicar do trono no brasil, que papel assumiu D.Pedro em Portugal?";
            answers[3] = new string[] { "Líder das Forças Liberais na Guerra Civil", "Primeiro Ministro"};

            questions[4] = "Porque criou D.Pedro o Museu de Pinturas e Estampas e outros objetos de Belas Artes em 1833?";
            answers[4] = new string[] { "Promover instrução e salvaguardar património artístico", "Expor a sua produção artística"};

            questions[5] = "Onde se encontra o coração de D. Pedro IV, conforme o seu desejo?";
            answers[5] = new string[] { "Igreja da Lapa (Porto)", "Mosteiro dos Jerónimos (Lisboa)"};
        }

        questionText.text = questions[0];
        leftButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[0][0];
        rightButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[0][1];

        currentVideoClipIndex = 0;
        videoPlayer.clip = videoClips[currentVideoClipIndex];
        videoPlayer.Play();
        
        leftButton.GetComponent<Image>().color = indigo;
        rightButton.GetComponent<Image>().color = indigo;
        leftButton.onClick.AddListener(() => OnAnswerClicked(0));
        rightButton.onClick.AddListener(() => OnAnswerClicked(1));

        Material fadeMaterial = fadePlane.GetComponent<Renderer>().material;
        Color color = fadeMaterial.color;
        color.a = 0;
        fadeMaterial.color = color;

        Material heartMaterial = heartPlane.GetComponent<Renderer>().material;
        color = heartMaterial.color;
        color.a = 0;
        heartMaterial.color = color;
    
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



            if (currentQuestionIndex != 5) StartCoroutine(FadeToNextVideo());
            yield return new WaitForSeconds(1);

            leftButton.GetComponent<Image>().color = indigo;
            rightButton.GetComponent<Image>().color = indigo;

            UpdateQuestionAndAnswers();
        }


    IEnumerator FadeToNextVideo()
{
    Material fadeMaterial = fadePlane.GetComponent<Renderer>().material;
    Material heartMaterial = heartPlane.GetComponent<Renderer>().material;
    float fadeDuration = 1.0f;

    currentVideoClipIndex = (currentVideoClipIndex + 1) % videoClips.Length;

    for (float t = 0; t < fadeDuration; t += Time.deltaTime)
    {
        Color color = fadeMaterial.color;
        color.a = Mathf.Lerp(0, 1, t / fadeDuration);
        fadeMaterial.color = color;
        yield return null;
    }

    // Change the video after incrementing the index
    videoPlayer.clip = videoClips[currentVideoClipIndex];
    videoPlayer.Play();

    // Fade back to transparent
    for (float t = 0; t < fadeDuration; t += Time.deltaTime)
    {   
        if (currentQuestionIndex == 5){
        Color heartColor = heartMaterial.color;
        heartColor.a = Mathf.Lerp(0, 1, t / fadeDuration);
        heartMaterial.color = heartColor;}

        Color color = fadeMaterial.color;
        color.a = Mathf.Lerp(1, 0, t / fadeDuration);
        fadeMaterial.color = color;
        yield return null;
    }
}

void UpdateQuestionAndAnswers()
{
    currentQuestionIndex++;

    if (currentQuestionIndex < questions.Length)
    { 
        questionText.text = questions[currentQuestionIndex];
        leftButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][0];
        rightButton.GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][1];
    }
    else
    {
        Debug.Log("Quiz finished");
        if (!finished)
        {
            finished = true;
            NavigationManager.NextLevel();
        }

        questionText.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        if (LanguageManager.Instance.CurrentLanguage == LanguageManager.Language.English){
            FinalText.text = "End of Quiz! You got " + correctAnswers + " out of " + questions.Length + " questions right!";
        }
        else{
            FinalText.text = "Fim do Quiz! Acertou " + correctAnswers + " de " + questions.Length + " perguntas!";
        }
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

    Material heartMaterial = heartPlane.GetComponent<Renderer>().material;
    Color color = heartMaterial.color;
    color.a = 0;
    heartMaterial.color = color;

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

    
