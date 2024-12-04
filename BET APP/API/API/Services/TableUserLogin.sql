CREATE TABLE user_login(
id_user SERIAL PRIMARY KEY,
identifiant VARCHAR(50) NOT NULL,
adresse_mail VARCHAR(50) NOT NULL,
mot_de_passe VARCHAR(50) NOT NULL,
UNIQUE(identifiant),
UNIQUE(adresse_mail)
);

