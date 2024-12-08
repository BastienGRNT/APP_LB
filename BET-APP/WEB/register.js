document.addEventListener("DOMContentLoaded", function () {
    function showError(fieldId, message) {
        const errorElement = document.getElementById(`${fieldId}-error`);
        if (errorElement) {
            errorElement.textContent = message; // Injecter le message d'erreur dans le span
            errorElement.style.color = "red"; // Style d'erreur (optionnel)
        }
    }

    function clearErrors() {
        document.querySelectorAll(".error-message").forEach((error) => {
            error.textContent = ""; // Effacer le texte des erreurs précédentes
        });
    }

    function register() {
        clearErrors(); // Nettoyer les erreurs affichées

        // Récupérer les valeurs des champs du formulaire
        const username = document.getElementById("username").value.trim();
        const email = document.getElementById("email").value.trim();
        const password = document.getElementById("password").value.trim();
        const confirmPassword = document.getElementById("confirm-password").value.trim();

        // Vérification des champs
        let hasError = false;

        if (!username) {
            showError("username", "Veuillez entrer un nom d'utilisateur.");
            hasError = true;
        }

        if (!email) {
            showError("email", "Veuillez entrer une adresse mail.");
            hasError = true;
        }

        if (!password) {
            showError("password", "Veuillez entrer un mot de passe.");
            hasError = true;
        }

        if (password !== confirmPassword) {
            showError("confirm-password", "Les mots de passe ne correspondent pas.");
            hasError = true;
        }

        if (hasError) return; // Ne pas soumettre le formulaire si des erreurs existent

        const registrationData = {
            identifiant: username,
            adresse_mail: email,
            mot_de_passe: password,
        };

        // Appel à l'API pour enregistrer l'utilisateur
        fetch("http://localhost:5125/api/UserLogin", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(registrationData),
        })
            .then((response) => {
                if (!response.ok) {
                    // Traiter les erreurs retournées par l'API
                    return response.json().then((err) => {
                        console.error("Erreur retournée par l'API :", err.error);

                        // Gérer les erreurs spécifiques renvoyées par l'API
                        if (err.error.includes("mail")) {
                            showError("email", "Adresse mail déjà utilisée.");
                        } else if (err.error.includes("identifiant")) {
                            showError("username", "Nom d'utilisateur déjà utilisé.");
                        } else {
                            console.error("Erreur inconnue :", err.error);
                        }

                        throw new Error(err.error || "Erreur d'inscription.");
                    });
                }
                return response.json();
            })
            .then(() => {
                // Supprimer le formulaire et afficher le message de succès
                const container = document.querySelector(".container");
                container.innerHTML = "<h1>Création de compte réussi !!</h1>";

                // Rediriger vers la page de connexion après 3 secondes
                setTimeout(() => {
                    window.location.href = "login.html";
                }, 3000);
            })
            .catch((error) => {
                console.error("Erreur lors de l'inscription :", error);
            });
    }

    // Écoute de l'événement du bouton d'inscription
    document.getElementById("register-form").addEventListener("submit", function (e) {
        e.preventDefault(); // Empêcher le rechargement de la page
        register();
    });
});
