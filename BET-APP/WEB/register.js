document.addEventListener("DOMContentLoaded", function() {
    // Fonction pour s'inscrire
    function register() {
        // Récupérer les valeurs des champs du formulaire
        let username = document.getElementById("username").value.trim();
        let email = document.getElementById("email").value.trim();
        let password = document.getElementById("password").value.trim();
        let confirmPassword = document.getElementById("confirm-password").value.trim();

        // Vérification des champs
        if (!username || !email || !password || !confirmPassword) {
            alert("Veuillez remplir tous les champs.");
            return;
        }

        if (password !== confirmPassword) {
            alert("Les mots de passe ne correspondent pas.");
            return;
        }

        console.log("Données utilisateur : ", { username, email, password });

        // Préparer les données pour l'API
        const registrationData = {
            identifiant: username || "", // Par défaut, chaîne vide si le champ est vide
            adresse_mail: email || "",
            mot_de_passe: password || ""
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
                console.log("Réponse brute :", response);
                if (!response.ok) {
                    return response.json().then((err) => {
                        throw new Error(err.message || `HTTP error! status: ${response.status}`);
                    });
                }
                return response.json();
            })
            .then((data) => {
                console.log("Réponse du serveur :", data);
                alert(data || "Utilisateur ajouté avec succès !");
                // Réinitialisation du formulaire
                document.getElementById("register-form").reset();
            })
            .catch((error) => {
                console.error("Erreur lors de l'inscription :", error);
                alert(error.message || "Une erreur est survenue lors de l'inscription.");
            });
    }

    // Écoute de l'événement du bouton d'inscription
    document.getElementById("register-form").addEventListener("submit", function (e) {
        e.preventDefault(); // Empêcher le rechargement de la page
        register();
    });
});
