class Message {
    constructor(username, text, when) {
        this.UserName = username;
        this.content = text;
        this.date = when;
    }
}

const chat = document.getElementById('chat');
const username = document.getElementById('currentUser').value;

document.getElementById('submitButton').addEventListener('click', () => {
    sendMessage();
});

function clearInputField() {
    textInput.value = "";
}

function sendMessage() {
    let textInput = document.getElementById('messageText');

    if (textInput.value.trim() != "") {
        let when = new Date();
        let content = textInput.value;
        let message = new Message(username, content, when);
        sendMessageToHub(message);
    }
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.userName === username;

    if (isCurrentUserMessage) {
        let container = document.createElement('div');
        container.className = "outgoing_msg";

        let container2 = document.createElement('div');
        container2.className = "sent_msg";

        let sender = document.createElement('p');
        sender.innerHTML = message.content;

        let date = document.createElement('span');
        date.className = "time_date";
        date.innerHTML = dateFormat(message.date, "mm-dd-yyyy HH:MM:ss");

        chat.appendChild(container);
        container.appendChild(container2);
        container2.appendChild(sender);
        container2.appendChild(date);
        chat.appendChild(container);
        $("#messageText").val("");
    }
    else {

        let container = document.createElement('div');
        container.className = "incoming_msg";

        // Ajuster pour image ici
        let container2 = document.createElement('div');
        container2.className = "incoming_msg_img";
        container2.innerHTML = "<img src='https://ptetutorials.com/images/user-profile.png'/>";

        let container3 = document.createElement('div');
        container3.className = "received_msg";

        let container4 = document.createElement('div');
        container4.className = "received_withd_msg";

        let sender = document.createElement('p');
        sender.innerHTML = message.content;

        let date = document.createElement('span');
        date.className = "time_date";
        date.innerHTML = dateFormat(message.date, "mm-dd-yyyy HH:MM:ss");

        container.appendChild(container2);
        container.appendChild(container3);
        container3.appendChild(container4);
        container4.appendChild(sender);
        container4.appendChild(date);
        chat.appendChild(container);
    }

    var objDiv = document.getElementById("chat");
    objDiv.scrollTop = objDiv.scrollHeight;
}