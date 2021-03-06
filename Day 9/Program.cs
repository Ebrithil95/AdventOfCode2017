﻿using System;
using System.IO;

namespace Day_9
{
    class Program
    {
        private static int calcScore(string input) {
            int openedGroups = 0;
            int score = 0;
            int cancelled = 0;
            bool isGarbage = false;
            for (int i = 0; i < input.Length; i++) {
                var c = input[i];

                if (isGarbage) {
                    if(c == '!') {
                        i ++;
                    } else if (c == '>') {
                        isGarbage =  false;
                    } else {
                        cancelled++;
                    }
                } else {
                    if (c == '{') {
                        openedGroups++;
                        score += openedGroups;
                    } else if (c == '<') {
                        isGarbage = true;
                    } else if (c == '}') {
                        openedGroups--;
                    }
                }
            }

            Console.WriteLine(score);
            Console.WriteLine(cancelled);
            return score;
        }

        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    var line = sr.ReadLine();
                    calcScore(line);
                }
            }
            catch (Exception e) { }
        }
    }
}
