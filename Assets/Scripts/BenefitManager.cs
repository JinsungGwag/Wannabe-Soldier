using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenefitManager : MonoBehaviour
{
    public DataMananger dataManager;

    public GameObject saleContent;
    public GameObject welfareContent;

    public Text benefitText;
    public Text saleCategory;
    public Text welfareCategory;

    public void UpdateSaleList()
    {
        // 리스트 초기화
        Transform[] childList = saleContent.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        foreach(SaleEvent sale in dataManager.saleList)
        {
            if (!sale.location.Contains(saleCategory.text)) continue;
            
            Text rightBenefit = Instantiate(benefitText);
            rightBenefit.text = "지역: " + sale.location + "\n";
            rightBenefit.text += "시설: " + sale.facility + "\n";
            rightBenefit.text += "할인: " + sale.sale + "\n";
            rightBenefit.text += "번호: " + sale.number + "\n";
            rightBenefit.text += "주소: " + sale.site + "\n";
            rightBenefit.text += "설명: " + sale.explain + "\n";

            rightBenefit.transform.parent = saleContent.transform;
            rightBenefit.transform.localScale = benefitText.transform.localScale;
            rightBenefit.transform.localPosition = new Vector3(rightBenefit.transform.localPosition.x, rightBenefit.transform.localPosition.y, 0);
            rightBenefit.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void UpdateWelfareList()
    {
        // 리스트 초기화
        Transform[] childList = welfareContent.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        foreach (Welfare welfare in dataManager.welfareList)
        {
            if (!welfare.sort.Contains(welfareCategory.text)) continue;
            
            Text rightBenefit = Instantiate(benefitText);
            rightBenefit.text = "시설: " + welfare.facility + "\n";
            rightBenefit.text += "위치: " + welfare.address + "\n";
            rightBenefit.text += "번호: " + welfare.number + "\n";
            
            rightBenefit.transform.parent = welfareContent.transform;
            rightBenefit.transform.localScale = benefitText.transform.localScale;
            rightBenefit.transform.localPosition = new Vector3(rightBenefit.transform.localPosition.x, rightBenefit.transform.localPosition.y, 0);
            rightBenefit.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
