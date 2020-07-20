using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenefitManager : MonoBehaviour
{
    public DataMananger dataManager;

    public GameObject saleContent;
    public GameObject welfareContent;
    public GameObject supplyContent;
    public GameObject pxContent;
    public GameObject tmoContent;

    public Text benefitText;
    public Text saleCategory;
    public Text welfareCategory;
    public Text supplyCategory;

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

    public void UpdateSupplyList()
    {
        // 리스트 초기화
        Transform[] childList = supplyContent.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        Text rightBenefit = Instantiate(benefitText);
        rightBenefit.text = "";

        foreach (Supply supply in dataManager.supplyList)
        {
            if (supplyCategory.text == "육군")
            {
                if (supply.army == 0) continue;
                rightBenefit.text += supply.title + ": " + supply.army + "개\n";
            }

            if (supplyCategory.text == "해군")
            {
                if (supply.navy == 0) continue;
                rightBenefit.text += supply.title + ": " + supply.navy + "개\n";
            }

            if (supplyCategory.text == "해병")
            {
                if (supply.marin == 0) continue;
                rightBenefit.text += supply.title + ": " + supply.marin + "개\n";
            }

            if (supplyCategory.text == "공군")
            {
                if (supply.air == 0) continue;
                rightBenefit.text += supply.title + ": " + supply.air + "개\n";
            }
            
            rightBenefit.transform.parent = supplyContent.transform;
            rightBenefit.transform.localScale = benefitText.transform.localScale;
            rightBenefit.transform.localPosition = new Vector3(rightBenefit.transform.localPosition.x, rightBenefit.transform.localPosition.y, 0);
            rightBenefit.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void UpdatePXList()
    {
        // 리스트 초기화
        Transform[] childList = pxContent.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        foreach (PX px in dataManager.pxList)
        {
            Text rightBenefit = Instantiate(benefitText);
            rightBenefit.text = "선정기준: " + px.standard + "\n";
            rightBenefit.text += "상품종류: " + px.item + "\n";
            
            rightBenefit.transform.parent = pxContent.transform;
            rightBenefit.transform.localScale = benefitText.transform.localScale;
            rightBenefit.transform.localPosition = new Vector3(rightBenefit.transform.localPosition.x, rightBenefit.transform.localPosition.y, 0);
            rightBenefit.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void UpdateTMOList()
    {
        // 리스트 초기화
        Transform[] childList = tmoContent.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        foreach (TMO tmo in dataManager.tmoList)
        {
            Text rightBenefit = Instantiate(benefitText);
            rightBenefit.text = "TMO명: " + tmo.title + "\n";
            rightBenefit.text += "전화번호: " + tmo.number + "\n";
            rightBenefit.text += "평일운용시: " + tmo.weekday + "\n";
            rightBenefit.text += "주말운용시: " + tmo.weekend + "\n";
            rightBenefit.text += "위치설명: " + tmo.location + "\n";
            
            rightBenefit.transform.parent = tmoContent.transform;
            rightBenefit.transform.localScale = benefitText.transform.localScale;
            rightBenefit.transform.localPosition = new Vector3(rightBenefit.transform.localPosition.x, rightBenefit.transform.localPosition.y, 0);
            rightBenefit.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
