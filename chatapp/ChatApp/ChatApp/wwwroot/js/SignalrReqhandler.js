var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('ReceiveMessage', addMessageToChat);

//connection.start().catch(err => console.error(err.toString()));

connection.start().then(() => {
    var roomGuid = getCookie("RoomGuid");
    connection.invoke("JoinGroup", roomGuid).catch(function (err) {
        return console.error(err.toString());
    });
});

function sendMessageToHub(message) {
    var roomGuid = getCookie("RoomGuid");
    connection.invoke('SendMessageToGroup', message, roomGuid);
}

