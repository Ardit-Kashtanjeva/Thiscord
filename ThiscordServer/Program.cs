using ThiscordServer;

var server = new ServerTcp();
await server.ListenForClientsAsync();

