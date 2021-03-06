﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Rand = UnityEngine.Random;
using Assets.Scripts.Managers;
using Assets.Scripts.InfoClasses;



public class AI
{
    public static void StartOpponentAI(Hand currentHand, Board myBoard)
    { 
        CoroutineManager.Instance.SetupTimer(3f, null, () => { TurnManager.Instance.EndTurn(); });

        int count = Rand.Range(0, 4);
        Debug.Log(count);
        for (int i = 0; i < count; i++)
        {
            CoroutineManager.Instance.SetupTimer(Rand.Range(0.1f, 2.9f), null,
            () =>
            {
                Card c = currentHand.GetRandomCardInHand();
                myBoard.PlayCard(c);

            }

            );
        }

    }
}
