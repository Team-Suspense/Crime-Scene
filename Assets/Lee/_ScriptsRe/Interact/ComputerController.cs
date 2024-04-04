using Cinemachine;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerController : MonoBehaviour, IAnswerable, IZoomable
{
    // ��ǻ�Ϳ� �ܵǴ� ī�޶�
    [SerializeField] CinemachineVirtualCamera computerCamera;
    // ��ǻ�Ϳ� ���� ui
    [SerializeField] Canvas canvas;
    // ����
    int score = 0;
    int totalQuestions = 0;


    // �����
    [Header("Answer Sheet")]
    [SerializeField] List<string> subjecttiveAnswers;
    [SerializeField] List<string> multipleChoiceAnswer;

    // �÷��̾� �����
    [Header("Player Answer Sheet")]
    [SerializeField] List<TMP_InputField> PlayerSubAnswers = new List<TMP_InputField>();
    [SerializeField] List<TextMeshProUGUI> PlayerMultiAnswer = new List<TextMeshProUGUI>();

    public void SubmitButton()
    {
        totalQuestions += subjecttiveAnswers.Count;
        totalQuestions += multipleChoiceAnswer.Count;
        // �ְ��� �� üũ
        for ( int i = 0; i < PlayerSubAnswers.Count; i++ )
        {
            string answer = PlayerSubAnswers [i].text;
            answer = answer.Replace(" ", string.Empty);
            if ( answer == subjecttiveAnswers [i] )
            {
                score++;
            }
        }
        // ������ �� üũ
        for ( int i = 0; i < PlayerMultiAnswer.Count; i++ )
        {
            if ( PlayerMultiAnswer [i].text == multipleChoiceAnswer [i] )
            {
                score++;
            }
        }
        // ���� ������ ���� ��ȭ���ָ�ɵ�
        Debug.Log($"������ {score}");

    }

    public void UnzoomObject( Transform ZoomTrans )
    {
        computerCamera.m_Priority = 0;
        canvas.enabled = false;
    }

    public void ZoomObject( Transform ZoomTrans )
    {
        computerCamera.m_Priority = 20;
        canvas.enabled = true;
    }


}