document.addEventListener("DOMContentLoaded", function () {
    const username = localStorage.getItem("username");

    const welcomeMessage = document.getElementById("welcome-message");
    if (username) {
        welcomeMessage.textContent = `Bienvenue sur notre application : ${username} !`;
    } else {
        welcomeMessage.textContent = "Bienvenue sur notre application, invité !";
    }

    document.getElementById("logout-button").addEventListener("click", function () {
        localStorage.removeItem("username");
        window.location.href = "login.html";
    });
});
