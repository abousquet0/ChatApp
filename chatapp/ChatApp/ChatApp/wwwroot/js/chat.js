class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.content = text;
        this.date = when;
    }
}

const chat = document.getElementById('chat');


document.getElementById('submitButton').addEventListener('click', () => {
    sendMessage();
});

function clearInputField() {
    textInput.value = "";
}

function sendMessage() {
    var username = "Antoine";
    let when = new Date();
    let textInput = document.getElementById('messageText').value;
    let message = new Message(username, textInput, when);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    username = "Antoine";
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
        date.innerHTML = dateFormat(message.date, "MM-dd-yyyy HH:mm:ss");

        chat.appendChild(container);
        container.appendChild(container2);
        container2.appendChild(sender);
        container2.appendChild(date);
        chat.appendChild(container);
    }
    else {
        let container = document.createElement('div');
        container.className = "incoming_msg";

        // Ajuster pour image ici
        let container2 = document.createElement('div');
        container2.className = "sent_msg";
        container2.innerHTML = "<img  >";

        let container3 = document.createElement('div');
        container3.className = "received_msg";

        let container4 = document.createElement('div');
        container4.className = "received_withd_msg";

        let sender = document.createElement('p');
        sender.innerHTML = message.text;

        let date = document.createElement('span');
        date.className = "time_date";
        date.innerHTML = dateFormat(message.date, "MM-dd-yyyy HH:mm:ss");


        container.appendChild(container2);
        container2.appendChild(container3);
        container3.appendChild(container4);
        container4.appendChild(sender);
        container.appendChild(when);
        chat.appendChild(container);
    }
}