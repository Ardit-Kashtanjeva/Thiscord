using LNMServer;

var server = new ServerTcp();
await server.ListenForClientsAsync();

