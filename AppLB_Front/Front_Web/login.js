document.addEventListener("DOMContentLoaded", function () {
    function showError(fieldId, message) {
        const errorElement = document.getElementById(`${fieldId}-error`);
        if (errorElement) {
            errorElement.textContent = message; // Afficher le message d'erreur
            errorElement.style.color = "red";  // Style pour rendre l'erreur visible
        }
    }

    function clearErrors() {
        document.querySelectorAll(".error-message").forEach((error) => {
            error.textContent = ""; // Efface les erreurs existantes
        });
    }

    function login() {
        clearErrors(); // Effacer les erreurs précédentes

        let username = document.getElementById("username").value.trim();
        let password = document.getElementById("password").value.trim();

        // Vérification des champs
        let hasError = false;
        if (!username) {
            showError("username", "Veuillez entrer votre identifiant.");
            hasError = true;
        }
        if (!password) {
            showError("password", "Veuillez entrer votre mot de passe.");
            hasError = true;
        }

        if (hasError) return; // Arrêter la soumission si des erreurs existent

        const loginData = {
            identifiant: username,
            mot_de_passe: password
        };

        fetch("http://localhost:5125/api/Controllers_Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(loginData),
        })
            .then((response) => {
                if (!response.ok) {
                    return response.json().then((err) => {
                        if (err.error.includes("Identifiant")) {
                            showError("username", err.error);
                        } else if (err.error.includes("Mot de passe")) {
                            showError("password", err.error);
                        } else {
                            showError("username", "Cet identifiant n'éxiste pas !");
                        }
                        throw new Error(err.error);
                    });
                }
                return response.json();
            })
            .then((data) => {
                localStorage.setItem("username", username); // Stocker l'identifiant
                window.location.href = "dashboard.html"; // Rediriger vers le tableau de bord
            })
    }

    document.getElementById("login-form").addEventListener("submit", function (e) {
        e.preventDefault();
        login();
    });
});
