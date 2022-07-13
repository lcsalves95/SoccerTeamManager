namespace SoccerTeamManager.Application.ViewModels
{
    public class EventMinuteBreakViewModel
    {
        public int MinuteBreak { get; set; }

        public EventMinuteBreakViewModel()
        {

        }

        public EventMinuteBreakViewModel(int minuteBreak)
        {
            MinuteBreak = minuteBreak;
        }
    }
}
