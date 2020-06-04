using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MissionList
{
    public class Mission
    {
        public Mission(string category, string name, int price)
        {
            this.category = category;
            this.name = name;
            this.price = price;
        }

        public string category;
        public string name;
        public int price;
    }


    public static Mission[] missions = new Mission[] {
        new Mission( "여행", "독립", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10),
        new Mission( "여행", "호구", 10)
    };
}