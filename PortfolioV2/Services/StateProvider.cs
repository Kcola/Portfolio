using System;
using System.Text.Json;

#nullable enable
namespace PortfolioV2.Services
{
    public class State
    {
        public bool? NavOpen { get; set; } = false;
        public VimCommandLine? CurrentCommand { get; set; } = new VimCommandLine("", "");
        private void NotifyStateChanged() => OnChange?.Invoke();

        public event Action? OnChange;

        public void Reducer(StateAction stateAction)
        {
            switch (stateAction.Type)
            {
                case ActionType.TOGGLE_NAVBAR:
                    NavOpen = stateAction.Payload?.NavOpen;
                    break;
                case ActionType.ENTER_COMMAND:
                    NavOpen = stateAction.Payload?.NavOpen;
                    CurrentCommand = stateAction.Payload?.CurrentCommand;
                    break;
                case ActionType.CLEAR_COMMAND:
                    CurrentCommand = new VimCommandLine("","");
                    break;
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