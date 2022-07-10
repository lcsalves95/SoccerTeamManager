namespace SoccerTeamManager.Domain.Entities
{
    public class Game : Entity
    {
        public DateTime? StartTime { get; private set; } = null;
        public int? Goal { get; private set; } = null;
        public int? MinuteBreak { get; private set; } = null;
        public int? MinuteAddition { get; private set; } = null;
        public int? Replacement { get; private set; } = null;
        public int? Warning { get; private set; } = null;
        public DateTime? EndTime { get; private set; } = null;

        /* Torneio */
        public Guid TournamentId { get; private set; }
        public Tournament Tournament { get; private set; }

        /* Time 1 */
        public Guid FirstTeamId { get; private set; }
        public Team FirstTeam { get; private set; }

        /* Time 2 */
        public Guid SecondTeamId { get; private set; }
        public Team SecondTeam { get; private set; }

        public Game()
        {
            Tournament = new Tournament();
            FirstTeam = new Team();
            SecondTeam = new Team();
        }

        public Game(
                Guid tournamentId, 
                Guid firstTeamId,
                Guid secondTeamId,
                DateTime? startTime)
        {
            TournamentId = tournamentId;
            FirstTeamId = firstTeamId;
            SecondTeamId = secondTeamId;
            StartTime = startTime;
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
