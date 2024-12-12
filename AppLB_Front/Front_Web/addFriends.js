document.addEventListener("DOMContentLoaded", function () {
    function showError(fieldId, message) {
        const errorElement = document.getElementById(`${fieldId}-error`);
        if (errorElement) {
            errorElement.textContent = message;
            errorElement.style.color = "red";
        }
    }

    function clearErrors() {
        document.querySelectorAll(".error-message").forEach((error) => {
            error.textContent = "";
        });
    }

    function addFriend() {
        clearErrors();

        const friendUsername = document.getElementById("friend-username").value.trim();

        if (!friendUsername) {
            showError("friend-username", "Veuillez entrer un nom d'utilisateur.");
            return;
        }

        fetch("http://localhost:5125/api/Friends", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ friendUsername }),
        })
            .then((response) => {
                if (!response.ok) {
                    return response.json().then((err) => {
                        showError("friend-username", err.error || "Erreur lors de l'ajout.");
                        throw new Error(err.error);
                    });
                }
                return response.json();
            })
            .then(() => {
                alert("Ami ajouté avec succès !");
                document.getElementById("add-friend-form").reset();
            })
            .catch((error) => {
                console.error("Erreur :", error);
            });
    }

    document.getElementById("add-friend-form").addEventListener("submit", function (e) {
        e.preventDefault();
        addFriend();
    });
});
