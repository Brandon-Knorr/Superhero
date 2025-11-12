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
                new QuizQuestions("You feel like you have extreme senses that detect when you are in danger.", "heros.jpg", 10, 8, 2, 1, 0, 0, 6, 6),
                new QuizQuestions("You know you only have 1 weakness.", "batman.jpg", 1, 2, 2, 10, 0, 1, 1, 8),
                new QuizQuestions("You recover from a tough day or injuries very quick.", "superman.jpg", 0, 10, 8, 6, 2, 0, 0, 1),
                new QuizQuestions("You get extremely strong when angry.", "wolverine.jpg", 1, 3, 10, 4, 2, 1, 0, 1),
                new QuizQuestions("You are very honest.", "spiderman.jpg", 2, 3, 1, 10, 1, 1, 1, 0),
                new QuizQuestions("You loved to swing and climb on the jungle gym when you were young.", "hulk.jpg", 10, 1, 1, 1, 0, 2, 2, 2),
                new QuizQuestions("You have nightmares all the time.", "batman.jpg", 2, 8, 3, 1, 1, 0, 1, 2),
                new QuizQuestions("You love science!", "heros.jpg", 8, 0, 6,  4, 0, 2, 0, 1),
            };
            superheroList = new List<Superheros>()
            {
                new Superheros("Spiderman", "spiderman.jpg", 0.0),
                new Superheros("Wolverine", "wolverine.jpg", 0.0),
                new Superheros("Hulk", "hulk.jpg", 0.0),
                new Superheros("Superman", "superman.jpg", 0.0),
            };
            questionCount = 0;


            ShowQuestion(questionCount++);
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= questionList.Count)
                return;

            var q = questionList[index];
            QuestionLabel.Text = q.Question;

            // ensure result image hidden while in quiz
            ResultImage.IsVisible = false;

            if (!string.IsNullOrWhiteSpace(q.ImageSource))
            {
                // For images placed in Resources/Images (Build Action = MauiImage), supplying filename works.
                QuestionImage.Source = ImageSource.FromFile(q.ImageSource);
                QuestionImage.IsVisible = true;
            }
            else
            {
                QuestionImage.IsVisible = false;
                QuestionImage.Source = null;
            }

            // clear any prior result text
            ResultLabel.Text = string.Empty;
        }

        private void ShowResult(Superheros winner)
        {
            // hide question UI
            QuestionImage.IsVisible = false;
            TrueButton.IsVisible = FalseButton.IsVisible = false;

            // show winning hero image
            if (!string.IsNullOrWhiteSpace(winner.ImageSourceName))
            {
                ResultImage.Source = ImageSource.FromFile(winner.ImageSourceName);
                ResultImage.IsVisible = true;
            }
            else
            {
                ResultImage.IsVisible = false;
            }

            ResultLabel.Text = $"You are most like {winner.Name}!";
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
                ShowQuestion(questionCount++);
            }
            else
            {
                TrueButton.IsVisible = FalseButton.IsVisible = false;
                var maxScore = superheroList.Max(s => s.SuperheroScore);

                var winner = superheroList.OrderByDescending(s => s.SuperheroScore).First();
                ShowResult(winner);
            }
        }

    
    }

}
