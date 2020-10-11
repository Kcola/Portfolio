namespace PortfolioV2.Services
{
    public interface IStateProvider
    {
        bool NavOpen { get; set; }
    }

    public class StateProvider : IStateProvider
    {
        public bool NavOpen { get; set; }
    }
}