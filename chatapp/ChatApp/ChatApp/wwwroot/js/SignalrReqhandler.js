var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

//connection = new signalR.HubConnectionBuilder()
//    .configureLogging(signalR.LogLevel.Debug)
//    .withUrl('https://localhost:*****/chat/chatroom', {
//        skipNegotiation: true,
//        transport: signalR.HttpTransportType.WebSockets
//    })
//    .build();

connection.on('ReceiveMessage', addMessageToChat);

connection.start().catch(err => console.error(err.toString()));

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message);
}