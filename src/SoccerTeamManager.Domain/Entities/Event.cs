using SoccerTeamManager.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SoccerTeamManager.Domain.Entities
{
    public class Event : Entity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EventTypes EventType { get; private set; }
        public DateTime? StartTime { get; private set; }
        public int? Goal { get; private set; }
        public int? MinuteBreak { get; private set; }
        public int? MinuteAddition { get; private set; }
        public int? Replacement { get; private set; }
        public int? Warning { get; private set; }
        public DateTime? EndTime { get; private set; }

        /* Partida */
        public Guid GameId { get; private set; }
        public Game Game { get; private set; }


        public Event()
        {
            Game = new Game();
        }

        public Event(Game game, EventTypes eventType)
        {
            EventType = eventType;
            Game = game;
        }

        public void UpdateStartTime(DateTime startTime)
        {
            if (startTime == new DateTime())
                throw new ArgumentException("Parameter [startTime] must be valid.", nameof(startTime));

            StartTime = startTime;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateGoal(int goal)
        {
            if (goal < 0)
                throw new ArgumentException("Parameter [goal] must be valid.", nameof(goal));

            Goal = goal;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateMinuteBreak(int minuteBreak)
        {
            if (minuteBreak < 0)
                throw new ArgumentException("Parameter [minuteBreak] must be valid.", nameof(minuteBreak));

            MinuteBreak = minuteBreak;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateMinuteAddition(int minuteAddition)
        {
            if (minuteAddition < 0)
                throw new ArgumentException("Parameter [minuteAddition] must be valid.", nameof(minuteAddition));

            MinuteAddition = minuteAddition;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateReplacement(int replacement)
        {
            if (replacement < 0)
                throw new ArgumentException("Parameter [replacement] must be valid.", nameof(replacement));

            Replacement = replacement;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateWarning(int warning)
        {
            if (warning < 0)
                throw new ArgumentException("Parameter [warning] must be valid.", nameof(warning));

            Warning = warning;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateEndTime(DateTime endTime)
        {
            if (endTime == new DateTime())
                throw new ArgumentException("Parameter [endTime] must be valid.", nameof(endTime));

            EndTime = endTime;
            UpdatedAt = DateTime.Now;
        }

    }
}
