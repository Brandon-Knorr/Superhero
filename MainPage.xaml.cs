namespace Superhero
{
    public partial class MainPage : ContentPage
    {
        List<QuizQuestions> questionList;
        List<Superheros> superheroList;
        int questionCount;

        public MainPage()
        {
            InitializeComponent();
            questionList = new List<QuizQuestions>()
            {
                   // trueSpiderman, trueWolverine, trueHulk, trueSuperman, falseSpiderman, falseWolverine, falseHulk, falseSuperman
                new QuizQuestions("You feel like you have extreme senses that detect when you are in danger.", "", 10, 8, 2, 1, 0, 0, 6, 6),
                new QuizQuestions("You know you only have 1 weakness.", "", 1, 2, 2, 10, 0, 1, 1, 8),
                new QuizQuestions("You recover from a tough day or injuries very quick.", "", 0, 10, 8, 6, 2, 0, 0, 1),
                new QuizQuestions("You get extremely strong when angry.", "", 1, 3, 10, 4, 2, 1, 0, 1),
                new QuizQuestions("You are very honest.", "", 2, 3, 1, 10, 1, 1, 1, 0),
                new QuizQuestions("You loved to swing and climb on the jungle gym when you were young.", "", 10, 1, 1, 1, 0, 2, 2, 2),
                new QuizQuestions("You have nightmares all the time.", "", 2, 8, 3, 1, 1, 0, 1, 2),
                new QuizQuestions("You love science!", "", 8, 0, 6,  4, 0, 2, 0, 1),
            };
            superheroList = new List<Superheros>()
            {
                new Superheros("Spiderman", "", 0.0),
                new Superheros("Wolverine", "", 0.0),
                new Superheros("Hulk", "", 0.0),
                new Superheros("Superman", "", 0.0),
            };
            questionCount = 0;


            QuestionLabel.Text = questionList[questionCount++].Question;
        }

        private void ButtonClicked(object? sender, EventArgs e)
        {

            if (sender is not Button btn)
                return;

            int currentIndex = Math.Max(0, questionCount - 1);


            if (currentIndex >= questionList.Count)
            {
                currentIndex = questionList.Count - 1;
            }

            var question = questionList[currentIndex];

            if (btn.Text == "True")
            {
                superheroList[0].SuperheroScore += question.TrueSpiderman;
                superheroList[1].SuperheroScore += question.TrueWolverine;
                superheroList[2].SuperheroScore += question.TrueHulk;
                superheroList[3].SuperheroScore += question.TrueSuperman;
            }
            else
            {
                superheroList[0].SuperheroScore += question.FalseSpiderman;
                superheroList[1].SuperheroScore += question.FalseWolverine;
                superheroList[2].SuperheroScore += question.FalseHulk;
                superheroList[3].SuperheroScore += question.FalseSuperman;
            }

            if (questionCount < questionList.Count)
            {
                QuestionLabel.Text = questionList[questionCount++].Question;
            }
            else
            {
                TrueButton.IsVisible = FalseButton.IsVisible = false;
                var maxScore = superheroList.Max(s => s.SuperheroScore);

                var winner = superheroList.Where(s => Math.Abs(s.SuperheroScore - maxScore) < 1e-9 ).Select(s => s.Name).ToList();

                if (winner.Count == 1)
                {
                    ResultLabel.Text = $"You are most like {winner[0]}!";
                }
                else
                {
                    ResultLabel.Text = $"It's a tie: {string.Join(", ", winner)}";
                }
   
            }
        }

    
    }

}
