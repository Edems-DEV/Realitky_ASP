"use strict";

//(ui)
document.getElementById("sendButton").disabled = true;

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    SendMessage(user, message);
    event.preventDefault();
});

//------------------------------------------

//Connect
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// On connected
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

// From server
connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user}: ${message}`;
});

// Client to server
function SendMessage(user, message) {
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
}


