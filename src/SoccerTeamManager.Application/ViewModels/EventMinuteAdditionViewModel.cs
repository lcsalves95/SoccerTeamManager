namespace SoccerTeamManager.Application.ViewModels
{
    public class EventMinuteAdditionViewModel
    {
        public int MinuteAddition { get; set; }

        public EventMinuteAdditionViewModel()
        {

        }

        public EventMinuteAdditionViewModel(int minuteAddition)
        {
            MinuteAddition = minuteAddition;
        }
    }
}
