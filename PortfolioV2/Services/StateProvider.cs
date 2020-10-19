namespace PortfolioV2.Services
{
    public record State
    {
        public bool NavOpen { get; init; }

    }

    public static class Mutate
    {
        public enum Action
        {
            TOGGLE_NAVBAR
        }
        public static State Reducer(State state, Action action)
        {
            return action switch
            {
                Action.TOGGLE_NAVBAR => state with { NavOpen = !state.NavOpen },
                _ => state
            };
        }
    }
}