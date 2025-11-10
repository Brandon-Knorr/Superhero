using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero
{
    internal class QuizQuestions
    {
        public string Question { get; set; }

        public string ImageSource { get; set; }

        public int TrueSpiderman { get; set; }

        public int TrueWolverine { get; set; }

        public int TrueHulk { get; set; }

        public int TrueSuperman { get; set; }

        public int FalseSpiderman { get; set; }

        public int FalseWolverine { get; set; }

        public int FalseHulk { get; set; }

        public int FalseSuperman { get; set; }

        public QuizQuestions(string question, string imageSource, int trueSpiderman, int trueWolverine, int trueHulk, int trueSuperman, int falseSpiderman, int falseWolverine, int falseHulk, int falseSuperman)
        {
            Question = question;
            ImageSource = imageSource;
            TrueSpiderman = trueSpiderman;
            TrueWolverine = trueWolverine;
            TrueHulk = trueHulk;
            TrueSuperman = trueSuperman;
            FalseSpiderman = falseSpiderman;
            FalseWolverine = falseWolverine;
            FalseHulk = falseHulk;
            FalseSuperman = falseSuperman;
        }
    }
}
