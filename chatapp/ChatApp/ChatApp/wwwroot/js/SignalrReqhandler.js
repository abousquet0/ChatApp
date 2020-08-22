var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();


connection.on('ReceiveMessage', addMessageToChat);

connection.start().catch(err => console.error(err.toString()));

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message);
}