using System;
namespace Portfolio.Services
{
    public class State
    {
        public bool NavOpen { get; set; }
        public VimCommandLine CurrentCommand { get; set; } = new VimCommandLine("", "");
        private void NotifyStateChanged() => OnChange?.Invoke();

        public event Action? OnChange;

        public void Reducer(StateAction stateAction)
        {
            switch (stateAction.Type)
            {
                case ActionType.TOGGLE_NAVBAR:
                    NavOpen = (stateAction.Payload ?? throw new ArgumentException("Navigation state is required.", nameof(stateAction))).NavOpen;
                    break;
                case ActionType.ENTER_COMMAND:
                    var payload = stateAction.Payload ?? throw new ArgumentException("Command state is required.", nameof(stateAction));
                    NavOpen = payload.NavOpen;
                    CurrentCommand = payload.CurrentCommand;
                    break;
                case ActionType.CLEAR_COMMAND:
                    CurrentCommand = new VimCommandLine("","");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stateAction));
            }

            NotifyStateChanged();
        }

    }

    public record VimCommandLine
        {
            public string Command { get; init; } = "";
            public string Args { get; init; } = "";
            public VimCommandLine(string command, string args) => (Command, Args) = (command, args);
        }

        public static class NavItems
        {
            public const string Socials = "socials.ts";
            public const string Contacts = "contacts.ts";
            public const string Publications = "publications.ts";
            public const string Home = "home.ts";
            public const string Github = "github.ts";
            public const string Projects = "projects.ts";
        }

        public enum ActionType
        {
            TOGGLE_NAVBAR,
            ENTER_COMMAND,
            CLEAR_COMMAND
        }

        public class StateAction
        {
            public ActionType Type { get; set; }
            public State? Payload { get; set; }
        }
    }