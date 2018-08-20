﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CH11;
using static System.Console;

namespace CardClient
{
   public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;
        public Game()
        {
            currentCard = 0;
            playDeck = new Deck();
            playDeck.LastCardDrawn += Reshuffle;
            playDeck.Shuffle();
            discardedCards = new Cards();
        }
        private void Reshuffle(object source,EventArgs args)
        {
            WriteLine("Discarded cards reshuffled into deck");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException("A maximum of 7 players may play this game.");
            if (newPlayers.Length < 2)
                throw new ArgumentException("A minimum of 2 players may play this game.");
            players = newPlayers;
        }
        private void DealHands()
        {
            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }

        }
        public int PlayGame()
        {
            if (players == null)
                return -1;
            DealHands();
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);
            do
            {
                for (currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
                {
                    WriteLine($"{players[currentPlayer].Name}'s turn");
                    WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        WriteLine(card);
                    }
                    WriteLine($"Card in play: {playCard}");
                    bool inputOK = false;
                    do
                    {
                        WriteLine("Press T to take card in play or D to draw:");
                        string input = ReadLine();
                        if (input.ToLower() == "t")
                        {
                            WriteLine($"Draw:{playCard}");
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }
                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            Card newCard;
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                cardIsAvailable = !discardedCards.Contains(newCard);
                                if (cardIsAvailable)
                                {
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvailable);
                            WriteLine($"Drawn:{newCard}");
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }
                    } while (inputOK == false);
                    WriteLine("New hand:");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                    {
                        WriteLine($"{i + 1}" + $"{players[currentPlayer].PlayHand[i]}");
                    }
                    inputOK = false;
                    int choice = -1;
                    do
                    {
                        WriteLine("Choose card to discard:");
                        string input = ReadLine();
                        try
                        {
                            choice = Convert.ToInt32(input);
                            if ((choice > 0) && (choice <= 8))
                                inputOK = true;
                        }
                        catch
                        {

                        }
                    } while (inputOK == false);
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                    discardedCards.Add(playCard);
                    WriteLine($" Discarding:{ playCard}");
                    WriteLine();
                    GameWon = players[currentPlayer].HasWon();
                    if (GameWon == true)
                        break;
                }
            } while (GameWon == false);
            return currentPlayer;
        }
    }
}
