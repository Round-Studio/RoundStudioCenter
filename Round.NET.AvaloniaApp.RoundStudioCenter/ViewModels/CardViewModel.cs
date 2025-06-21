using ReactiveUI;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.ViewModels;

public class CardViewModel
{
    public class MainViewModel : ReactiveObject
    {
        private string _cardTitle;
        private string _cardDescription;

        public string CardTitle
        {
            get => _cardTitle;
            set => this.RaiseAndSetIfChanged(ref _cardTitle, value);
        }

        public string CardDescription
        {
            get => _cardDescription;
            set => this.RaiseAndSetIfChanged(ref _cardDescription, value);
        }

        public MainViewModel()
        {
            // 初始化卡片内容
            CardTitle = "Initial Title";
            CardDescription = "This is the initial description.";
        }
    }
}