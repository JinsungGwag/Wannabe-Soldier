using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDate : MonoBehaviour
{
    public DataMananger dataManager;
    public Animator cameraAnimator;
    public Animator playerAnimator;
    public Transform player;
    public GameObject dateProgress;
    public Text dateText;
    public Image dateBar;

    private bool show = false;

    /// <summary>
    /// 두 날짜 사이의 일수를 구함
    /// </summary>
    /// <param name="dateTime1">기본 날짜</param>
    /// <param name="dateTime2">빼는 날짜</param>
    /// <returns>날짜 차이</returns>
    public int GetTerm(DateTime dateTime1, DateTime dateTime2)
    {
        TimeSpan termTime = dateTime1 - dateTime2;
        return termTime.Days;
    }

    public void StartShow()
    {
        if (show) return;
        show = true;

        StartCoroutine(ShowCurrent());
    }

    public void HideShow()
    {
        if (!show) return;
        show = false;

        StartCoroutine(HideCurrent());
    }

    private IEnumerator ShowCurrent()
    {
        cameraAnimator.SetTrigger("DoMove");
        playerAnimator.SetTrigger("DoMove");
        yield return new WaitForSeconds(1f);

        dateProgress.SetActive(true);

        Information userInfo = dataManager.userInfo;
        DateTime startDate = new DateTime(userInfo.inYear, userInfo.inMonth, userInfo.inDay);
        DateTime endDate = new DateTime(userInfo.outYear, userInfo.outMonth, userInfo.outDay);
        int allTime = GetTerm(endDate, startDate);
        int remainTime = GetTerm(endDate, DateTime.Now);

        dateText.text = ((float)(allTime - remainTime) / allTime) * 100 + "% (D-" + remainTime + ")";
        dateBar.fillAmount = ((float)(allTime - remainTime) / allTime);
    } 

    private IEnumerator HideCurrent()
    {
        cameraAnimator.SetTrigger("UndoMove");
        playerAnimator.SetTrigger("UndoMove");
        dateProgress.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        player.rotation = Quaternion.Euler(0, 180, 0);
    }
}
