using System;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Modules.Entities;

namespace CounterStrikeSharp.API.Core
{
    public class ListenersDefs
    {
        /// <summary>
        /// Called when an entity is spawned.
        /// </summary>
        /// <param name="entity">The spawned entity.</param>
        public static readonly ListenerDefinition<Action<CEntityInstance>> OnEntitySpawned = new("OnEntitySpawned",
            (context, method) => { method.Invoke(context.GetArgument<CEntityInstance>(0)); });

        /// <summary>
        /// Called when an entity is created.
        /// </summary>
        /// <param name="entity">The created entity.</param>
        public static readonly ListenerDefinition<Action<CEntityInstance>> OnEntityCreated = new("OnEntityCreated",
            (context, method) => { method.Invoke(context.GetArgument<CEntityInstance>(0)); });

        /// <summary>
        /// Called when an entity is deleted.
        /// </summary>
        /// <param name="entity">The deleted entity.</param>
        public static readonly ListenerDefinition<Action<CEntityInstance>> OnEntityDeleted = new("OnEntityDeleted",
            (context, method) => { method.Invoke(context.GetArgument<CEntityInstance>(0)); });

        /// <summary>
        /// Called when an entity's parent is changed.
        /// </summary>
        /// <param name="entity">The entity whose parent was changed.</param>
        /// <param name="newParent">The new parent entity.</param>
        public static readonly ListenerDefinition<Action<CEntityInstance, CEntityInstance>> OnEntityParentChanged = new(
            "OnEntityParentChanged",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<CEntityInstance>(0),
                    context.GetArgument<CEntityInstance>(1));
            });

        /// <summary>
        /// Called on every server tick (64 per second).
        /// This handler should avoid containing expensive operations.
        /// </summary>
        public static readonly ListenerDefinition<Action> OnTick = new("OnTick",
            (context, method) => { method.Invoke(); });

        /// <summary>
        /// Called when a new map is loaded.
        /// </summary>
        /// <param name="mapName">The name of the map that was started.</param>
        public static readonly ListenerDefinition<Action<string>> OnMapStart = new("OnMapStart",
            (context, method) => { method.Invoke(context.GetArgument<string>(0)); });

        /// <summary>
        /// Called when the current map is about to end.
        /// </summary>
        public static readonly ListenerDefinition<Action> OnMapEnd = new("OnMapEnd",
            (context, method) => { method.Invoke(); });

        /// <summary>
        /// Called when a client connects to the server.
        /// </summary>
        /// <param name="playerSlot">The player slot of the connected client.</param>
        /// <param name="name">The name of the connected client.</param>
        /// <param name="ipAddress">The IP address of the connected client.</param>
        public static readonly ListenerDefinition<Action<int, string, string>> OnClientConnect = new(
            "OnClientConnect",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0),
                    context.GetArgument<string>(1),
                    context.GetArgument<string>(2));
            });

        /// <summary>
        /// Called when a client connects to the server.
        /// </summary>
        /// <param name="playerSlot">The player slot of the connected client.</param>
        public static readonly ListenerDefinition<Action<int>> OnClientConnected = new(
            "OnClientConnected",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0));
            });

        /// <summary>
        /// Called when a client is entering the game.
        /// </summary>
        /// <param name="playerSlot">The player slot of the client.</param>
        public static readonly ListenerDefinition<Action<int>> OnClientPutInServer = new(
            "OnClientPutInServer",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0));
            });

        /// <summary>
        /// Called when a client disconnects from the server.
        /// </summary>
        /// <param name="playerSlot">The player slot of the disconnected client.</param>
        public static readonly ListenerDefinition<Action<int>> OnClientDisconnect = new(
            "OnClientDisconnect",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0));
            });

        /// <summary>
        /// Called after a client has disconnected from the server.
        /// </summary>
        /// <param name="playerSlot">The player slot of the disconnected client.</param>
        public static readonly ListenerDefinition<Action<int>> OnClientDisconnectPost = new(
            "OnClientDisconnectPost",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0));
            });

        /// <summary>
        /// Called when a client transmits voice data
        /// </summary>
        /// <param name="playerSlot">The player slot of the client.</param>
        public static readonly ListenerDefinition<Action<int>> OnClientVoice = new(
            "OnClientVoice",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0));
            });

        /// <summary>
        /// Called when a client has been authorized by Steam.
        /// </summary>
        /// <param name="playerSlot">The player slot of the authorized client.</param>
        /// <param name="steamId">The Steam ID of the authorized client.</param>
        public static readonly ListenerDefinition<Action<int, SteamID>> OnClientAuthorized = new(
            "OnClientAuthorized",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<int>(0),
                    new SteamID(context.GetArgument<ulong>(1)));
            });

        /// <summary>
        /// Called when the server is updating the hibernation state.
        /// </summary>
        /// <param name="isHibernating"><see langword="true"/> if the server is hibernating, <see langword="false"/> otherwise</param>
        public static readonly ListenerDefinition<Action<bool>> OnServerHibernationUpdate = new(
            "OnServerHibernationUpdate",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<bool>(0));
            });

        /// <summary>
        /// Called when the Steam API is activated.
        /// </summary>
        public static readonly ListenerDefinition<Action> OnGameServerSteamAPIActivated = new(
            "OnGameServerSteamAPIActivated",
            (context, method) => { method.Invoke(); });

        /// <summary>
        /// Called when the Steam API is deactivated.
        /// </summary>
        public static readonly ListenerDefinition<Action> OnGameServerSteamAPIDeactivated = new(
            "OnGameServerSteamAPIDeactivated",
            (context, method) => { method.Invoke(); });

        /// <summary>
        /// Called when the server has changed hostname.
        /// </summary>
        /// <param name="hostname">New hostname of the server</param>
        public static readonly ListenerDefinition<Action<string>> OnHostNameChanged = new(
            "OnHostNameChanged",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<string>(0));
            });

        /// <summary>
        /// Called before the server enters fatal shutdown.
        /// </summary>
        public static readonly ListenerDefinition<Action> OnServerPreFatalShutdown = new(
            "OnServerPreFatalShutdown",
            (context, method) => { method.Invoke(); });

        /// <summary>
        /// Called when the server is in a loading stage.
        /// </summary>
        /// <param name="frameTime"></param>
        public static readonly ListenerDefinition<Action<float>> OnUpdateWhenNotInGame = new(
            "OnUpdateWhenNotInGame",
            (context, method) => { method.Invoke(context.GetArgument<float>(0)); });

        /// <summary>
        /// Called before the world updates.
        /// This seems to be called even when the server is hibernating.
        /// </summary>
        /// <param name="simulating"><see langword="true"/> if simulating, <see langword="false"/> otherwise</param>
        public static readonly ListenerDefinition<Action<bool>> OnServerPreWorldUpdate = new(
            "OnServerPreWorldUpdate",
            (context, method) =>
            {
                method.Invoke(
                    context.GetArgument<bool>(0));
            });
    }

    public class ListenerDefinition<T> where T : Delegate
    {
        private readonly Action<ScriptContext, T> _call;
        public string Name { get; }

        public ListenerDefinition(string name, Action<ScriptContext, T> call)
        {
            _call = call;
            Name = name;
        }

        public void Call(ScriptContext context, T method)
        {
            _call(context, method);
        }
    }
}